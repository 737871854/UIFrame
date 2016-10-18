//
// /**************************************************************************
//
// MessageType.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Unity课程讨论群:  152767675
//
// Date: 15-8-16
//
// Description:Provide  functions  to connect Oracle
//
// Copyright (c) 2015 xiaohong
//
// **************************************************************************/

using System;
namespace Need.Mx
{
	public class MessageType 
	{
		public static string Net_MessageTestOne = "Net_MessageTestOne";
		public static string Net_MessageTestTwo = "Net_MessageTestTwo";

        #region ------------------键盘按键替代Button----------------------------
        public static string Message_Key_Game_Start = "Message_Key_Game_Start";
        #endregion

        // 每帧刷新
        public static string Message_Update_Pre_Frame = "Message_Update_Pre_Frame";
        // 固定时间刷新
        public static string Message_Update_Fix_Frame = "Message_Update_Fix_Frame";

        // 投币
        public static string Message_Inster_Coin = "Message_Inster_Coin";
        // 投币后更新界面玩家币数
        public static string Message_Refresh_Coin = "Message_Refresh_Coin";

        // Login界面打开事件
        public static string Message_LoginView_Is_Open = "Message_LoginView_Is_Open";

	}
}

