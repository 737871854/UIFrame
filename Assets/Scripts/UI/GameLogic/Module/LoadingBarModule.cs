using System;
using UnityEngine;
using System.Collections.Generic;
using Need.Mx;


public class LoadingBarModule : BaseModule
{
    // 通用数字精灵
    public List<Sprite> numberList = null;

    public LoadingBarModule()
    {
        this.AutoRegister = true;        
    }

    protected override void OnLoad()
    {
        numberList = new List<Sprite>();
        GameObject spriteNumber = PrefabResManager.Instance.Load(SpritePathDefine.GetPrefabPathByType(EnumSpriteType.SpriteNumber)) as GameObject;
        PrefabComponent pc = spriteNumber.GetComponent<PrefabComponent>();
        pc.Init(); 
        string name = string.Empty;
        for (int i = 0; i < pc.SpriteDic.Count; i++)
        {
            name = "frame_start_coin_number_" + i.ToString();
            if (null != pc.SpriteDic && pc.SpriteDic.ContainsKey(name))
            {
                numberList.Add(pc.SpriteDic[name]);
            }
        }
        base.OnLoad();
    }

    protected override void OnRelease()
    {
        base.OnRelease();
    }
}
