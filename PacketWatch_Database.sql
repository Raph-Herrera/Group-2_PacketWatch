-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: packetwatch
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alerts`
--

DROP TABLE IF EXISTS `alerts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alerts` (
  `alert_id` bigint NOT NULL AUTO_INCREMENT,
  `rule_id` int DEFAULT NULL,
  `packet_id` bigint DEFAULT NULL,
  `timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `source_ip` varchar(45) DEFAULT NULL,
  `destination_ip` varchar(45) DEFAULT NULL,
  `severity_level` enum('Low','Medium','High','Critical') DEFAULT NULL,
  `alert_message` text,
  `details` text,
  `is_resolved` tinyint(1) DEFAULT '0',
  `resolved_by` int DEFAULT NULL,
  `resolved_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`alert_id`),
  KEY `rule_id` (`rule_id`),
  KEY `packet_id` (`packet_id`),
  KEY `resolved_by` (`resolved_by`),
  KEY `timestamp` (`timestamp`),
  KEY `severity_level` (`severity_level`),
  KEY `is_resolved` (`is_resolved`),
  KEY `source_ip` (`source_ip`),
  CONSTRAINT `alerts_ibfk_1` FOREIGN KEY (`rule_id`) REFERENCES `detection_rules` (`rule_id`) ON DELETE SET NULL,
  CONSTRAINT `alerts_ibfk_2` FOREIGN KEY (`packet_id`) REFERENCES `packets` (`packet_id`) ON DELETE SET NULL,
  CONSTRAINT `alerts_ibfk_3` FOREIGN KEY (`resolved_by`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alerts`
--

