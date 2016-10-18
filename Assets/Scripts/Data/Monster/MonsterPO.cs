/**
*    Copyright (c) 2015 Need co.,Ltd
*    All rights reserved

*    文件名称:    MonsterPO.cs
*    创建标识:    (0:不旋转，1：旋转)
*    简    介:    怪物ID（=怪物编号+场景ID*1000+怪物类型*10000）插入怪物时请根据格式在每一个场景ID的最后添加怪物
*/
using System;
using System.Collections.Generic; 
using System.Text;
using LitJson; 
namespace Need.Mx
{

    public partial class MonsterPO 
    {
        protected int m_Id;
        protected int m_Index;
        protected string m_ShapeName;
        protected string m_Desc;
        protected int m_MonsterType;
        protected float m_Speed;
        protected float m_Radius;
        protected int m_StandAction;
        protected int m_MonsterValue;
        protected string[] m_BirthSound;
        protected string[] m_DieSound;
        protected string[] m_Effect;
        protected string[] m_HitEffect;
        protected string[] m_IdleEffect;
        protected string[] m_StruggleEffect;
        protected string[] m_DieEffet;
        protected float m_ScaleSize;
        protected int m_IsRotate;

        public MonsterPO(JsonData jsonNode)
        {
            m_Id = (int)jsonNode["Id"];
            m_Index = (int)jsonNode["Index"];
            m_ShapeName = jsonNode["ShapeName"].ToString() == "NULL" ? "" : jsonNode["ShapeName"].ToString();
            m_Desc = jsonNode["Desc"].ToString() == "NULL" ? "" : jsonNode["Desc"].ToString();
            m_MonsterType = (int)jsonNode["MonsterType"];
            m_Speed = (float)(double)jsonNode["Speed"];
            m_Radius = (float)(double)jsonNode["Radius"];
            m_StandAction = (int)jsonNode["StandAction"];
            m_MonsterValue = (int)jsonNode["MonsterValue"];
            {
                JsonData array = jsonNode["BirthSound"];
                m_BirthSound = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_BirthSound[index] = array[index].ToString();
                }
            }
            {
                JsonData array = jsonNode["DieSound"];
                m_DieSound = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_DieSound[index] = array[index].ToString();
                }
            }
            {
                JsonData array = jsonNode["Effect"];
                m_Effect = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_Effect[index] = array[index].ToString();
                }
            }
            {
                JsonData array = jsonNode["HitEffect"];
                m_HitEffect = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_HitEffect[index] = array[index].ToString();
                }
            }
            {
                JsonData array = jsonNode["IdleEffect"];
                m_IdleEffect = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_IdleEffect[index] = array[index].ToString();
                }
            }
            {
                JsonData array = jsonNode["StruggleEffect"];
                m_StruggleEffect = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_StruggleEffect[index] = array[index].ToString();
                }
            }
            {
                JsonData array = jsonNode["DieEffet"];
                m_DieEffet = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_DieEffet[index] = array[index].ToString();
                }
            }
            m_ScaleSize = (float)(double)jsonNode["ScaleSize"];
            m_IsRotate = (int)jsonNode["IsRotate"];
        }

        public int Id
        {
            get
            {
                return m_Id;
            }
        }

        public int Index
        {
            get
            {
                return m_Index;
            }
        }

        public string ShapeName
        {
            get
            {
                return m_ShapeName;
            }
        }

        public string Desc
        {
            get
            {
                return m_Desc;
            }
        }

        public int MonsterType
        {
            get
            {
                return m_MonsterType;
            }
        }

        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }

        public float Radius
        {
            get
            {
                return m_Radius;
            }
        }

        public int StandAction
        {
            get
            {
                return m_StandAction;
            }
        }

        public int MonsterValue
        {
            get
            {
                return m_MonsterValue;
            }
        }

        public string[] BirthSound
        {
            get
            {
                return m_BirthSound;
            }
        }

        public string[] DieSound
        {
            get
            {
                return m_DieSound;
            }
        }

        public string[] Effect
        {
            get
            {
                return m_Effect;
            }
        }

        public string[] HitEffect
        {
            get
            {
                return m_HitEffect;
            }
        }

        public string[] IdleEffect
        {
            get
            {
                return m_IdleEffect;
            }
        }

        public string[] StruggleEffect
        {
            get
            {
                return m_StruggleEffect;
            }
        }

        public string[] DieEffet
        {
            get
            {
                return m_DieEffet;
            }
        }

        public float ScaleSize
        {
            get
            {
                return m_ScaleSize;
            }
        }

        public int IsRotate
        {
            get
            {
                return m_IsRotate;
            }
        }

    }


}

