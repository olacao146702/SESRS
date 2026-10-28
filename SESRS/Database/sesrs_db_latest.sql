/*M!999999\- enable the sandbox mode */ 
-- MariaDB dump 10.19  Distrib 10.11.14-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: sesrs_db
-- ------------------------------------------------------
-- Server version	10.11.14-MariaDB-0ubuntu0.24.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `sesrs_db`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `sesrs_db` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci */;

USE `sesrs_db`;

--
-- Table structure for table `academic_periods`
--

DROP TABLE IF EXISTS `academic_periods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `academic_periods` (
  `period_id` int(11) NOT NULL AUTO_INCREMENT,
  `school_year` varchar(20) NOT NULL,
  `semester` varchar(20) NOT NULL,
  `enrollment_start` date NOT NULL,
  `enrollment_end` date NOT NULL,
  `min_units` int(11) NOT NULL DEFAULT 12,
  `max_units` int(11) NOT NULL DEFAULT 24,
  `is_current` tinyint(1) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`period_id`),
  UNIQUE KEY `uq_period` (`school_year`,`semester`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `academic_periods`
--

LOCK TABLES `academic_periods` WRITE;
/*!40000 ALTER TABLE `academic_periods` DISABLE KEYS */;
/*!40000 ALTER TABLE `academic_periods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `announcements`
--

DROP TABLE IF EXISTS `announcements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `announcements` (
  `announcement_id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(150) NOT NULL,
  `body` text NOT NULL,
  `program_id` int(11) DEFAULT NULL,
  `year_level` int(11) DEFAULT NULL,
  `section_id` int(11) DEFAULT NULL,
  `posted_by` int(11) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1,
  `expires_at` date DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`announcement_id`),
  KEY `idx_announce_created` (`created_at`),
  KEY `fk_announce_program` (`program_id`),
  KEY `fk_announce_section` (`section_id`),
  KEY `fk_announce_user` (`posted_by`),
  CONSTRAINT `fk_announce_program` FOREIGN KEY (`program_id`) REFERENCES `programs` (`program_id`) ON DELETE SET NULL,
  CONSTRAINT `fk_announce_section` FOREIGN KEY (`section_id`) REFERENCES `sections` (`section_id`) ON DELETE SET NULL,
  CONSTRAINT `fk_announce_user` FOREIGN KEY (`posted_by`) REFERENCES `users` (`user_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `announcements`
--

LOCK TABLES `announcements` WRITE;
/*!40000 ALTER TABLE `announcements` DISABLE KEYS */;
/*!40000 ALTER TABLE `announcements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `audit_log`
--

DROP TABLE IF EXISTS `audit_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `audit_log` (
  `audit_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `action` varchar(50) NOT NULL,
  `entity_type` varchar(50) NOT NULL,
  `entity_id` varchar(50) DEFAULT NULL,
  `details` varchar(500) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`audit_id`),
  KEY `idx_audit_created` (`created_at`),
  KEY `idx_audit_user` (`user_id`),
  KEY `idx_audit_entity` (`entity_type`,`entity_id`),
  CONSTRAINT `fk_audit_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `audit_log`
--

LOCK TABLES `audit_log` WRITE;
/*!40000 ALTER TABLE `audit_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `audit_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `curriculum`
--

DROP TABLE IF EXISTS `curriculum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `curriculum` (
  `curriculum_id` int(11) NOT NULL AUTO_INCREMENT,
  `program_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `year_level` int(11) NOT NULL,
  `semester` varchar(20) NOT NULL,
  `school_year` varchar(20) NOT NULL DEFAULT 'ALL',
  `prerequisite_subject_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`curriculum_id`),
  UNIQUE KEY `uq_curriculum_entry` (`program_id`,`subject_id`),
  KEY `fk_curriculum_program` (`program_id`),
  KEY `fk_curriculum_subject` (`subject_id`),
  KEY `fk_curriculum_prerequisite` (`prerequisite_subject_id`),
  CONSTRAINT `fk_curriculum_prerequisite` FOREIGN KEY (`prerequisite_subject_id`) REFERENCES `subjects` (`subject_id`),
  CONSTRAINT `fk_curriculum_program` FOREIGN KEY (`program_id`) REFERENCES `programs` (`program_id`),
  CONSTRAINT `fk_curriculum_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`subject_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curriculum`
--

LOCK TABLES `curriculum` WRITE;
/*!40000 ALTER TABLE `curriculum` DISABLE KEYS */;
/*!40000 ALTER TABLE `curriculum` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enrollment_details`
--

