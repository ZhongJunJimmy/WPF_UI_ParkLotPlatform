SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

CREATE TABLE `parking_lot_platform_db`.`config` (
  `config_sno` int(11) NOT NULL,
  `config_para_name` char(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `config_para_data` varchar(30) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `parking_lot_platform_db`.`control_box_info` (
  `control_box_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `control_box_info_ip` char(15) COLLATE utf8_unicode_ci NOT NULL,
  `control_box_info_port` char(5) COLLATE utf8_unicode_ci NOT NULL,
  `control_box_info_para` char(5) COLLATE utf8_unicode_ci DEFAULT NULL,
  `control_box_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `parking_lot_platform_db`.`display_info` (
  `display_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `display_info_ip` char(15) COLLATE utf8_unicode_ci NOT NULL,
  `display_info_port` char(5) COLLATE utf8_unicode_ci NOT NULL,
  `display_info_para` char(10) COLLATE utf8_unicode_ci NOT NULL,
  `display_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `parking_lot_platform_db`.`gate_info` (
  `gate_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `control_box_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL,
  `gate_info_no` char(1) COLLATE utf8_unicode_ci NOT NULL,
  `gate_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `parking_lot_platform_db`.`group_info` (
  `group_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `group_info_space_amount` int(11) NOT NULL,
  `group_info_space_remaning` int(11) NOT NULL,
  `group_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `parking_lot_platform_db`.`history_info` (
  `vehicle_info_uuid` char(17) COLLATE utf8_unicode_ci DEFAULT NULL,
  `history_info_current_time` datetime NOT NULL,
  `history_info_direct` tinyint(1) NOT NULL,
  `history_info_image_filename` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `history_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `parking_lot_platform_db`.`vehicle_info` (
  `vehicle_info_owner` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `vehicle_info_plate` char(8) COLLATE utf8_unicode_ci NOT NULL,
  `vehicle_info_phone` char(13) COLLATE utf8_unicode_ci DEFAULT NULL,
  `group_info_uuid` char(17) COLLATE utf8_unicode_ci DEFAULT NULL,
  `vehicle_info_other` varchar(15) COLLATE utf8_unicode_ci DEFAULT NULL,
  `vehicle_info_is_inside` tinyint(1) NOT NULL,
  `vehicle_info_is_deleted` tinyint(1) NOT NULL DEFAULT '1',
  `vehicle_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

DELIMITER $$
CREATE TRIGGER `insert_control_box_info_uuid` BEFORE INSERT ON `parking_lot_platform_db`.`control_box_info` FOR EACH ROW BEGIN
  IF New.control_box_info_uuid IS NULL THEN
    SET New.control_box_info_uuid := uuid_short();
  END IF;
END
$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `insert_display_info_uuid` BEFORE INSERT ON `parking_lot_platform_db`.`display_info` FOR EACH ROW BEGIN
  IF New.display_info_uuid IS NULL THEN
    SET New.display_info_uuid := uuid_short();
  END IF;
END
$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `insert_gate_info_uuid` BEFORE INSERT ON `parking_lot_platform_db`.`gate_info` FOR EACH ROW BEGIN
  IF New.gate_info_uuid IS NULL THEN
    SET New.gate_info_uuid := uuid_short();
  END IF;
END
$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `insert_group_info_uuid` BEFORE INSERT ON `parking_lot_platform_db`.`group_info` FOR EACH ROW BEGIN
  IF New.group_info_uuid IS NULL THEN
    SET New.group_info_uuid := uuid_short();
  END IF;
END
$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `insert_history_info_uuid` BEFORE INSERT ON `parking_lot_platform_db`.`history_info` FOR EACH ROW BEGIN
  IF New.history_info_uuid IS NULL THEN
    SET New.history_info_uuid := uuid_short();
  END IF;
END
$$
DELIMITER ;


DELIMITER $$
CREATE TRIGGER `insert_vehicle_info_uuid` BEFORE INSERT ON `parking_lot_platform_db`.`vehicle_info` FOR EACH ROW BEGIN
  IF New.vehicle_info_uuid IS NULL THEN
    SET New.vehicle_info_uuid := uuid_short();
  END IF;
END
$$
DELIMITER ;

ALTER TABLE `parking_lot_platform_db`.`config`
  ADD PRIMARY KEY (`config_sno`);

ALTER TABLE `parking_lot_platform_db`.`control_box_info`
  ADD PRIMARY KEY (`control_box_info_uuid`);

ALTER TABLE `parking_lot_platform_db`.`display_info`
  ADD PRIMARY KEY (`display_info_uuid`);

ALTER TABLE `parking_lot_platform_db`.`gate_info`
  ADD PRIMARY KEY (`gate_info_uuid`),
  ADD KEY `control_box_info_uuid` (`control_box_info_uuid`);

ALTER TABLE `parking_lot_platform_db`.`group_info`
  ADD PRIMARY KEY (`group_info_uuid`);

ALTER TABLE `parking_lot_platform_db`.`history_info`
  ADD PRIMARY KEY (`history_info_uuid`),
  ADD KEY `vehicle_info_uuid` (`vehicle_info_uuid`);

ALTER TABLE `parking_lot_platform_db`.`vehicle_info`
  ADD PRIMARY KEY (`vehicle_info_uuid`),
  ADD KEY `group_info_uuid` (`group_info_uuid`);

ALTER TABLE `parking_lot_platform_db`.`config`
  MODIFY `config_sno` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `parking_lot_platform_db`.`gate_info`
  ADD CONSTRAINT `gate_info_ibfk_1` FOREIGN KEY (`control_box_info_uuid`) REFERENCES `parking_lot_platform_db`.`control_box_info` (`control_box_info_uuid`) ON DELETE CASCADE;

ALTER TABLE `parking_lot_platform_db`.`history_info`
  ADD CONSTRAINT `history_info_ibfk_1` FOREIGN KEY (`vehicle_info_uuid`) REFERENCES `parking_lot_platform_db`.`vehicle_info` (`vehicle_info_uuid`) ON DELETE SET NULL;

ALTER TABLE `parking_lot_platform_db`.`vehicle_info`
  ADD CONSTRAINT `vehicle_info_ibfk_1` FOREIGN KEY (`group_info_uuid`) REFERENCES `parking_lot_platform_db`.`group_info` (`group_info_uuid`) ON DELETE SET NULL;