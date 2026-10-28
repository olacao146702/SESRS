-- SESRS migration 005: public sign-up and the pending-account queue no longer exist.
-- Students are created directly by an administrator, so "Pending" is no longer a valid account status.
-- NOTHING IS DELETED: any account that was still Pending becomes Inactive and stays in the Students list.
-- (Activating it there assigns an official student number automatically.)
-- Safe to run twice. Back up first: mysqldump -u root sesrs_db > backup.sql

USE sesrs_db;

UPDATE students SET status = 'Inactive' WHERE status = 'Pending';
UPDATE users    SET status = 'Inactive' WHERE status = 'Pending';

ALTER TABLE students MODIFY COLUMN status ENUM('Active','Inactive') NOT NULL DEFAULT 'Active';
ALTER TABLE users    MODIFY COLUMN status ENUM('Active','Inactive') NOT NULL DEFAULT 'Active';
