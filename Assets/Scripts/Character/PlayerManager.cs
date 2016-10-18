using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Need.Mx
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        private Player[] player;
        private GameObject[] go = new GameObject[3];

        public override void Init()
        {
            Debug.Log("PlayerManager Init()");
            player = new Player[GameConfig.GAME_CONFIG_PLAYER_COUNT];

            go[0] = PrefabResManager.Instance.LoadInstance(ModelPathDefine.GetPrefabPathByType(EnumModel.Player0)) as GameObject;
            go[1] = PrefabResManager.Instance.LoadInstance(ModelPathDefine.GetPrefabPathByType(EnumModel.Player1)) as GameObject;
            go[2] = PrefabResManager.Instance.LoadInstance(ModelPathDefine.GetPrefabPathByType(EnumModel.Player2)) as GameObject;
        }

        public void CreatePlyer()
        {
            for (int i = 0; i < GameConfig.GAME_CONFIG_PLAYER_COUNT; i++)
            {
                GameObject.DontDestroyOnLoad(go[i]);
                player[i] = go[i].GetOrAddComponent<Player>();
                player[i].Reset(i);
            }

            MessageCenter.Instance.AddListener(MessageType.Message_Inster_Coin, InsterCoinToPlayer);
        }

        public void Reset()
        {
            for (int index = 0; index < GameConfig.GAME_CONFIG_PLAYER_COUNT; index++)
            {
                player[index].Reset(index);
            }
        }

        public Player GetPlayer(int id)
        {
            return player[id];
        }

        private void InsterCoinToPlayer (Message message)
        {
            int id = (int) message["id"];
            int coin = (int)message["coin"];
            player[id].InsertCoin(coin);
        }
    }
}
