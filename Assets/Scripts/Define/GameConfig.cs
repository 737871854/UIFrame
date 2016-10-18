using System;
using UnityEngine;
using System.Collections.Generic;

namespace Need.Mx
{
    public class GameConfig
    {

        #region---------------------------配置文件路径常量------------------------------
        public const string DIFFICULTY_LEVEL_JSON = "Json/Level.json";
        public const string MONSTER_JSON = "Json/Monster.json";
        public const string MONSTER_REFRESH_JSON = "Json/MonsterRefresh.json";
        public const string SKILL_JSON = "Json/Skill.json";
        public const string SKILL_EFFECT_JSON = "Json/SkillEffect.json";
        #endregion

        #region---------------------------内部定义游戏常量------------------------------
        public static int   GAME_CONFIG_DIFFICULTY              = 1;
        public static int   GAME_CONFIG_PLAYER_COUNT            = 3;
        public static int   GAME_CONFIG_PLAYER_1                = 0;
        public static int   GAME_CONFIG_PLAYER_2                = 1;
        public static int   GAME_CONFIG_PLAYER_3                = 2;

        public static int   GAME_CONFIG_NAME_LEN                = 3;
        public static int   GAME_CONFIG_PER_CONSUME_WATER       = 1;
        public static int   GAME_CONFIG_MAX_SCORE               = 99999;
        public static int   GAME_CONFIG_MAX_CAR                 = 3;          // 消防车数量
        public static int   GAME_CONFIG_MAX_LIFE_TIME           = 9999;       // 游戏时间
        public static int   GAME_CONFIG_MAX_WAIT_TIME           = 10;         // 续币时间
        public static int   GAME_CONFIG_MAX_COIN                = 99;         // 最大币数
        public static int   GAME_CONFIG_PER_USE_COIN            = 3;          // 每次币数
        public static float GAME_CONFIG_SELECT_WAIT_TIME        = 10.0f;      // 等待时间
        public static float GAME_CONFIG_RANK_WAIT_TIME          = 30.0f;      // 等待时间
        public static int   GAME_CONFIG_WATER_DAMAGE_1          = 1;          // 玩家喷水攻击力，对怪物造成伤害
        public static int   GAME_CONFIG_WATER_DAMAGE_2          = 5;          // 玩家喷水攻击力，对怪物造成伤害
        public static float GAME_CONFIG_WATER_DAMAGE_INTERVAL   = 0.3f;       // 玩家攻击造成伤害的间隔（毫秒）
        public static float GAME_CONFIG_ADD_WATER_TIEM          = 3.0f;       // 水枪加水时间（毫秒）
        public static int   GAME_CONFIG_FULL_WATER              = 15;         // 水枪满水能够攻击的次数
        public static float GAME_CONFIG_SHOW_HEAD_UI_TIME_1     = 3.0f;       // 怪物X毫秒没受到攻击血条暂时消失
        public static float GAME_CONFIG_SHOW_HEAD_UI_TIME_2     = 3.0f;       // 友方怪物X毫秒没被喷水，救援进度条暂时消失
        public static float GAME_CONFIG_CLOSE_DOOR_TIME         = 0.5f;       // 门窗关闭时间（毫秒）
        public static float GAME_CONFIG_DAMAGE_LIFE_TIME        = 1.0f;       // 遭遇伤害时减少生命时间
        public static bool  GAME_CONFIG_JUDEG_CONDITION         = true;       // 是否进入条件判断(调试使用)
        public static int   GAME_CONFIG_MAX_RANK_ITEM           = 5;          // 排行榜个数
        #endregion 

        /// <summary>
        /// 初始化函数
        /// </summary>
        public static void ParsingGameConfig()
        {
            GAME_CONFIG_DIFFICULTY              = PlayerPrefs.GetInt("GAME_CONFIG_DIFFICULTY",              GAME_CONFIG_DIFFICULTY);
            GAME_CONFIG_PER_CONSUME_WATER       = PlayerPrefs.GetInt("GAME_CONFIG_PER_CONSUME_WATER",       GAME_CONFIG_PER_CONSUME_WATER);
            GAME_CONFIG_MAX_SCORE               = PlayerPrefs.GetInt("GAME_CONFIG_MAX_SCORE",               GAME_CONFIG_MAX_SCORE);
            GAME_CONFIG_MAX_CAR                 = PlayerPrefs.GetInt("GAME_CONFIG_MAX_CAR",                 GAME_CONFIG_MAX_CAR);
            GAME_CONFIG_MAX_LIFE_TIME           = PlayerPrefs.GetInt("GAME_CONFIG_MAX_LIFE_TIME",           GAME_CONFIG_MAX_LIFE_TIME);
            GAME_CONFIG_MAX_WAIT_TIME           = PlayerPrefs.GetInt("GAME_CONFIG_MAX_WAIT_TIME",           GAME_CONFIG_MAX_WAIT_TIME);
            GAME_CONFIG_MAX_COIN                = PlayerPrefs.GetInt("GAME_CONFIG_MAX_COIN",                GAME_CONFIG_MAX_COIN);
            GAME_CONFIG_PER_USE_COIN            = PlayerPrefs.GetInt("GAME_CONFIG_PER_USE_COIN",            GAME_CONFIG_PER_USE_COIN);
            GAME_CONFIG_SELECT_WAIT_TIME        = PlayerPrefs.GetFloat("GAME_CONFIG_SELECT_WAIT_TIME",      GAME_CONFIG_SELECT_WAIT_TIME);
            GAME_CONFIG_WATER_DAMAGE_1          = PlayerPrefs.GetInt("GAME_CONFIG_WATER_DAMAGE_1",          GAME_CONFIG_WATER_DAMAGE_1);
            GAME_CONFIG_WATER_DAMAGE_2          = PlayerPrefs.GetInt("GAME_CONFIG_WATER_DAMAGE_2",          GAME_CONFIG_WATER_DAMAGE_2);
            GAME_CONFIG_WATER_DAMAGE_INTERVAL   = PlayerPrefs.GetFloat("GAME_CONFIG_WATER_DAMAGE_INTERVAL", GAME_CONFIG_WATER_DAMAGE_INTERVAL);
            GAME_CONFIG_ADD_WATER_TIEM          = PlayerPrefs.GetFloat("GAME_CONFIG_ADD_WATER_TIEM",        GAME_CONFIG_ADD_WATER_TIEM);
            GAME_CONFIG_FULL_WATER              = PlayerPrefs.GetInt("GAME_CONFIG_FULL_WATER",              GAME_CONFIG_FULL_WATER);
            GAME_CONFIG_SHOW_HEAD_UI_TIME_1     = PlayerPrefs.GetFloat("GAME_CONFIG_SHOW_HEAD_UI_TIME_1",   GAME_CONFIG_SHOW_HEAD_UI_TIME_1);
            GAME_CONFIG_SHOW_HEAD_UI_TIME_2     = PlayerPrefs.GetFloat("GAME_CONFIG_SHOW_HEAD_UI_TIME_2",   GAME_CONFIG_SHOW_HEAD_UI_TIME_2);
            GAME_CONFIG_CLOSE_DOOR_TIME         = PlayerPrefs.GetFloat("GAME_CONFIG_CLOSE_DOOR_TIME",       GAME_CONFIG_CLOSE_DOOR_TIME);
            GAME_CONFIG_DAMAGE_LIFE_TIME        = PlayerPrefs.GetFloat("GAME_CONFIG_DAMAGE_LIFE_TIME",      GAME_CONFIG_DAMAGE_LIFE_TIME);
        }
    }
}