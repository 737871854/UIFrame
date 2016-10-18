using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Need.Mx;

public class Player : MonoBehaviour
{
    private int coin;
    protected float lifeTime;
    protected float score;

    public int ID           { get;private set; }
    public float Score      { get { return score; }}
    public float LifeTime   { get { return lifeTime; }}

    public void Reset (int _id)
    {
        ID = _id;
        coin = 0;
        score = 0;
        lifeTime = GameConfig.GAME_CONFIG_MAX_LIFE_TIME;
        MessageCenter.Instance.AddListener(MessageType.Message_LoginView_Is_Open, OnLoginViewOpen);
    }

    public void InsertCoin (int value)
    {
        if (value > 0)
        {
            coin += value;
            SendInfoMessage();
        }
    }

    private void OnLoginViewOpen(Message message)
    {
        SendInfoMessage();
    }

    private void SendInfoMessage()
    {
        Message message = new Message(MessageType.Message_Refresh_Coin, this);
        message["id"] = ID;
        message["coin"] = coin;
        message.Send();
    }

    public void AddScore (int value)
    {
        if (value > 0)
        {
            score += value;
        }
    }

    public bool CanPlay ()
    {
        if (coin >= 3)
        {
            return true;
        }
        return false;
    }

    public void ChangePlay()
    {
        if (coin > 3)
        {
            coin -= 3;
        }
    }
}
