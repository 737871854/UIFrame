//
// /**************************************************************************
//
// Defines.cs
//
// Author: XiaoHong  <704872627@qq.com>
//
// Unity课程讨论群:  152767675
//
// Date: 15-8-6
//
// Description:Provide  functions  to connect Oracle
//
// Copyright (c) 2015 XiaoHong
//
// **************************************************************************/


using System;
using UnityEngine;
using System.Collections;

namespace Need.Mx
{

	#region Global delegate 委托
	public delegate void StateChangedEvent (object sender,EnumObjectState newState,EnumObjectState oldState);
	
	public delegate void MessageEvent(Message message);

	public delegate void OnTouchEventHandle(GameObject _listener, object _args, params object[] _params);

	public delegate void PropertyChangedHandle(BaseActor actor, int id, object oldValue, object newValue);

    public delegate void LoadingCompletedHandle(object sender, EventArgs e);
	#endregion

	#region Global enum 枚举
	/// <summary>
	/// 对象当前状态 
	/// </summary>
	public enum EnumObjectState
	{
		/// <summary>
		/// The none.
		/// </summary>
		None,
		/// <summary>
		/// The initial.
		/// </summary>
		Initial,
		/// <summary>
		/// The loading.
		/// </summary>
		Loading,
		/// <summary>
		/// The ready.
		/// </summary>
		Ready,
		/// <summary>
		/// The disabled.
		/// </summary>
		Disabled,
		/// <summary>
		/// The closing.
		/// </summary>
		Closing
	}

	/// <summary>
	/// Enum user interface type.
	/// UI面板类型
	/// </summary>
	public enum EnumUIType : int
	{
		/// <summary>
		/// The none.
		/// </summary>
		None = -1,
        /// <summary>
        /// UI Root
        /// </summary>
        UIRoot,
		/// <summary>
		/// The test one.
		/// </summary>
		TestOne,
		/// <summary>
		/// The test two.
		/// </summary>
		TestTwo,
        /// <summary>
        /// 开始界面
        /// </summary>
        PanelStart,
        /// <summary>
        /// 进度条界面
        /// </summary>
        PanelLoading,
     
	}

    public enum EnumSpriteType : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = -1,
        /// <summary>
        /// 通用数字
        /// </summary>
        SpriteNumber,
    }

    public enum EnumModel :int
    {
        /// <summary>
        /// 
        /// </summary>
        None = -1,
        /// <summary>
        /// 
        /// </summary>
        Player0,
        /// <summary>
        /// 
        /// </summary>
        Player1,
        /// <summary>
        /// 
        /// </summary>
        Player2,
    }

	public enum EnumTouchEventType
	{
		OnClick,
		OnDoubleClick,
		OnDown,
		OnUp,
		OnEnter,
		OnExit,
		OnSelect,  
		OnUpdateSelect,  
		OnDeSelect, 
		OnDrag, 
		OnDragEnd,
		OnDrop,
		OnScroll, 
		OnMove,
	}

	public enum EnumPropertyType : int
	{
		RoleName = 1, // 角色名
		Sex,     // 性别
		RoleID,  // Role ID
		Gold,    // 宝石(元宝)
		Coin,    // 金币(铜板)
		Level,   // 等级
		Exp,     // 当前经验

		AttackSpeed,//攻击速度
		HP,     //当前HP
		HPMax,  //生命最大值
		Attack, //普通攻击（点数）
		Water,  //水系攻击（点数）
		Fire,   //火系攻击（点数）
	}

	public enum EnumActorType
	{
		None = 0,
		Role,
		Monster,
		NPC,
	}

    /// <summary>
    /// 场景枚举
    /// </summary>
    public enum EnumSceneType
    {
        None = 0,
        StartGame,
        LoadingScene,
        LoginScene,
        MainScene,
        CopyScene,
        BattleScene,
    }
	
	#endregion

	#region Defines static class & cosnt

	/// <summary>
	/// 路径定义。
	/// </summary>
	public static class UIPathDefines
	{
		/// <summary>
		/// UI预设。
		/// </summary>
        public const string UI_PREFAB = "Prefabs/UI/";
      
		/// <summary>
		/// Gets the type of the prefab path by.
		/// </summary>
		/// <returns>The prefab path by type.</returns>
		/// <param name="_uiType">_ui type.</param>
		public static string GetPrefabPathByType(EnumUIType _uiType)
		{
			string _path = string.Empty;
			switch (_uiType)
			{
                case EnumUIType.UIRoot:
                    _path = UI_PREFAB + "UIRoot";
                    break;
                // UI
			    case EnumUIType.TestOne:
				    _path = UI_PREFAB + "TestUIOne";
				    break;
			    case EnumUIType.TestTwo:
				    _path = UI_PREFAB + "TestUITwo";
				    break;
                case EnumUIType.PanelStart:
                    _path = UI_PREFAB + "PanelStart";
                    break;
                case EnumUIType.PanelLoading:
                    _path = UI_PREFAB + "PanelLoading";
                    break;
			    default:
				    Debug.Log("Not Find EnumUIType! type: " + _uiType.ToString());
				    break;
			 }
			return _path;
		}

		/// <summary>
		/// Gets the type of the user interface script by.
		/// </summary>
		/// <returns>The user interface script by type.</returns>
		/// <param name="_uiType">_ui type.</param>
		public static System.Type GetUIScriptByType(EnumUIType _uiType)
		{
			System.Type _scriptType = null;
			switch (_uiType)
			{
			    case EnumUIType.TestOne:
				    _scriptType = typeof(TestOne);
				    break;
			    case EnumUIType.TestTwo:
				    _scriptType = typeof(TestTwo);
				    break;
                case EnumUIType.PanelStart:
                    _scriptType = typeof(Login);
                    break;
                case EnumUIType.PanelLoading:
                _scriptType = typeof(LoadingBar);
                    break;
			    default:
				    Debug.Log("Not Find EnumUIType! type: " + _uiType.ToString());
				    break;
			}
			return _scriptType;
		}

	}

    public static class SpritePathDefine
    {
        /// <summary>
        /// 精灵预设
        /// </summary>
        public const string SPRITE_PREFAB = "Prefabs/Sprite/";

        public static string GetPrefabPathByType(EnumSpriteType _spriteType)
        {
            string _path = string.Empty;
            switch (_spriteType)
            {
                // 精灵
                case EnumSpriteType.SpriteNumber:
                    _path = SPRITE_PREFAB + "SpriteNumber";
                    break;
                default:
                    Debug.Log("Not Find EnumUIType! type: " + _spriteType.ToString());
                    break;
            }
            return _path;
        }
    }

    public static class ModelPathDefine
    {
        /// <summary>
        /// 模型预设
        /// </summary>
        public const string MODEL_PREFAB = "Prefabs/Model/";

        public static string GetPrefabPathByType(EnumModel _modelType)
        {
            string _path = string.Empty;
            switch (_modelType)
            {
                case EnumModel.Player0:
                    _path = MODEL_PREFAB + "Player0";
                    break;
                case EnumModel.Player1:
                    _path = MODEL_PREFAB + "Player1";
                    break;
                case EnumModel.Player2:
                    _path = MODEL_PREFAB + "Player2";
                    break;
            }
            return _path;
        }
    }

	#endregion
	//public delegate void OnTouchEventHandle(EventTriggerListener _listener, object _args, params object[] _params);
	

	public class Defines : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
