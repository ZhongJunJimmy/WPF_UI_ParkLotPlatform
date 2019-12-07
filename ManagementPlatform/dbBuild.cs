using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementPlatform
{
    class dbBuild
    {
        public static bool createDatabase()
        {
            try
            {
                using (StreamReader sr = new StreamReader("./sqlCommand/dbCreate.sql"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    dbProcess.ExecuteSQL(line);
                }

                //string createConfigDT = "CREATE TABLE parking_lot_platform_db.config " +
                //    "(`config_sno` int(11) NOT NULL," +
                //    "`config_para_name` char(10) COLLATE utf8_unicode_ci DEFAULT NULL," +
                //    "`config_para_data` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL) " +
                //    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci; ";

                //string createControlBoxDT = "CREATE TABLE parking_lot_platform_db.control_box_info " +
                //    "( `control_box_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL, " +
                //    "`control_box_info_ip` char(15) COLLATE utf8_unicode_ci NOT NULL, " +
                //    "`control_box_info_port` char(5) COLLATE utf8_unicode_ci NOT NULL, " +
                //    "`control_box_info_para` char(5) COLLATE utf8_unicode_ci DEFAULT NULL, " +
                //    "`control_box_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL) " +
                //    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci; ";

                //string createDisplyDT = "CREATE TABLE `display_info` (" +
                //    "`display_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`display_info_ip` char(15) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`display_info_port` char(5) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`display_info_para` char(10) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`display_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL) " +
                //    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci;";

                //string createGateDT = "CREATE TABLE `gate_info` (" +
                //    "`gate_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`control_box_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`gate_info_no` char(1) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`gate_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL)" +
                //    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci;";

                //string createGroupDT = "CREATE TABLE `group_info` (" +
                //    "`group_info_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`group_info_space_amount` int(11) NOT NULL," +
                //    "`group_info_space_remaning` int(11) NOT NULL," +
                //    "`group_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL) " +
                //    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci; ";

                //string createHistoryDT = "CREATE TABLE `history_info` (" +
                //    "`vehicle_info_uuid` char(17) COLLATE utf8_unicode_ci DEFAULT NULL," +
                //    "`history_info_current_time` datetime NOT NULL," +
                //    "`history_info_direct` tinyint(1) NOT NULL," +
                //    "`history_info_image_filename` varchar(50) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`history_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL) " +
                //    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci; ";

                //string createVehicleDT = "CREATE TABLE `vehicle_info` (" +
                //    "`vehicle_info_owner` varchar(10) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`vehicle_info_plate` char(8) COLLATE utf8_unicode_ci NOT NULL," +
                //    "`vehicle_info_phone` char(13) COLLATE utf8_unicode_ci DEFAULT NULL," +
                //    "`group_info_uuid` char(17) COLLATE utf8_unicode_ci DEFAULT NULL," +
                //    "`vehicle_info_other` varchar(15) COLLATE utf8_unicode_ci DEFAULT NULL," +
                //    "`vehicle_info_is_inside` tinyint(1) NOT NULL," +
                //    "`vehicle_info_is_deleted` tinyint(1) NOT NULL DEFAULT '1'," +
                //    "`vehicle_info_uuid` char(17) COLLATE utf8_unicode_ci NOT NULL) " +
                //    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci; ";

                //dbProcess.ExecuteSQL(createConfigDT);
                //dbProcess.ExecuteSQL(createControlBoxDT);
                //dbProcess.ExecuteSQL(createDisplyDT);
                //dbProcess.ExecuteSQL(createGateDT);
                //dbProcess.ExecuteSQL(createGroupDT);
                //dbProcess.ExecuteSQL(createHistoryDT);
                //dbProcess.ExecuteSQL(createVehicleDT);



                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
