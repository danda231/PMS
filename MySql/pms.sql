/*
 Navicat Premium Data Transfer

 Source Server         : xjd
 Source Server Type    : MySQL
 Source Server Version : 80033
 Source Host           : localhost:3306
 Source Schema         : pms

 Target Server Type    : MySQL
 Target Server Version : 80033
 File Encoding         : 65001

 Date: 26/04/2026 10:40:35
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sysemployee
-- ----------------------------
DROP TABLE IF EXISTS `sysemployee`;
CREATE TABLE `sysemployee`  (
  `EId` int NOT NULL,
  `UserName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `RealName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Status` int NULL DEFAULT NULL,
  `Age` int NULL DEFAULT NULL,
  `EIcon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Mobile` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Address` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `QQ` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `WeChat` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Gender` int NULL DEFAULT NULL,
  `LastLoginTime` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `CreateTime` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `CreateId` int NULL DEFAULT NULL,
  `LastModifyTime` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `LastModifyId` int NULL DEFAULT NULL,
  PRIMARY KEY (`EId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysemployee
-- ----------------------------
INSERT INTO `sysemployee` VALUES (2024001, 'admin', 'Administrator', '123456', 1, 30, 'a01.jpg', NULL, NULL, 'AAAAAA2', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sysemployee` VALUES (2024002, 'jovan', 'Jovan Cheng', '123456', 1, 30, 'a02.jpg', NULL, NULL, '湖北省武汉市汉阳区人信大厦', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sysemployee` VALUES (2024003, 'gabby', 'Gabby', '123456', 1, 30, 'a03.jpg', NULL, NULL, 'AAAAAA2', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sysemployee` VALUES (2024004, 'test', 'Test', '123456', 1, 30, 'a04.jpg', NULL, NULL, 'AAAAAA2', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for upgrade_files
-- ----------------------------
DROP TABLE IF EXISTS `upgrade_files`;
CREATE TABLE `upgrade_files`  (
  `file_id` int NOT NULL AUTO_INCREMENT COMMENT '文件ID',
  `file_name` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL COMMENT '文件名',
  `file_md5` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL COMMENT '文件MD5',
  `file_path` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL COMMENT '文件路径',
  `upload_time` datetime NULL DEFAULT NULL COMMENT '上传时间',
  `state` int NOT NULL DEFAULT 0 COMMENT '状态',
  `length` int NULL DEFAULT NULL COMMENT '文件大小',
  PRIMARY KEY (`file_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci COMMENT = '升级文件表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of upgrade_files
-- ----------------------------
INSERT INTO `upgrade_files` VALUES (1, 'PMS.Client.Bll.dll', 'C918A3D4-F0A9-4B44-B3F0-21A3A1014255', 'Modules', '2026-04-24 19:42:59', 0, 100);
INSERT INTO `upgrade_files` VALUES (2, 'PMS.Client.IBll.dll', '{03B1E293-480A-469B-9DD7-052460357B9A}', '', NULL, 0, 123);
INSERT INTO `upgrade_files` VALUES (3, 'PMS.Client.IDAL.dll', '{A1B4A239-97A2-4DA6-84A1-46B71BA2A15D}', '', NULL, 0, 111);

SET FOREIGN_KEY_CHECKS = 1;
