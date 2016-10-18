using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Need.Mx;

public class GameController : MonoBehaviour
{
    public class Joystick
    {
        public bool start;
        public Vector3 position;


        public Joystick()
        {
            start = false;
            position = new Vector3();
        }
       
    }

    protected Joystick[] joysticks;
    
    void Start()
    {
        joysticks = new Joystick[GameConfig.GAME_CONFIG_PLAYER_COUNT];
        for (int index = 0; index < GameConfig.GAME_CONFIG_PLAYER_COUNT; ++index)
        {
            joysticks[index] = new Joystick();
        }
    }

    void Update()
    {
       
        {
            if (Input.GetKeyUp(KeyCode.F1))
            {
                Message message = new Message(MessageType.Message_Inster_Coin,this);
                message["id"] = GameConfig.GAME_CONFIG_PLAYER_1;
                message["coin"] = 1;
                message.Send();
            }

            if (Input.GetKeyUp(KeyCode.F3))
            {
                //joysticks[GameConfig.GAME_CONFIG_PLAYER_1].start = true;
                Message message = new Message(MessageType.Message_Key_Game_Start, this);
                message.Send();
            }

        }

        joysticks[GameConfig.GAME_CONFIG_PLAYER_1].position = Input.mousePosition;
    }


    public bool IsStartButtonPressed(int index)
    {
        bool value = joysticks[index].start;
        joysticks[index].start = false;
        return value;
    }

    public Vector3 JoystickPosition(int index)
    {
        return joysticks[index].position;
    }

}