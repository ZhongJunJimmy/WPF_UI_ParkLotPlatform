-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Dec 06, 2019 at 09:52 AM
-- Server version: 5.7.17-log
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `parking_lot_platform_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `config`
--

CREATE TABLE `config` (
  `config_sno` int(11) NOT NULL,
  `config_para_name` char(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `config_para_data` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `control_box_info`
--

CREATE TABLE `control_box_info` (
  `control_box_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `control_box_info_ip` char(15) COLLATE utf8_unicode_ci NOT NULL,
  `control_box_info_port` char(5) COLLATE utf8_unicode_ci NOT NULL,
  `control_box_info_para` char(5) COLLATE utf8_unicode_ci DEFAULT NULL,
  `control_box_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `display_info`
--

CREATE TABLE `display_info` (
  `display_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `display_info_ip` char(15) COLLATE utf8_unicode_ci NOT NULL,
  `display_info_port` char(5) COLLATE utf8_unicode_ci NOT NULL,
  `display_info_para` char(10) COLLATE utf8_unicode_ci NOT NULL,
  `display_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `gate_info`
--

CREATE TABLE `gate_info` (
  `gate_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `control_box_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL,
  `gate_info_no` char(1) COLLATE utf8_unicode_ci NOT NULL,
  `gate_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `group_info`
--

CREATE TABLE `group_info` (
  `group_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `group_info_space_amount` int(11) NOT NULL,
  `group_info_space_remaning` int(11) NOT NULL,
  `group_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `history_info`
--

CREATE TABLE `history_info` (
  `vehicle_info_uuid` char(17) COLLATE utf8_unicode_ci DEFAULT NULL,
  `history_info_current_time` datetime NOT NULL,
  `history_info_direct` tinyint(1) NOT NULL,
  `history_info_image_filename` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `history_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Triggers `history_info`
--
DELIMITER $$
CREATE TRIGGER `insert_history_info_uuid` BEFORE INSERT ON `history_info` FOR EACH ROW BEGIN
  IF New.history_info_uuid IS NULL THEN
    SET New.history_info_uuid := uuid_short();
  END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `vehicle_info`
--

CREATE TABLE `vehicle_info` (
  `vehicle_info_owner` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `vehicle_info_plate` char(8) COLLATE utf8_unicode_ci NOT NULL,
  `vehicle_info_phone` char(13) COLLATE utf8_unicode_ci DEFAULT NULL,
  `group_info_uuid` char(17) COLLATE utf8_unicode_ci DEFAULT NULL,
  `vehicle_info_other` varchar(15) COLLATE utf8_unicode_ci DEFAULT NULL,
  `vehicle_info_is_inside` tinyint(1) NOT NULL,
  `vehicle_info_is_deleted` tinyint(1) NOT NULL DEFAULT '1',
  `vehicle_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Triggers `vehicle_info`
--
DELIMITER $$
CREATE TRIGGER `insert_vehicle_info_uuid` BEFORE INSERT ON `vehicle_info` FOR EACH ROW BEGIN
  IF New.vehicle_info_uuid IS NULL THEN
    SET New.vehicle_info_uuid := uuid_short();
  END IF;
END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `config`
--
ALTER TABLE `config`
  ADD PRIMARY KEY (`config_sno`);

--
-- Indexes for table `control_box_info`
--
ALTER TABLE `control_box_info`
  ADD PRIMARY KEY (`control_box_info_uuid`);

--
-- Indexes for table `display_info`
--
ALTER TABLE `display_info`
  ADD PRIMARY KEY (`display_info_uuid`);

--
-- Indexes for table `gate_info`
--
ALTER TABLE `gate_info`
  ADD PRIMARY KEY (`gate_info_uuid`),
  ADD KEY `control_box_info_uuid` (`control_box_info_uuid`);

--
-- Indexes for table `group_info`
--
ALTER TABLE `group_info`
  ADD PRIMARY KEY (`group_info_uuid`);

--
-- Indexes for table `history_info`
--
ALTER TABLE `history_info`
  ADD PRIMARY KEY (`history_info_uuid`),
  ADD KEY `vehicle_info_uuid` (`vehicle_info_uuid`);

--
-- Indexes for table `vehicle_info`
--
ALTER TABLE `vehicle_info`
  ADD PRIMARY KEY (`vehicle_info_uuid`),
  ADD KEY `group_info_uuid` (`group_info_uuid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `config`
--
ALTER TABLE `config`
  MODIFY `config_sno` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `gate_info`
--
ALTER TABLE `gate_info`
  ADD CONSTRAINT `gate_info_ibfk_1` FOREIGN KEY (`control_box_info_uuid`) REFERENCES `control_box_info` (`control_box_info_uuid`) ON DELETE CASCADE;

--
-- Constraints for table `history_info`
--
ALTER TABLE `history_info`
  ADD CONSTRAINT `history_info_ibfk_1` FOREIGN KEY (`vehicle_info_uuid`) REFERENCES `vehicle_info` (`vehicle_info_uuid`) ON DELETE SET NULL;

--
-- Constraints for table `vehicle_info`
--
ALTER TABLE `vehicle_info`
  ADD CONSTRAINT `vehicle_info_ibfk_1` FOREIGN KEY (`group_info_uuid`) REFERENCES `group_info` (`group_info_uuid`) ON DELETE SET NULL;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
