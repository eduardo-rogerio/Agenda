CREATE DATABASE  IF NOT EXISTS `dbcapacitacao` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `dbcapacitacao`;
-- MariaDB dump 10.17  Distrib 10.4.10-MariaDB, for Win64 (AMD64)
--
-- Host: 127.0.0.1    Database: dbcapacitacao
-- ------------------------------------------------------
-- Server version	10.4.10-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblagenda`
--

DROP TABLE IF EXISTS `tblagenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblagenda` (
  `agdid` int(11) NOT NULL,
  `agdnome` varchar(50) DEFAULT NULL,
  `agdemail` varchar(200) DEFAULT NULL,
  `agdtelefone` varchar(15) DEFAULT NULL,
  `agdcpf` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`agdid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblagenda`
--

LOCK TABLES `tblagenda` WRITE;
/*!40000 ALTER TABLE `tblagenda` DISABLE KEYS */;
INSERT INTO `tblagenda` VALUES (10,'Maycon','maycon@email.com','17953453241','78578567802'),(2,'eduardo','eduardo@email.com','17992541053','05201609597'),(4,'José Carlos','jose@email.com','17997541159','41467275568'),(6,'Maria Clara','maria@email.com','17998531159','01600529597'),(8,'Sergio','sergio@email.com','17996234673','20160950597'),(9,'Daniel','daniel@email.com','17992235478','09597052016'),(12,'Marcos','marcos@email.com','17986524195','52016009597'),(14,'Everton','everton@email.com','17985416295','02685201478'),(3,'Ana','ana@email.com','17993456343','45324545235'),(5,'Fernando','fernado@email.com','1796345463','23536345407');
/*!40000 ALTER TABLE `tblagenda` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-30 10:56:50
