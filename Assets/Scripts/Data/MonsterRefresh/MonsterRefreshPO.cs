/**
*    Copyright (c) 2015 Need co.,Ltd
*    All rights reserved

*    文件名称:    MonsterRefreshPO.cs
*    创建标识:    
*    简    介:    怪物刷出脚本ID
*/
using System;
using System.Collections.Generic; 
using System.Text;
using LitJson; 
namespace Need.Mx
{

    public partial class MonsterRefreshPO 
    {
        protected int m_Id;
        protected int m_SceneId;
        protected int m_Index;
        protected int m_MonsterId;
        protected int m_RefreshArea;
        protected float m_AppeareTime;
        protected int m_MonsterNumber;
        protected int m_MonsterUse;
        protected float[] m_PathList;
        protected string m_MosterDesc;

        public MonsterRefreshPO(JsonData jsonNode)
        {
            m_Id = (int)jsonNode["Id"];
            m_SceneId = (int)jsonNode["SceneId"];
            m_Index = (int)jsonNode["Index"];
            m_MonsterId = (int)jsonNode["MonsterId"];
            m_RefreshArea = (int)jsonNode["RefreshArea"];
            m_AppeareTime = (float)(double)jsonNode["AppeareTime"];
            m_MonsterNumber = (int)jsonNode["MonsterNumber"];
            m_MonsterUse = (int)jsonNode["MonsterUse"];
            {
                JsonData array = jsonNode["PathList"];
                m_PathList = new float[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_PathList[index] = (float)(double)array[index];
                }
            }
            m_MosterDesc = jsonNode["MosterDesc"].ToString() == "NULL" ? "" : jsonNode["MosterDesc"].ToString();
        }

        public int Id
        {
            get
            {
                return m_Id;
            }
        }

        public int SceneId
        {
            get
            {
                return m_SceneId;
            }
        }

        public int Index
        {
            get
            {
                return m_Index;
            }
        }

        public int MonsterId
        {
            get
            {
                return m_MonsterId;
            }
        }

        public int RefreshArea
        {
            get
            {
                return m_RefreshArea;
            }
        }

        public float AppeareTime
        {
            get
            {
                return m_AppeareTime;
            }
        }

        public int MonsterNumber
        {
            get
            {
                return m_MonsterNumber;
            }
        }

        public int MonsterUse
        {
            get
            {
                return m_MonsterUse;
            }
        }

        public float[] PathList
        {
            get
            {
                return m_PathList;
            }
        }

        public string MosterDesc
        {
            get
            {
                return m_MosterDesc;
            }
        }

    }


}

