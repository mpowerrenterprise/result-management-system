-- MySqlBackup.NET 2.0.4
-- Dump Time: 2018-09-10 00:14:55
-- --------------------------------------
-- Server version 10.1.16-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of batch
-- 

DROP TABLE IF EXISTS `batch`;
CREATE TABLE IF NOT EXISTS `batch` (
  `batch_id` int(50) NOT NULL AUTO_INCREMENT,
  `batch_no` int(50) NOT NULL,
  `course_id` varchar(60) NOT NULL,
  `start_date` varchar(50) NOT NULL,
  `end_date` varchar(50) NOT NULL,
  PRIMARY KEY (`batch_id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table batch
-- 

/*!40000 ALTER TABLE `batch` DISABLE KEYS */;

/*!40000 ALTER TABLE `batch` ENABLE KEYS */;

-- 
-- Definition of course
-- 

DROP TABLE IF EXISTS `course`;
CREATE TABLE IF NOT EXISTS `course` (
  `course_id` int(11) NOT NULL AUTO_INCREMENT,
  `course_title` varchar(100) NOT NULL,
  `course_type` varchar(12) NOT NULL,
  `duration` int(11) NOT NULL,
  `total_fee` double NOT NULL,
  PRIMARY KEY (`course_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table course
-- 

/*!40000 ALTER TABLE `course` DISABLE KEYS */;

/*!40000 ALTER TABLE `course` ENABLE KEYS */;

-- 
-- Definition of results
-- 

DROP TABLE IF EXISTS `results`;
CREATE TABLE IF NOT EXISTS `results` (
  `result_id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` varchar(50) NOT NULL,
  `First_Name` varchar(60) NOT NULL,
  `course_id` varchar(50) NOT NULL,
  `subject_id` varchar(50) NOT NULL,
  `result` varchar(50) NOT NULL,
  `batch_id` varchar(50) NOT NULL,
  PRIMARY KEY (`result_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table results
-- 

/*!40000 ALTER TABLE `results` DISABLE KEYS */;

/*!40000 ALTER TABLE `results` ENABLE KEYS */;

-- 
-- Definition of student
-- 

DROP TABLE IF EXISTS `student`;
CREATE TABLE IF NOT EXISTS `student` (
  `student_id` varchar(60) NOT NULL,
  `first_name` text NOT NULL,
  `last_name` text NOT NULL,
  `date_of_birth` varchar(12) NOT NULL,
  `age` int(11) NOT NULL,
  `email` varchar(160) NOT NULL,
  `phone_number` int(11) NOT NULL,
  `gender` varchar(8) NOT NULL,
  `address` varchar(350) NOT NULL,
  `nic_card_no` varchar(16) NOT NULL,
  `course_id` varchar(60) NOT NULL,
  `batch_id` varchar(60) NOT NULL,
  PRIMARY KEY (`student_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table student
-- 

/*!40000 ALTER TABLE `student` DISABLE KEYS */;

/*!40000 ALTER TABLE `student` ENABLE KEYS */;

-- 
-- Definition of subject
-- 

DROP TABLE IF EXISTS `subject`;
CREATE TABLE IF NOT EXISTS `subject` (
  `subject_id` int(60) NOT NULL AUTO_INCREMENT,
  `course_id` varchar(60) NOT NULL,
  `subject_title` varchar(150) NOT NULL,
  `level` int(11) NOT NULL,
  `duration` int(50) NOT NULL,
  PRIMARY KEY (`subject_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table subject
-- 

/*!40000 ALTER TABLE `subject` DISABLE KEYS */;

/*!40000 ALTER TABLE `subject` ENABLE KEYS */;

-- 
-- Definition of user
-- 

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table user
-- 

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user`(`user_id`,`username`,`password`) VALUES
(1,'bcas','bcas123');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2018-09-10 00:14:55
-- Total time: 0:0:0:0:129 (d:h:m:s:ms)
