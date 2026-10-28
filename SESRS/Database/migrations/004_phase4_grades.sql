-- SESRS Phase 4 migration: grading components, grading scale, score storage,
-- review/publication workflow, and a grade change audit trail.
-- Additive and safe to run twice.

USE sesrs_db;

ALTER TABLE grades
  ADD COLUMN IF NOT EXISTS percent      DECIMAL(5,2) NULL AFTER section_id,
  ADD COLUMN IF NOT EXISTS grade_status VARCHAR(10)  NOT NULL DEFAULT 'Draft' AFTER result,
  ADD COLUMN IF NOT EXISTS remarks      VARCHAR(255) NULL;

-- Grades that were already visible to students stay visible.
UPDATE grades SET grade_status = 'Published' WHERE is_published = 1 AND grade_status = 'Draft';

-- A component belongs to one subject, or to everyone when subject_id is NULL (the default setup).
CREATE TABLE IF NOT EXISTS grading_components (
  component_id INT          NOT NULL AUTO_INCREMENT,
  subject_id   INT          NULL,
  name         VARCHAR(50)  NOT NULL,
  weight       DECIMAL(5,2) NOT NULL,
  sort_order   INT          NOT NULL DEFAULT 0,
  PRIMARY KEY (component_id),
  KEY idx_component_subject (subject_id),
  CONSTRAINT fk_component_subject FOREIGN KEY (subject_id) REFERENCES subjects (subject_id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Percent -> grade point conversion. result is Passed or Failed.
CREATE TABLE IF NOT EXISTS grading_scale (
  scale_id    INT          NOT NULL AUTO_INCREMENT,
  min_percent DECIMAL(5,2) NOT NULL,
  grade_point DECIMAL(3,2) NOT NULL,
  result      VARCHAR(10)  NOT NULL,
  PRIMARY KEY (scale_id),
  UNIQUE KEY uq_scale_min (min_percent)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS grade_scores (
  grade_id     INT          NOT NULL,
  component_id INT          NOT NULL,
  score        DECIMAL(5,2) NOT NULL,
  PRIMARY KEY (grade_id, component_id),
  KEY idx_score_component (component_id),
  CONSTRAINT fk_score_grade FOREIGN KEY (grade_id) REFERENCES grades (grade_id) ON DELETE CASCADE,
  CONSTRAINT fk_score_component FOREIGN KEY (component_id) REFERENCES grading_components (component_id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Who changed which grade, when, from what to what.
CREATE TABLE IF NOT EXISTS grade_audit (
  grade_audit_id BIGINT       NOT NULL AUTO_INCREMENT,
  grade_id       INT          NULL,
  student_id     INT          NOT NULL,
  subject_id     INT          NOT NULL,
  changed_by     INT          NULL,
  changed_by_name VARCHAR(100) NULL,
  action         VARCHAR(20)  NOT NULL,
  old_final      DECIMAL(4,2) NULL,
  new_final      DECIMAL(4,2) NULL,
  old_status     VARCHAR(10)  NULL,
  new_status     VARCHAR(10)  NULL,
  reason         VARCHAR(255) NULL,
  changed_at     TIMESTAMP    NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (grade_audit_id),
  KEY idx_gaudit_student (student_id, subject_id),
  KEY idx_gaudit_time (changed_at)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Defaults (only when nothing is configured yet).
INSERT INTO grading_components (subject_id, name, weight, sort_order)
SELECT NULL, t.name, t.weight, t.sort_order FROM (
    SELECT 'Class Standing' AS name, 40.00 AS weight, 1 AS sort_order
    UNION ALL SELECT 'Midterm Exam', 30.00, 2
    UNION ALL SELECT 'Final Exam', 30.00, 3
) AS t
WHERE NOT EXISTS (SELECT 1 FROM grading_components);

INSERT INTO grading_scale (min_percent, grade_point, result)
SELECT t.min_percent, t.grade_point, t.result FROM (
    SELECT 97.00 AS min_percent, 1.00 AS grade_point, 'Passed' AS result
    UNION ALL SELECT 94.00, 1.25, 'Passed'
    UNION ALL SELECT 91.00, 1.50, 'Passed'
    UNION ALL SELECT 88.00, 1.75, 'Passed'
    UNION ALL SELECT 85.00, 2.00, 'Passed'
    UNION ALL SELECT 82.00, 2.25, 'Passed'
    UNION ALL SELECT 79.00, 2.50, 'Passed'
    UNION ALL SELECT 76.00, 2.75, 'Passed'
    UNION ALL SELECT 75.00, 3.00, 'Passed'
    UNION ALL SELECT 0.00, 5.00, 'Failed'
) AS t
WHERE NOT EXISTS (SELECT 1 FROM grading_scale);
