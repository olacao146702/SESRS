-- SESRS Phase 3 migration: announcements (read by the student portal; publishing
-- screens arrive in Phase 5) and notification indexes. Additive and safe to run twice.

USE sesrs_db;

-- An announcement is shown to students matching ALL non-NULL targets.
-- NULL program/year/section = everyone.
CREATE TABLE IF NOT EXISTS announcements (
  announcement_id INT          NOT NULL AUTO_INCREMENT,
  title           VARCHAR(150) NOT NULL,
  body            TEXT         NOT NULL,
  program_id      INT          NULL,
  year_level      INT          NULL,
  section_id      INT          NULL,
  posted_by       INT          NULL,
  is_active       TINYINT(1)   NOT NULL DEFAULT 1,
  expires_at      DATE         NULL,
  created_at      TIMESTAMP    NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (announcement_id),
  KEY idx_announce_created (created_at),
  CONSTRAINT fk_announce_program FOREIGN KEY (program_id) REFERENCES programs (program_id) ON DELETE SET NULL,
  CONSTRAINT fk_announce_section FOREIGN KEY (section_id) REFERENCES sections (section_id) ON DELETE SET NULL,
  CONSTRAINT fk_announce_user FOREIGN KEY (posted_by) REFERENCES users (user_id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

ALTER TABLE notifications ADD INDEX IF NOT EXISTS idx_notification_user (user_id, is_read, created_at);
