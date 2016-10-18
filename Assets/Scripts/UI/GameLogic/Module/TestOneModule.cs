//
// /**************************************************************************
//
// TestOneModule.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Unity课程讨论群:  152767675
//
// Date: 15-8-30
//
// Description:Provide  functions  to connect Oracle
//
// Copyright (c) 2015 xiaohong
//
// **************************************************************************/
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using Need.Mx;

public class TestOneModule : BaseModule
{
	public int Gold { get; private set; }

	public TestOneModule ()
	{
		this.AutoRegister = true;
	}

	protected override void OnLoad ()
	{
		MessageCenter.Instance.AddListener(MessageType.Net_MessageTestOne, UpdateGold);
		base.OnLoad ();
	}

	protected override void OnRelease ()
	{
		MessageCenter.Instance.RemoveListener(MessageType.Net_MessageTestOne, UpdateGold);
		base.OnRelease ();
	}

	private void UpdateGold(Message message)
	{
		int gold = (int) message["gold"];
		if (gold >= 0)
		{
			Gold = gold;
			Message temp = new Message("AutoUpdateGold", this);
			temp["gold"] = gold;
			temp.Send();
		}
	}
}