DROP TABLE IF EXISTS `enrollment_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `enrollment_details` (
  `enrollment_detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `enrollment_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL,
  `units` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`enrollment_detail_id`),
  UNIQUE KEY `uq_detail_subject` (`enrollment_id`,`subject_id`),
  KEY `fk_detail_enrollment` (`enrollment_id`),
  KEY `fk_detail_subject` (`subject_id`),
  KEY `fk_detail_section` (`section_id`),
  CONSTRAINT `fk_detail_enrollment` FOREIGN KEY (`enrollment_id`) REFERENCES `enrollments` (`enrollment_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_detail_section` FOREIGN KEY (`section_id`) REFERENCES `sections` (`section_id`),
  CONSTRAINT `fk_detail_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`subject_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrollment_details`
--

LOCK TABLES `enrollment_details` WRITE;
/*!40000 ALTER TABLE `enrollment_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `enrollment_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enrollments`
--

DROP TABLE IF EXISTS `enrollments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `enrollments` (
  `enrollment_id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `school_year` varchar(20) NOT NULL,
  `semester` varchar(20) NOT NULL,
  `enrollment_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `status` varchar(20) NOT NULL DEFAULT 'Pending',
  `submitted_at` datetime DEFAULT NULL,
  `reviewed_by` int(11) DEFAULT NULL,
  `reviewed_at` datetime DEFAULT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `total_units` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`enrollment_id`),
  KEY `fk_enrollment_student` (`student_id`),
  CONSTRAINT `fk_enrollment_student` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrollments`
--

LOCK TABLES `enrollments` WRITE;
/*!40000 ALTER TABLE `enrollments` DISABLE KEYS */;
/*!40000 ALTER TABLE `enrollments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grade_audit`
--

DROP TABLE IF EXISTS `grade_audit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `grade_audit` (
  `grade_audit_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `grade_id` int(11) DEFAULT NULL,
  `student_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `changed_by` int(11) DEFAULT NULL,
  `changed_by_name` varchar(100) DEFAULT NULL,
  `action` varchar(20) NOT NULL,
  `old_final` decimal(4,2) DEFAULT NULL,
  `new_final` decimal(4,2) DEFAULT NULL,
  `old_status` varchar(10) DEFAULT NULL,
  `new_status` varchar(10) DEFAULT NULL,
  `reason` varchar(255) DEFAULT NULL,
  `changed_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`grade_audit_id`),
  KEY `idx_gaudit_student` (`student_id`,`subject_id`),
  KEY `idx_gaudit_time` (`changed_at`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grade_audit`
--

LOCK TABLES `grade_audit` WRITE;
/*!40000 ALTER TABLE `grade_audit` DISABLE KEYS */;
/*!40000 ALTER TABLE `grade_audit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grade_scores`
--

DROP TABLE IF EXISTS `grade_scores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `grade_scores` (
  `grade_id` int(11) NOT NULL,
  `component_id` int(11) NOT NULL,
  `score` decimal(5,2) NOT NULL,
  PRIMARY KEY (`grade_id`,`component_id`),
  KEY `idx_score_component` (`component_id`),
  CONSTRAINT `fk_score_component` FOREIGN KEY (`component_id`) REFERENCES `grading_components` (`component_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_score_grade` FOREIGN KEY (`grade_id`) REFERENCES `grades` (`grade_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grade_scores`
--

LOCK TABLES `grade_scores` WRITE;
/*!40000 ALTER TABLE `grade_scores` DISABLE KEYS */;
/*!40000 ALTER TABLE `grade_scores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grades`
--

DROP TABLE IF EXISTS `grades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `grades` (
  `grade_id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `school_year` varchar(20) NOT NULL,
  `semester` varchar(20) NOT NULL,
  `section_id` int(11) DEFAULT NULL,
  `percent` decimal(5,2) DEFAULT NULL,
  `final_grade` decimal(4,2) DEFAULT NULL,
  `result` varchar(12) NOT NULL DEFAULT 'Pending',
  `grade_status` varchar(10) NOT NULL DEFAULT 'Draft',
  `is_published` tinyint(1) NOT NULL DEFAULT 0,
  `published_at` datetime DEFAULT NULL,
  `updated_by` int(11) DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`grade_id`),
  UNIQUE KEY `uq_grade` (`student_id`,`subject_id`,`school_year`,`semester`),
  KEY `idx_grade_subject` (`subject_id`),
  CONSTRAINT `fk_grade_student` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_grade_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`subject_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grades`
--

LOCK TABLES `grades` WRITE;
/*!40000 ALTER TABLE `grades` DISABLE KEYS */;
/*!40000 ALTER TABLE `grades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grading_components`
--

DROP TABLE IF EXISTS `grading_components`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `grading_components` (
  `component_id` int(11) NOT NULL AUTO_INCREMENT,
  `subject_id` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `weight` decimal(5,2) NOT NULL,
  `sort_order` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`component_id`),
  KEY `idx_component_subject` (`subject_id`),
  CONSTRAINT `fk_component_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`subject_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grading_components`
--

LOCK TABLES `grading_components` WRITE;
/*!40000 ALTER TABLE `grading_components` DISABLE KEYS */;
INSERT INTO `grading_components` VALUES
(1,NULL,'Class Standing',40.00,1),
(2,NULL,'Midterm Exam',30.00,2),
(3,NULL,'Final Exam',30.00,3);
/*!40000 ALTER TABLE `grading_components` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grading_scale`
--

DROP TABLE IF EXISTS `grading_scale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `grading_scale` (
  `scale_id` int(11) NOT NULL AUTO_INCREMENT,
  `min_percent` decimal(5,2) NOT NULL,
  `grade_point` decimal(3,2) NOT NULL,
  `result` varchar(10) NOT NULL,
  PRIMARY KEY (`scale_id`),
  UNIQUE KEY `uq_scale_min` (`min_percent`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grading_scale`
--

LOCK TABLES `grading_scale` WRITE;
/*!40000 ALTER TABLE `grading_scale` DISABLE KEYS */;
INSERT INTO `grading_scale` VALUES
(1,97.00,1.00,'Passed'),
(2,94.00,1.25,'Passed'),
(3,91.00,1.50,'Passed'),
(4,88.00,1.75,'Passed'),
(5,85.00,2.00,'Passed'),
(6,82.00,2.25,'Passed'),
(7,79.00,2.50,'Passed'),
(8,76.00,2.75,'Passed'),
(9,75.00,3.00,'Passed'),
(10,0.00,5.00,'Failed');
/*!40000 ALTER TABLE `grading_scale` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notifications`
--

DROP TABLE IF EXISTS `notifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `notifications` (
  `notification_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `title` varchar(100) NOT NULL,
  `message` varchar(255) NOT NULL,
  `is_read` tinyint(1) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `link` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`notification_id`),
  KEY `fk_notification_user` (`user_id`),
  KEY `idx_notification_user` (`user_id`,`is_read`,`created_at`),
  CONSTRAINT `fk_notification_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notifications`
--

LOCK TABLES `notifications` WRITE;
/*!40000 ALTER TABLE `notifications` DISABLE KEYS */;
/*!40000 ALTER TABLE `notifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `programs`
--

DROP TABLE IF EXISTS `programs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `programs` (
  `program_id` int(11) NOT NULL AUTO_INCREMENT,
  `program_code` varchar(20) NOT NULL,
  `program_name` varchar(150) NOT NULL,
  `duration_years` int(11) NOT NULL DEFAULT 4,
  `status` varchar(20) NOT NULL DEFAULT 'Active',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`program_id`),
  UNIQUE KEY `program_code` (`program_code`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `programs`
--

LOCK TABLES `programs` WRITE;
/*!40000 ALTER TABLE `programs` DISABLE KEYS */;
INSERT INTO `programs` VALUES
(1,'BSIT','Bachelor of Science in Information Technology',4,'Active','2026-09-21 12:57:45'),
(2,'BSBA','Bachelor of Science in Business Administration',4,'Active','2026-09-21 12:57:45'),
(3,'BSED','Bachelor of Secondary Education',4,'Active','2026-09-21 12:57:45'),
(4,'BEED','Bachelor of Elementary Education',4,'Active','2026-09-21 12:57:45');
/*!40000 ALTER TABLE `programs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedules`
--

DROP TABLE IF EXISTS `schedules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedules` (
  `schedule_id` int(11) NOT NULL AUTO_INCREMENT,
  `section_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `instructor` varchar(100) DEFAULT NULL,
  `room` varchar(50) DEFAULT NULL,
  `day` varchar(20) NOT NULL,
  `start_time` time NOT NULL,
  `end_time` time NOT NULL,
  PRIMARY KEY (`schedule_id`),
  KEY `fk_schedule_section` (`section_id`),
  KEY `fk_schedule_subject` (`subject_id`),
  CONSTRAINT `fk_schedule_section` FOREIGN KEY (`section_id`) REFERENCES `sections` (`section_id`),
  CONSTRAINT `fk_schedule_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`subject_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedules`
--

LOCK TABLES `schedules` WRITE;
/*!40000 ALTER TABLE `schedules` DISABLE KEYS */;
/*!40000 ALTER TABLE `schedules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sections`
--

DROP TABLE IF EXISTS `sections`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `sections` (
  `section_id` int(11) NOT NULL AUTO_INCREMENT,
  `section_code` varchar(30) NOT NULL,
  `section_name` varchar(100) NOT NULL,
  `program_id` int(11) NOT NULL,
  `year_level` int(11) NOT NULL,
  `semester` varchar(20) NOT NULL,
  `school_year` varchar(20) NOT NULL,
  `capacity` int(11) NOT NULL DEFAULT 40,
  `status` varchar(20) NOT NULL DEFAULT 'Active',
  PRIMARY KEY (`section_id`),
  KEY `fk_section_program` (`program_id`),
  CONSTRAINT `fk_section_program` FOREIGN KEY (`program_id`) REFERENCES `programs` (`program_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sections`
--

LOCK TABLES `sections` WRITE;
/*!40000 ALTER TABLE `sections` DISABLE KEYS */;
/*!40000 ALTER TABLE `sections` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `students` (
  `student_id` int(11) NOT NULL AUTO_INCREMENT,
  `student_number` varchar(30) DEFAULT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) NOT NULL,
  `gender` varchar(20) DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone` varchar(30) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `program_id` int(11) NOT NULL,
  `year_level` int(11) NOT NULL,
  `status` enum('Active','Inactive') NOT NULL DEFAULT 'Active',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`student_id`),
  UNIQUE KEY `student_number` (`student_number`),
  KEY `fk_student_program` (`program_id`),
  CONSTRAINT `fk_student_program` FOREIGN KEY (`program_id`) REFERENCES `programs` (`program_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES
(1,'146702','jade','husain','olacao','Male','2006-02-28','chie2k19@gmail.com','09052493502','Prk. Humabon, Brgy. Cuambogan, Tagum City',1,3,'Active','2026-09-21 14:13:56'),
(16,'20260001','Ethel Ruth','Ignacio','billien','Female','2005-01-10','ethelbillien@gmail.com','09978072040','Tagum City',3,3,'Active','2026-09-22 11:54:47'),
(17,'20260002','mike airon','T','iroy','Female','2026-09-23','iroy@gmail.com','090610244412','prk humabon tagum city',2,4,'Active','2026-09-23 12:29:02'),
(18,NULL,'john','','pork','Female','2026-09-24','johnpork@gmail.com','09088184444','Konoha',4,1,'Inactive','2026-09-23 17:42:19');
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject_prerequisites`
--

DROP TABLE IF EXISTS `subject_prerequisites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `subject_prerequisites` (
  `subject_id` int(11) NOT NULL,
  `prerequisite_subject_id` int(11) NOT NULL,
  PRIMARY KEY (`subject_id`,`prerequisite_subject_id`),
  KEY `fk_prereq_required` (`prerequisite_subject_id`),
  CONSTRAINT `fk_prereq_required` FOREIGN KEY (`prerequisite_subject_id`) REFERENCES `subjects` (`subject_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_prereq_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`subject_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject_prerequisites`
--

LOCK TABLES `subject_prerequisites` WRITE;
/*!40000 ALTER TABLE `subject_prerequisites` DISABLE KEYS */;
/*!40000 ALTER TABLE `subject_prerequisites` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subjects`
--

DROP TABLE IF EXISTS `subjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `subjects` (
  `subject_id` int(11) NOT NULL AUTO_INCREMENT,
  `subject_code` varchar(30) NOT NULL,
  `subject_name` varchar(150) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `units` int(11) NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'Active',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`subject_id`),
  UNIQUE KEY `subject_code` (`subject_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subjects`
--

LOCK TABLES `subjects` WRITE;
/*!40000 ALTER TABLE `subjects` DISABLE KEYS */;
/*!40000 ALTER TABLE `subjects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `role` varchar(20) NOT NULL,
  `student_id` int(11) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `status` enum('Active','Inactive') NOT NULL DEFAULT 'Active',
  `must_change_password` tinyint(1) NOT NULL DEFAULT 0,
  `failed_attempts` int(11) NOT NULL DEFAULT 0,
  `locked_until` datetime DEFAULT NULL,
  `last_login_at` datetime DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`),
  KEY `fk_user_student` (`student_id`),
  CONSTRAINT `fk_user_student` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES
(1,'Zergking','$2a$11$113SSS.3w.hLdqYjlJQ6Fu618YCN9aBRqHoFHH0A9iJeNFYI3W7Zq','jade husain olacao','Student',1,'2026-09-21 14:13:56','Active',0,0,NULL,NULL),
(2,'ethel','$2a$11$xIoiri9x/f5KrLCS0Vr9jusX4HBwPLUrIYWnaH9Dvi.yeuYTA9KMW','Ethel Ruth Ignacio billien','Student',16,'2026-09-22 11:54:48','Active',0,0,NULL,NULL),
(3,'admin','$2a$11$tlfO6K46knMyLfwWxug.tOBwy4sRgq8X6VC2lr9Vc8Sufh3VA10WK','SESRS Administrator','Admin',NULL,'2026-09-22 13:39:45','Active',0,0,NULL,NULL),
(4,'mike','$2a$11$lBGAkwgdPSn6apaPlZyeDeZ3P/RbHoISX4cdBDaVxIJXRi4WRyswO','mike airon T iroy','Student',17,'2026-09-23 12:29:02','Active',0,0,NULL,NULL),
(5,'john','$2a$11$DrMJaDyMK9Q12ohs5wDE6uvSNNjKn.JDXIk.BFpz1LwrDep0.YvbC','john  pork','Student',18,'2026-09-23 17:42:19','Inactive',0,0,NULL,NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `waitlist`
--

DROP TABLE IF EXISTS `waitlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `waitlist` (
  `waitlist_id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `status` varchar(12) NOT NULL DEFAULT 'Waiting',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`waitlist_id`),
  UNIQUE KEY `uq_waitlist` (`student_id`,`section_id`,`subject_id`),
  KEY `idx_waitlist_queue` (`section_id`,`subject_id`,`status`,`created_at`),
  KEY `fk_waitlist_subject` (`subject_id`),
  CONSTRAINT `fk_waitlist_section` FOREIGN KEY (`section_id`) REFERENCES `sections` (`section_id`),
  CONSTRAINT `fk_waitlist_student` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_waitlist_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`subject_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `waitlist`
--

LOCK TABLES `waitlist` WRITE;
/*!40000 ALTER TABLE `waitlist` DISABLE KEYS */;
/*!40000 ALTER TABLE `waitlist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'sesrs_db'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-10-21  1:55:04
