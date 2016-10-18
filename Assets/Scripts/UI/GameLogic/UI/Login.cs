using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Need.Mx;

public class Login : BaseUI
{
    private LoginModule loginModule;

    #region UI
    //投币按钮
    private Button btn_coin;
    // 开始按钮
    private Button btn_start;
    // 要显示的投币数
    private List<Image> coinList = null;

    public override EnumUIType GetUIType()
    {
        return EnumUIType.PanelStart;
    }

    #endregion
    // Use this for initialization
    void Start()
    {
        InitUI();

        // 事件Button_00 功能同Button_03
        EventTriggerListener listenerCoin = EventTriggerListener.Get(btn_coin.gameObject);
        listenerCoin.SetEventHandle(EnumTouchEventType.OnClick, OnButtonCoin, "OnClickCoin");

        // 事件Button_01 功能同Button_02
        EventTriggerListener listeneStart = EventTriggerListener.Get(btn_start.gameObject);
        listeneStart.SetEventHandle(EnumTouchEventType.OnClick, OnButtonStart, "OnClickStart");

        loginModule = ModuleManager.Instance.Get<LoginModule>();
        loginModule.Load();

        // Login界面打开初始化完成后，刷新一次数据
        Message message = new Message(MessageType.Message_LoginView_Is_Open, this);
        message.Send();

        MessageCenter.Instance.AddListener(MessageType.Message_Key_Game_Start, OnKeyStart);
    }

    void InitUI ()
    {
        Image image;
        coinList  = new List<Image>();
        btn_start = transform.Find("Button").GetComponent<Button>();
        btn_coin  = transform.Find("Coin").GetComponent<Button>();
        for (int i = 0; i < 3; i++)
        {
            image = transform.Find("Coin/Image_Number" + i.ToString()).GetComponent<Image>();
            coinList.Add(image);
        }
    }

    protected override void OnAwake()
    {
        MessageCenter.Instance.AddListener(MessageType.Message_Refresh_Coin, OnRefreshUICoin);
        base.OnAwake();
    }

    protected override void OnRelease()
    {
        MessageCenter.Instance.RemoveListener(MessageType.Message_Refresh_Coin, OnRefreshUICoin);
        base.OnRelease();
    }

    private void OnRefreshUICoin(Message message)
    {
        int coin = (int)message["coin"];
        int playerId = (int)message["id"];

        int value0 = (int)((coin / 10) % 10);
        int value1 = (int)((coin / 1) % 10);

        coinList[0].sprite = loginModule.numberList[value0];
        coinList[1].sprite = loginModule.numberList[value1];
        coinList[2].sprite = loginModule.numberList[3];
    }

    #region Game Start
    private void OnKeyStart(Message message)
    {
        bool changeScene = false;
        for (int index = 0; index < GameConfig.GAME_CONFIG_PLAYER_COUNT; index++)
        {
            if (PlayerManager.Instance.GetPlayer(index).CanPlay())
            {
                PlayerManager.Instance.GetPlayer(index).ChangePlay();
                changeScene = true;
            }
        }

        if (changeScene)
        {
            CoroutineController.Instance.StartCoroutine(ChangeSceneToMain());
        }
        else
        {
            Debug.Log("The Coin number is not enough !");
        }
    }

    private void OnButtonStart(GameObject _listener, object _args, params object[] _params)
    {
        Debug.Log((string)_params[0]);
        bool changeScene = false;
        for (int index = 0; index < GameConfig.GAME_CONFIG_PLAYER_COUNT; index++)
        {
            if (PlayerManager.Instance.GetPlayer(index).CanPlay())
            {
                PlayerManager.Instance.GetPlayer(index).ChangePlay();
                changeScene = true;
            }
        }

        if (changeScene)
        {
            CoroutineController.Instance.StartCoroutine(ChangeSceneToMain());
        }
        else
        {
            Debug.Log("The Coin number is not enough !");
        }
    }

    #endregion

    #region Coin
    private void OnButtonCoin(GameObject _listener, object _args, object[] _params)
    {
        Message message = new Message(MessageType.Message_Inster_Coin, this);
        message["id"] = GameConfig.GAME_CONFIG_PLAYER_1;
        message["coin"] = 1;
        message.Send();
    }
    #endregion

    private IEnumerator ChangeSceneToMain()
    {
        yield return new WaitForSeconds(1);
        SceneManager.Instance.ChangeScene(EnumSceneType.MainScene, EnumUIType.TestOne);
    }
}
