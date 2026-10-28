-- SESRS Phase 2 migration: enrollment workflow, academic periods, prerequisites,
-- waitlist, and the grades table needed for prerequisite/completion checks.
-- Additive and safe to run twice. Back up first: mysqldump -u root sesrs_db > backup.sql

USE sesrs_db;

-- ---------------------------------------------------------------
-- Academic periods (enrollment windows and configurable unit limits)
-- ---------------------------------------------------------------
CREATE TABLE IF NOT EXISTS academic_periods (
  period_id        INT         NOT NULL AUTO_INCREMENT,
  school_year      VARCHAR(20) NOT NULL,
  semester         VARCHAR(20) NOT NULL,
  enrollment_start DATE        NOT NULL,
  enrollment_end   DATE        NOT NULL,
  min_units        INT         NOT NULL DEFAULT 12,
  max_units        INT         NOT NULL DEFAULT 24,
  is_current       TINYINT(1)  NOT NULL DEFAULT 0,
  created_at       TIMESTAMP   NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (period_id),
  UNIQUE KEY uq_period (school_year, semester)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- ---------------------------------------------------------------
-- Subject prerequisites (many per subject). Existing single
-- curriculum.prerequisite_subject_id values are copied across.
-- ---------------------------------------------------------------
CREATE TABLE IF NOT EXISTS subject_prerequisites (
  subject_id              INT NOT NULL,
  prerequisite_subject_id INT NOT NULL,
  PRIMARY KEY (subject_id, prerequisite_subject_id),
  KEY fk_prereq_required (prerequisite_subject_id),
  CONSTRAINT fk_prereq_subject  FOREIGN KEY (subject_id) REFERENCES subjects (subject_id) ON DELETE CASCADE,
  CONSTRAINT fk_prereq_required FOREIGN KEY (prerequisite_subject_id) REFERENCES subjects (subject_id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

INSERT IGNORE INTO subject_prerequisites (subject_id, prerequisite_subject_id)
SELECT DISTINCT subject_id, prerequisite_subject_id
FROM curriculum
WHERE prerequisite_subject_id IS NOT NULL AND prerequisite_subject_id <> subject_id;

-- A curriculum is not tied to one school year.
ALTER TABLE curriculum MODIFY school_year VARCHAR(20) NOT NULL DEFAULT 'ALL';
ALTER TABLE curriculum ADD UNIQUE KEY IF NOT EXISTS uq_curriculum_entry (program_id, subject_id);

-- ---------------------------------------------------------------
-- Enrollments: review trail and unit totals.
-- Status values: Pending, Approved, Returned, Rejected, Cancelled
-- ---------------------------------------------------------------
ALTER TABLE enrollments
  ADD COLUMN IF NOT EXISTS submitted_at DATETIME NULL,
  ADD COLUMN IF NOT EXISTS reviewed_by  INT NULL,
  ADD COLUMN IF NOT EXISTS reviewed_at  DATETIME NULL,
  ADD COLUMN IF NOT EXISTS remarks      VARCHAR(255) NULL,
  ADD COLUMN IF NOT EXISTS total_units  INT NOT NULL DEFAULT 0;

ALTER TABLE enrollment_details
  ADD COLUMN IF NOT EXISTS units INT NOT NULL DEFAULT 0;
ALTER TABLE enrollment_details
  ADD UNIQUE KEY IF NOT EXISTS uq_detail_subject (enrollment_id, subject_id);

-- ---------------------------------------------------------------
-- Waitlist for full sections
-- Status: Waiting, Notified, Enrolled, Removed
-- ---------------------------------------------------------------
CREATE TABLE IF NOT EXISTS waitlist (
  waitlist_id INT         NOT NULL AUTO_INCREMENT,
  student_id  INT         NOT NULL,
  section_id  INT         NOT NULL,
  subject_id  INT         NOT NULL,
  status      VARCHAR(12) NOT NULL DEFAULT 'Waiting',
  created_at  TIMESTAMP   NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (waitlist_id),
  UNIQUE KEY uq_waitlist (student_id, section_id, subject_id),
  KEY idx_waitlist_queue (section_id, subject_id, status, created_at),
  CONSTRAINT fk_waitlist_student FOREIGN KEY (student_id) REFERENCES students (student_id) ON DELETE CASCADE,
  CONSTRAINT fk_waitlist_section FOREIGN KEY (section_id) REFERENCES sections (section_id),
  CONSTRAINT fk_waitlist_subject FOREIGN KEY (subject_id) REFERENCES subjects (subject_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- ---------------------------------------------------------------
-- Grades (entry/publication screens arrive in Phase 4; the table is
-- needed now so completed subjects and prerequisites can be checked).
-- result: Pending, Passed, Failed, Incomplete, Dropped
-- ---------------------------------------------------------------
CREATE TABLE IF NOT EXISTS grades (
  grade_id     INT           NOT NULL AUTO_INCREMENT,
  student_id   INT           NOT NULL,
  subject_id   INT           NOT NULL,
  school_year  VARCHAR(20)   NOT NULL,
  semester     VARCHAR(20)   NOT NULL,
  section_id   INT           NULL,
  final_grade  DECIMAL(4,2)  NULL,
  result       VARCHAR(12)   NOT NULL DEFAULT 'Pending',
  is_published TINYINT(1)    NOT NULL DEFAULT 0,
  published_at DATETIME      NULL,
  updated_by   INT           NULL,
  updated_at   DATETIME      NULL,
  PRIMARY KEY (grade_id),
  UNIQUE KEY uq_grade (student_id, subject_id, school_year, semester),
  KEY idx_grade_subject (subject_id),
  CONSTRAINT fk_grade_student FOREIGN KEY (student_id) REFERENCES students (student_id) ON DELETE CASCADE,
  CONSTRAINT fk_grade_subject FOREIGN KEY (subject_id) REFERENCES subjects (subject_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Notifications can point to the screen they relate to.
ALTER TABLE notifications ADD COLUMN IF NOT EXISTS link VARCHAR(50) NULL;