LOCK TABLES `alerts` WRITE;
/*!40000 ALTER TABLE `alerts` DISABLE KEYS */;
/*!40000 ALTER TABLE `alerts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dashboard_metrics`
--

DROP TABLE IF EXISTS `dashboard_metrics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dashboard_metrics` (
  `metric_id` int NOT NULL AUTO_INCREMENT,
  `metric_date` date NOT NULL,
  `total_packets_captured` bigint DEFAULT NULL,
  `tcp_packets` int DEFAULT NULL,
  `udp_packets` int DEFAULT NULL,
  `other_packets` int DEFAULT NULL,
  `total_alerts` int DEFAULT NULL,
  `critical_alerts` int DEFAULT NULL,
  `high_alerts` int DEFAULT NULL,
  `average_packet_size` int DEFAULT NULL,
  `peak_traffic_time` time DEFAULT NULL,
  `recorded_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`metric_id`),
  UNIQUE KEY `unique_date` (`metric_date`),
  KEY `metric_date` (`metric_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dashboard_metrics`
--

LOCK TABLES `dashboard_metrics` WRITE;
/*!40000 ALTER TABLE `dashboard_metrics` DISABLE KEYS */;
/*!40000 ALTER TABLE `dashboard_metrics` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detection_rules`
--

DROP TABLE IF EXISTS `detection_rules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detection_rules` (
  `rule_id` int NOT NULL AUTO_INCREMENT,
  `rule_name` varchar(100) NOT NULL,
  `description` text,
  `severity_level` enum('Low','Medium','High','Critical') DEFAULT NULL,
  `pattern_type` varchar(50) DEFAULT NULL,
  `pattern_value` varchar(255) DEFAULT NULL,
  `is_enabled` tinyint(1) DEFAULT '1',
  `created_by` int DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`rule_id`),
  KEY `created_by` (`created_by`),
  KEY `severity_level` (`severity_level`),
  KEY `is_enabled` (`is_enabled`),
  CONSTRAINT `detection_rules_ibfk_1` FOREIGN KEY (`created_by`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detection_rules`
--

LOCK TABLES `detection_rules` WRITE;
/*!40000 ALTER TABLE `detection_rules` DISABLE KEYS */;
INSERT INTO `detection_rules` VALUES (1,'Port Scan Detection','Detects rapid port scanning activity','High','port','0',1,1,'2026-05-17 09:13:43','2026-05-17 09:13:43'),(2,'SSH Brute Force','Detects repeated SSH login attempts','Critical','port','22',1,1,'2026-05-17 09:13:43','2026-05-17 09:13:43'),(3,'DNS Amplification','Detects DNS amplification attack pattern','Medium','port','53',1,1,'2026-05-17 09:13:43','2026-05-17 09:13:43'),(4,'ICMP Flood','Detects ICMP flood attack','High','protocol','ICMP',1,1,'2026-05-17 09:13:43','2026-05-17 09:13:43'),(5,'Suspicious High Port','Traffic on unusual high port numbers','Low','port','9999',1,1,'2026-05-17 09:13:43','2026-05-17 09:13:43');
/*!40000 ALTER TABLE `detection_rules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `packet_logs`
--

DROP TABLE IF EXISTS `packet_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `packet_logs` (
  `log_id` bigint NOT NULL AUTO_INCREMENT,
  `packet_id` bigint NOT NULL,
  `action` varchar(50) DEFAULT NULL,
  `details` text,
  `logged_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`log_id`),
  KEY `packet_id` (`packet_id`),
  KEY `logged_at` (`logged_at`),
  CONSTRAINT `packet_logs_ibfk_1` FOREIGN KEY (`packet_id`) REFERENCES `packets` (`packet_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13409 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `packet_logs`
--

LOCK TABLES `packet_logs` WRITE;
/*!40000 ALTER TABLE `packet_logs` DISABLE KEYS */;
/*!40000 ALTER TABLE `packet_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `packets`
--

DROP TABLE IF EXISTS `packets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `packets` (
  `packet_id` bigint NOT NULL AUTO_INCREMENT,
  `timestamp` timestamp(6) NULL DEFAULT CURRENT_TIMESTAMP(6),
  `source_ip` varchar(45) NOT NULL,
  `destination_ip` varchar(45) NOT NULL,
  `source_port` int DEFAULT NULL,
  `destination_port` int DEFAULT NULL,
  `protocol` varchar(10) DEFAULT NULL,
  `packet_size` int DEFAULT NULL,
  `flags` varchar(50) DEFAULT NULL,
  `payload_summary` text,
  `ttl` int DEFAULT NULL,
  `checksum` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`packet_id`),
  KEY `timestamp` (`timestamp`),
  KEY `source_ip` (`source_ip`),
  KEY `destination_ip` (`destination_ip`),
  KEY `protocol` (`protocol`)
) ENGINE=InnoDB AUTO_INCREMENT=13410 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `packets`
--

LOCK TABLES `packets` WRITE;
/*!40000 ALTER TABLE `packets` DISABLE KEYS */;
/*!40000 ALTER TABLE `packets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_activity_log`
--

DROP TABLE IF EXISTS `user_activity_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_activity_log` (
  `activity_id` bigint NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `action` varchar(100) DEFAULT NULL,
  `details` text,
  `ip_address` varchar(45) DEFAULT NULL,
  `activity_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`activity_id`),
  KEY `user_id` (`user_id`),
  KEY `activity_at` (`activity_at`),
  CONSTRAINT `user_activity_log_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_activity_log`
--

LOCK TABLES `user_activity_log` WRITE;
/*!40000 ALTER TABLE `user_activity_log` DISABLE KEYS */;
INSERT INTO `user_activity_log` VALUES (1,1,'CLEAR_LOG','Activity log cleared','192.168.1.8','2026-05-17 15:26:29');
/*!40000 ALTER TABLE `user_activity_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `role` enum('Admin','User') DEFAULT 'User',
  `is_active` tinyint(1) DEFAULT '1',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `last_login` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `unique_email` (`email`),
  UNIQUE KEY `email` (`email`),
  KEY `username_2` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9','admin@packetwatch.com','Admin','User','Admin',1,'2026-05-17 09:12:46','2026-05-17 15:25:33');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-17 23:44:08
