-- SESRS Phase 1 migration (additive: no existing data is dropped or changed).
-- Run once against sesrs_db (MariaDB 10.4+ / MySQL 8+ compatible except
-- "ADD COLUMN IF NOT EXISTS", which needs MariaDB 10.0.2+; XAMPP is fine).
-- Back up the database first: mysqldump -u root sesrs_db > backup.sql

USE sesrs_db;

-- Account security: forced password change, lockout, last login.
ALTER TABLE users
  ADD COLUMN IF NOT EXISTS must_change_password TINYINT(1) NOT NULL DEFAULT 0 AFTER status,
  ADD COLUMN IF NOT EXISTS failed_attempts INT NOT NULL DEFAULT 0 AFTER must_change_password,
  ADD COLUMN IF NOT EXISTS locked_until DATETIME NULL AFTER failed_attempts,
  ADD COLUMN IF NOT EXISTS last_login_at DATETIME NULL AFTER locked_until;

-- Audit trail for sensitive actions (logins, account changes, approvals).
CREATE TABLE IF NOT EXISTS audit_log (
  audit_id    BIGINT       NOT NULL AUTO_INCREMENT,
  user_id     INT          NULL,
  username    VARCHAR(50)  NULL,
  action      VARCHAR(50)  NOT NULL,
  entity_type VARCHAR(50)  NOT NULL,
  entity_id   VARCHAR(50)  NULL,
  details     VARCHAR(500) NULL,
  created_at  TIMESTAMP    NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (audit_id),
  KEY idx_audit_created (created_at),
  KEY idx_audit_user (user_id),
  KEY idx_audit_entity (entity_type, entity_id),
  CONSTRAINT fk_audit_user FOREIGN KEY (user_id)
    REFERENCES users (user_id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
