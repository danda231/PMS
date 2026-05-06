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

 Date: 06/05/2026 13:03:21
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for base_info
-- ----------------------------
DROP TABLE IF EXISTS `base_info`;
CREATE TABLE `base_info`  (
  `info_id` int NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `info_header` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '标题',
  `info_content` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '内容',
  `info_key` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '关键词',
  `info_type` int NOT NULL COMMENT '类型',
  `state` int NOT NULL COMMENT '状态',
  `modify_time` datetime NOT NULL COMMENT '修改时间',
  `publish_time` datetime NULL DEFAULT NULL COMMENT '发布时间',
  `user_id` int NOT NULL COMMENT '用户ID',
  `user_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户名',
  PRIMARY KEY (`info_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 164 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '基础信息表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of base_info
-- ----------------------------
INSERT INTO `base_info` VALUES (1, '测试公告', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (2, '测试通知', '测试通知测试通知测试通知', '测试,通知', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (3, 'Test', 'TestTestTestTest', 'Test', 3, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (4, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (5, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (6, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (7, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (8, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (9, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (10, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (11, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (12, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (13, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (14, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (15, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (16, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (17, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (18, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (19, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (20, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (21, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (22, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (23, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (24, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (25, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (26, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (27, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (28, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (29, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (30, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (31, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (32, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (33, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (34, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (35, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (36, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (37, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (38, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (39, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (40, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (41, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (42, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (43, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (44, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (45, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (46, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (47, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (48, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (49, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (50, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (51, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (52, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (53, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (54, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (55, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (56, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (57, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (58, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (59, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (60, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (61, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (62, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (63, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (64, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (65, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (66, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (67, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (68, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (69, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (70, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (71, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (72, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (73, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (74, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (75, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (76, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (77, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (78, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (79, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (80, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (81, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (82, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (83, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (84, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (85, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (86, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (87, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (88, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (89, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (90, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (91, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (92, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (93, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (94, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (95, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (96, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (97, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (98, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (99, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (100, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (101, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (102, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (103, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (104, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (105, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (106, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (107, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (108, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (109, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (110, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (111, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (112, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (113, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (114, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (115, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (116, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (117, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (118, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (119, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (120, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (121, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (122, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (123, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (124, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (125, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (126, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (127, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (128, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (129, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (130, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (131, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (132, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (133, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (134, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (135, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (136, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (137, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (138, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (139, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (140, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (141, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (142, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (143, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (144, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (145, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (146, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (147, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (148, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (149, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (150, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (151, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (152, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (153, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (154, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (155, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (156, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (157, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (158, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (159, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (160, '测试公告2024001', '测试公告测试公告测试公告', '测试,公告', 1, 0, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (161, '测试公告2024002', '测试公告测试公告测试公告', '测试,公告', 2, 1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `base_info` VALUES (162, '测试公告2024003', '测试公告测试公告测试公告', '测试,公告', 3, -1, '2024-04-22 20:00:00', '2024-04-22 20:00:00', 2024001, 'admin');

-- ----------------------------
-- Table structure for buildings
-- ----------------------------
DROP TABLE IF EXISTS `buildings`;
CREATE TABLE `buildings`  (
  `b_id` int NOT NULL,
  `b_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `q_id` int NOT NULL,
  `q_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`b_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of buildings
-- ----------------------------
INSERT INTO `buildings` VALUES (1, '一号楼', 1, '保利名都');
INSERT INTO `buildings` VALUES (2, '二号楼', 1, '保利名都');
INSERT INTO `buildings` VALUES (3, '三号楼', 1, '保利名都');
INSERT INTO `buildings` VALUES (4, '四号楼', 1, '保利名都');
INSERT INTO `buildings` VALUES (5, '五号楼', 1, '保利名都');
INSERT INTO `buildings` VALUES (6, '一号楼', 2, '十里景秀');
INSERT INTO `buildings` VALUES (7, '二号楼', 2, '十里景秀');
INSERT INTO `buildings` VALUES (8, '三号楼', 2, '十里景秀');
INSERT INTO `buildings` VALUES (9, '四号楼', 2, '十里景秀');
INSERT INTO `buildings` VALUES (10, '五号楼', 2, '十里景秀');

-- ----------------------------
-- Table structure for contracts
-- ----------------------------
DROP TABLE IF EXISTS `contracts`;
CREATE TABLE `contracts`  (
  `cid` int NOT NULL AUTO_INCREMENT,
  `c_name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `c_num` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `c_amount` decimal(10, 2) NOT NULL,
  `e_amount` decimal(10, 2) NULL DEFAULT NULL,
  `sign_time` datetime NOT NULL,
  `operator` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `opposite` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `state` int NOT NULL,
  `archived_time` datetime NULL DEFAULT NULL,
  `archived_user_id` int NULL DEFAULT NULL,
  `archived_user_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `modify_time` datetime NOT NULL,
  `user_id` int NOT NULL,
  `user_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`cid`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of contracts
-- ----------------------------
INSERT INTO `contracts` VALUES (1, '12313', '1', 110.00, 20.00, '2026-05-06 10:42:48', '1', '1', 1, NULL, 0, NULL, '2026-05-06 12:07:53', 2024001, 'admin');
INSERT INTO `contracts` VALUES (4, '123', '123', 0.00, 0.00, '2026-05-06 11:17:38', '123', '123', 0, NULL, 0, NULL, '2026-05-06 11:17:46', 2024001, 'admin');

-- ----------------------------
-- Table structure for fee_info
-- ----------------------------
DROP TABLE IF EXISTS `fee_info`;
CREATE TABLE `fee_info`  (
  `fee_id` int NOT NULL AUTO_INCREMENT,
  `fee_mode_id` int NOT NULL,
  `fee_mode` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `amount` decimal(6, 2) NOT NULL,
  `b_id` int NOT NULL,
  `b_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `q_id` int NOT NULL,
  `q_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `room_num` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `state` int NOT NULL,
  `valid_time` datetime NOT NULL,
  `modify_time` datetime NOT NULL,
  `user_id` int NOT NULL,
  `user_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`fee_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of fee_info
-- ----------------------------
INSERT INTO `fee_info` VALUES (1, 1, '物业管理费', 3496.23, 1, '一号楼', 1, '保利名都', '2601', '备注', 0, '2025-04-23 20:00:00', '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `fee_info` VALUES (2, 2, '车位管理费', 496.23, 1, '一号楼', 1, '保利名都', '2601', '备注', 1, '2025-04-23 20:00:00', '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `fee_info` VALUES (3, 2, '车位管理费', 496.23, 1, '一号楼', 1, '保利名都', '2601', '备注', -1, '2025-04-23 20:00:00', '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `fee_info` VALUES (4, 1, '物业管理费', 13.00, 1, '一号楼', 1, '保利名都', '111', '13123', -1, '2026-05-05 01:28:47', '2026-05-05 01:29:18', 2024001, 'admin');

-- ----------------------------
-- Table structure for fee_mode
-- ----------------------------
DROP TABLE IF EXISTS `fee_mode`;
CREATE TABLE `fee_mode`  (
  `f_id` int NOT NULL,
  `f_name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`f_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of fee_mode
-- ----------------------------
INSERT INTO `fee_mode` VALUES (1, '物业管理费');
INSERT INTO `fee_mode` VALUES (2, '车位管理费');

-- ----------------------------
-- Table structure for income_expenses
-- ----------------------------
DROP TABLE IF EXISTS `income_expenses`;
CREATE TABLE `income_expenses`  (
  `ie_id` int NOT NULL AUTO_INCREMENT,
  `happend_time` datetime NOT NULL,
  `record_type` int NOT NULL,
  `amount` decimal(18, 2) NOT NULL,
  `amount_type` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `amount_desc` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `project_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `account` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `department` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `operator` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `record_id` int NULL DEFAULT NULL,
  `record_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `record_time` datetime NULL DEFAULT NULL,
  `state` int NOT NULL,
  `modity_time` datetime NOT NULL,
  `user_id` int NOT NULL,
  `user_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`ie_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of income_expenses
-- ----------------------------
INSERT INTO `income_expenses` VALUES (1, '2026-05-06 00:30:45', 1, 11.00, '其他收入', '113', '1', '1', '1', '1', '1', 1, '1', '2026-05-06 00:30:59', 0, '2026-05-06 07:14:25', 2024001, 'admin');
INSERT INTO `income_expenses` VALUES (2, '2026-05-06 07:17:29', 2, 1313.00, '员工薪酬支出', '13123123', '123', '123', '312', '123', '123', 0, NULL, '1900-01-01 00:00:00', 0, '2026-05-06 07:22:15', 2024001, 'admin');

-- ----------------------------
-- Table structure for menus
-- ----------------------------
DROP TABLE IF EXISTS `menus`;
CREATE TABLE `menus`  (
  `menu_id` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `menu_header` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `target_view` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `parent_id` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `menu_icon` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `state` int NULL DEFAULT NULL,
  PRIMARY KEY (`menu_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of menus
-- ----------------------------
INSERT INTO `menus` VALUES ('-1', '工作台', NULL, '0', NULL, 1);
INSERT INTO `menus` VALUES ('1', '物业', NULL, '0', NULL, 1);
INSERT INTO `menus` VALUES ('1001', '小区管理', 'MView', '1', 'e624', 1);
INSERT INTO `menus` VALUES ('1002', '楼栋管理', 'MView', '1', 'e66d', 1);
INSERT INTO `menus` VALUES ('1003', '房屋管理', 'MView', '1', 'e604', 1);
INSERT INTO `menus` VALUES ('1004', '业主管理', 'OwnerView', '1', 'e6a9', 1);
INSERT INTO `menus` VALUES ('1005', '车位管理', 'MView', '1', 'e604', 1);
INSERT INTO `menus` VALUES ('1006', '车辆管理', 'MView', '1', 'e604', 1);
INSERT INTO `menus` VALUES ('2', '收费', NULL, '0', NULL, 1);
INSERT INTO `menus` VALUES ('2001', '代收费用', 'FeeView', '2', 'e66d', 1);
INSERT INTO `menus` VALUES ('2002', '押金收费', 'MView', '2', 'e8bd', 1);
INSERT INTO `menus` VALUES ('2003', '租金收入', 'MView', '2', 'e607', 1);
INSERT INTO `menus` VALUES ('3', '工单', NULL, '0', NULL, 1);
INSERT INTO `menus` VALUES ('3001', '报修管理', 'OrderView', '3', 'e659', 1);
INSERT INTO `menus` VALUES ('3002', '业主投诉', 'MView', '3', 'eaa0', 1);
INSERT INTO `menus` VALUES ('4', '财务', NULL, '0', NULL, 1);
INSERT INTO `menus` VALUES ('4001', '帐套管理', 'MView', '4', 'e624', 1);
INSERT INTO `menus` VALUES ('4002', '科目管理', 'MView', '4', 'e604', 1);
INSERT INTO `menus` VALUES ('4003', '收费标准', 'MView', '4', 'e606', 1);
INSERT INTO `menus` VALUES ('4004', '财务日结', 'MView', '4', 'e614', 1);
INSERT INTO `menus` VALUES ('4005', '收费明细', 'IEDetailView', '4', 'e608', 1);
INSERT INTO `menus` VALUES ('5', '文件', NULL, '0', NULL, 1);
INSERT INTO `menus` VALUES ('5001', '合同管理', 'ContractView', '5', 'e68f', 1);
INSERT INTO `menus` VALUES ('5002', '合同模板', 'MView', '5', 'e635', 1);
INSERT INTO `menus` VALUES ('6', '系统', NULL, '0', NULL, 1);
INSERT INTO `menus` VALUES ('6001', '菜单维护', 'MenuView', '6', 'e603', 1);
INSERT INTO `menus` VALUES ('6002', '系统用户', 'UserView', '6', 'e601', 1);
INSERT INTO `menus` VALUES ('6003', '角色权限', 'RoleView', '6', 'e60a', 1);
INSERT INTO `menus` VALUES ('6004', '更新上传', 'UploadView', '6', 'e648', 1);
INSERT INTO `menus` VALUES ('6005', '菜单维护', 'MView', '6', 'e6a9', 1);
INSERT INTO `menus` VALUES ('6006', '公告与通知', 'BaseInfoView', '6', 'e618', 1);

-- ----------------------------
-- Table structure for owner_info
-- ----------------------------
DROP TABLE IF EXISTS `owner_info`;
CREATE TABLE `owner_info`  (
  `owner_id` int NOT NULL AUTO_INCREMENT,
  `householder` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `id_number` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `phone` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `b_id` int NOT NULL,
  `b_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `q_id` int NOT NULL,
  `q_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `room_num` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `gender` int NOT NULL,
  `credentials_img_1` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `credentials_img_2` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `state` int NOT NULL,
  `modify_time` datetime NOT NULL,
  `user_id` int NOT NULL,
  `user_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`owner_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 10 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of owner_info
-- ----------------------------
INSERT INTO `owner_info` VALUES (1, '张三', '210811196005132133', '19012345678', 1, '一号楼', 1, '保利名都', '2601', 1, '', '', '', 1, '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `owner_info` VALUES (2, '李四', '210811196005132133', '19012345678', 1, '一号楼', 1, '保利名都', '2601', 1, '', '', '', 1, '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `owner_info` VALUES (3, '王五', '210811196005132133', '19012345678', 2, '二号楼', 1, '保利名都', '2701', 0, '', '', '', 0, '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `owner_info` VALUES (4, '赵六', '210811196005132133', '19012345678', 3, '三号楼', 1, '保利名都', '2601', 0, '', '', '', 1, '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `owner_info` VALUES (5, '路人甲', '210811196005132133', '19012345678', 6, '一号楼', 2, '十里景秀', '一单元1102', 0, '', '', '', 1, '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `owner_info` VALUES (6, '路人乙', '210811196005132133', '19012345678', 6, '一号楼', 2, '十里景秀', '一单元1102', 0, '', '', '', 1, '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `owner_info` VALUES (7, '路人丁', '210811196005132133', '19012345678', 6, '一号楼', 2, '十里景秀', '一单元1102', 0, '', '', '', 1, '2024-04-23 20:00:00', 2024001, 'admin');
INSERT INTO `owner_info` VALUES (8, '路人丙', '210811196005132133', '19012345678', 8, '三号楼', 2, '十里景秀', '二单元901', 0, '', '', '', 0, '2024-04-23 20:00:00', 2024001, 'admin');

-- ----------------------------
-- Table structure for quarters
-- ----------------------------
DROP TABLE IF EXISTS `quarters`;
CREATE TABLE `quarters`  (
  `q_id` int NOT NULL,
  `q_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`q_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of quarters
-- ----------------------------
INSERT INTO `quarters` VALUES (1, '保利名都');
INSERT INTO `quarters` VALUES (2, '十里景秀');

-- ----------------------------
-- Table structure for role_menu
-- ----------------------------
DROP TABLE IF EXISTS `role_menu`;
CREATE TABLE `role_menu`  (
  `role_id` int NOT NULL,
  `menu_id` int NOT NULL,
  PRIMARY KEY (`role_id`, `menu_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of role_menu
-- ----------------------------
INSERT INTO `role_menu` VALUES (1, 0);
INSERT INTO `role_menu` VALUES (1, 1);
INSERT INTO `role_menu` VALUES (1, 2);
INSERT INTO `role_menu` VALUES (1, 3);
INSERT INTO `role_menu` VALUES (1, 4);
INSERT INTO `role_menu` VALUES (1, 5);
INSERT INTO `role_menu` VALUES (1, 6);
INSERT INTO `role_menu` VALUES (1, 1001);
INSERT INTO `role_menu` VALUES (1, 1002);
INSERT INTO `role_menu` VALUES (1, 1003);
INSERT INTO `role_menu` VALUES (1, 1004);
INSERT INTO `role_menu` VALUES (1, 1005);
INSERT INTO `role_menu` VALUES (1, 1006);
INSERT INTO `role_menu` VALUES (1, 2001);
INSERT INTO `role_menu` VALUES (1, 2002);
INSERT INTO `role_menu` VALUES (1, 2003);
INSERT INTO `role_menu` VALUES (1, 3001);
INSERT INTO `role_menu` VALUES (1, 3002);
INSERT INTO `role_menu` VALUES (1, 4001);
INSERT INTO `role_menu` VALUES (1, 4002);
INSERT INTO `role_menu` VALUES (1, 4003);
INSERT INTO `role_menu` VALUES (1, 4004);
INSERT INTO `role_menu` VALUES (1, 4005);
INSERT INTO `role_menu` VALUES (1, 5001);
INSERT INTO `role_menu` VALUES (1, 5002);
INSERT INTO `role_menu` VALUES (1, 6001);
INSERT INTO `role_menu` VALUES (1, 6002);
INSERT INTO `role_menu` VALUES (1, 6003);
INSERT INTO `role_menu` VALUES (1, 6004);
INSERT INTO `role_menu` VALUES (1, 6005);
INSERT INTO `role_menu` VALUES (1, 6006);
INSERT INTO `role_menu` VALUES (2, 0);
INSERT INTO `role_menu` VALUES (2, 1);
INSERT INTO `role_menu` VALUES (2, 6);
INSERT INTO `role_menu` VALUES (2, 1001);
INSERT INTO `role_menu` VALUES (2, 6001);
INSERT INTO `role_menu` VALUES (2, 6002);
INSERT INTO `role_menu` VALUES (2, 6003);

-- ----------------------------
-- Table structure for role_user
-- ----------------------------
DROP TABLE IF EXISTS `role_user`;
CREATE TABLE `role_user`  (
  `user_id` int NOT NULL,
  `role_id` int NOT NULL,
  PRIMARY KEY (`role_id`, `user_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of role_user
-- ----------------------------
INSERT INTO `role_user` VALUES (2024001, 1);
INSERT INTO `role_user` VALUES (2024002, 1);
INSERT INTO `role_user` VALUES (2024003, 1);
INSERT INTO `role_user` VALUES (2024004, 1);
INSERT INTO `role_user` VALUES (2024001, 2);
INSERT INTO `role_user` VALUES (2024002, 2);
INSERT INTO `role_user` VALUES (2024001, 3);
INSERT INTO `role_user` VALUES (2024003, 3);

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
INSERT INTO `sysemployee` VALUES (2024001, 'admin', 'Administrator', '123456', 1, 30, 'a01.jpg', NULL, NULL, 'AAAAAA2', NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, 0);
INSERT INTO `sysemployee` VALUES (2024002, 'jovan', 'Jovan Cheng', '123456', 1, 30, 'a02.jpg', NULL, NULL, '湖北省武汉市汉阳区人信大厦', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sysemployee` VALUES (2024003, 'gabby', 'Gabby', '123456', 1, 30, 'a03.jpg', NULL, NULL, 'AAAAAA2', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sysemployee` VALUES (2024004, 'test', 'Test', '123456', 1, 30, 'a04.jpg', NULL, NULL, 'AAAAAA2', NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, 0);

-- ----------------------------
-- Table structure for sysrole
-- ----------------------------
DROP TABLE IF EXISTS `sysrole`;
CREATE TABLE `sysrole`  (
  `role_id` int NOT NULL AUTO_INCREMENT,
  `role_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `role_desc` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `state` int NOT NULL,
  PRIMARY KEY (`role_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysrole
-- ----------------------------
INSERT INTO `sysrole` VALUES (1, '测试权限组', '测试权限组测试权限组测试权限组测试权限组测试权限组', 1);
INSERT INTO `sysrole` VALUES (2, 'AAAA', 'AAAAA', 1);
INSERT INTO `sysrole` VALUES (3, 'BBBBB', 'BBBBB', 1);
INSERT INTO `sysrole` VALUES (4, '12333', '123', 1);

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
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci COMMENT = '升级文件表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of upgrade_files
-- ----------------------------
INSERT INTO `upgrade_files` VALUES (10, 'wj.png', 'd5e389684b7d350786ac1b8dd88c2a98', '.\\Modules', '2026-05-02 01:20:53', 0, 376448);
INSERT INTO `upgrade_files` VALUES (11, 'xjd.jpg', 'f79e845b5a6d5d32d63a34ff74457cc9', '.\\', '2026-05-02 01:20:53', 0, 74252);

-- ----------------------------
-- Table structure for work_order
-- ----------------------------
DROP TABLE IF EXISTS `work_order`;
CREATE TABLE `work_order`  (
  `order_id` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `order_type` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `service_type` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `address` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `contacts` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `finish_time` datetime NOT NULL,
  `state` int NOT NULL,
  `is_urgent` int NOT NULL,
  `modify_time` datetime NOT NULL,
  `user_id` int NOT NULL,
  `user_name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`order_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of work_order
-- ----------------------------
INSERT INTO `work_order` VALUES ('20240506200000345', '维修更换', '上门服务', '业主房间渗水', '业主房间渗水业主房间渗水业主房间渗水业主房间渗水', '小区二号楼一单元702室', '张三', '13123456789', '2024-04-22 20:00:00', 0, 0, '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `work_order` VALUES ('20240506200000346', '维修更换', '上门服务', '业主房间渗水', '业主房间渗水业主房间渗水业主房间渗水业主房间渗水', '小区二号楼一单元702室', '张三', '13123456789', '2024-04-22 20:00:00', 1, 1, '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `work_order` VALUES ('20240506200000347', '维修更换', '上门服务', '业主房间渗水', '业主房间渗水业主房间渗水业主房间渗水业主房间渗水', '小区二号楼一单元702室', '张三', '13123456789', '2024-04-22 20:00:00', 2, 0, '2024-04-22 20:00:00', 2024001, 'admin');
INSERT INTO `work_order` VALUES ('20240506200000349', '维修更换', '上门服务', '业主房间渗水', '业主房间渗水业主房间渗水业主房间渗水业主房间渗水', '小区二号楼一单元702室', '张三', '13123456789', '2024-04-22 20:00:00', 0, 1, '2024-04-22 20:00:00', 2024001, 'admin');

-- ----------------------------
-- Table structure for work_order_images
-- ----------------------------
DROP TABLE IF EXISTS `work_order_images`;
CREATE TABLE `work_order_images`  (
  `order_id` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `img_id` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `img_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`img_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of work_order_images
-- ----------------------------
INSERT INTO `work_order_images` VALUES ('20240506200000345', '20240506200000345-001', '20240506200000345-001.png');
INSERT INTO `work_order_images` VALUES ('20240506200000345', '20240506200000345-002', '20240506200000345-002.jpg');
INSERT INTO `work_order_images` VALUES ('20240506200000345', '20240506200000345-003', '20240506200000345-003.jpg');
INSERT INTO `work_order_images` VALUES ('20240506200000346', '20240506200000346-001', '20240506200000346-001.png');
INSERT INTO `work_order_images` VALUES ('20240506200000346', '20240506200000346-002', '20240506200000346-002.jpg');
INSERT INTO `work_order_images` VALUES ('20240506200000346', '20240506200000346-003', '20240506200000346-003.jpg');
INSERT INTO `work_order_images` VALUES ('20240506200000347', '20240506200000347-001', '20240506200000347-001.png');
INSERT INTO `work_order_images` VALUES ('20240506200000347', '20240506200000347-002', '20240506200000347-002.jpg');
INSERT INTO `work_order_images` VALUES ('20240506200000347', '20240506200000347-003', '20240506200000347-003.jpg');

SET FOREIGN_KEY_CHECKS = 1;
