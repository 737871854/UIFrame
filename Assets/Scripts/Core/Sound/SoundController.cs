using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Need.Mx;


public class SoundController : MonoBehaviour
{

    [SerializeField]
    public SoundLibrary library;

    public SoundLibrary Library
    {
        get { return library; }
        set { library = value; }
    }

    static int soundIDCounter = 0;

    static int GetSoundID()
    {
        soundIDCounter++;
        return soundIDCounter;
    }

    private Dictionary<string, SoundEvent> eventsDict = new Dictionary<string, SoundEvent>();
    private int standByMusicId;
    private int standByMusicIndex;
    private int sceneMusicId;
    private int sceneEffectId;
    private int sceneTempId;
    private int waterWarningId;



    // Use this for initialization
    void Start()
    {
        sceneMusicId        = -1;
        sceneTempId         = 0;
        standByMusicId      = -1;
        standByMusicIndex   = 0;
        waterWarningId      = -1;
        library.Init();
    }

    public void Init()
    {
        
    }

    void Update()
    {
        SoundEvent.CleanUpChannels();
    }

    public AudioChannel GetAudioChannel(int id)
    {
        return SoundEvent.GetAudioChannel(id);
    }

    public int FireEvent(string eventName, int id = -1)
    {
        if (eventsDict.ContainsKey(eventName))
        {
            SoundEvent e = eventsDict[eventName];

            id = e.FireEvent(id);
        }
        else
        {
            Log.Hsz("Warning: Firing sound event that doesn't exist - " + eventName);
        }

        return id;
    }

    public void AddSoundEvent(string eventType, params string[] paramlist)
    {
        SoundEvent e = null;

        switch (eventType)
        {
            case "PlaySound":
                e = new PlaySFXEvent();
                break;
            case "StartSoundLoop":
                e = new StartSFXLoopEvent();
                break;
            case "StopSoundLoop":
                e = new StopSFXLoopEvent();
                break;
            case "StartMusic":
                e = new StartMusicEvent();
                break;
            case "StopMusic":
                e = new StopMusicEvent();
                break;
            case "FadeMusic":
                e = new FadeMusicEvent();
                break;
        }

        if (e != null)
        {
            e.Deserialize(paramlist);

            if (eventsDict.ContainsKey(e.name))
            {
                eventsDict[e.name].clip = library.GetSoundFromLibrary(e.soundName);
                eventsDict[e.name].library = library;
            }
            else
            {
                e.clip = library.GetSoundFromLibrary(e.soundName);
                e.library = library;
                eventsDict.Add(e.name, e);
            }
        }
    }
}
