using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Need.Mx;

public class TestOne : BaseUI
{
    #region MyRegion
    private TestOneModule oneModule;
    private Button btn;
    private Text text;
    #endregion
  
	#region implemented abstract members of BaseUI
	public override EnumUIType GetUIType ()
	{
		return EnumUIType.TestOne;
	}
	#endregion

	// Use this for initialization
	void Start ()
	{
		text = transform.Find("Text").GetComponent<Text>();

		EventTriggerListener listener = EventTriggerListener.Get(transform.Find("Button").gameObject);
		listener.SetEventHandle(EnumTouchEventType.OnClick, Close, 1, "1234");

		oneModule = ModuleManager.Instance.Get<TestOneModule>();
		text.text = "Gold: " + oneModule.Gold;

	}

	protected override void OnAwake ()
	{
		MessageCenter.Instance.AddListener("AutoUpdateGold", UpdateGold);
		base.OnAwake ();
	}

	protected override void OnRelease ()
	{
		MessageCenter.Instance.RemoveListener("AutoUpdateGold", UpdateGold);
		base.OnRelease ();
	}

	private void UpdateGold(Message message)
	{
		int gold = (int) message["gold"];
		Debug.Log("TestOne UpdateGold : " + gold);
		text.text = "Gold: " + gold;
	}

	private void Close(GameObject _listener, object _args, params object[] _params)
	{
		int i = (int) _params[0];
		string s = (string) _params[1];
		Debug.Log(i);
		Debug.Log(s);
		UIManager.Instance.OpenUICloseOthers(EnumUIType.TestTwo);
	}
}

