using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Need.Mx;

/*
 * SoundEvents Specification and defaults
 * 
 * PlaySound "name=EventName", "sound=AudioBankName" volume="1.0" pitch="1.0" pitchRange="1.0,1.0"
 * StartSoundLoop "name=EventName" "sound=AudioBankName" "volume=1.0" "pitch=1.0" "pitchRange=1.0,1.0"
 * StopSoundLoop "name=EventName"
 * StartMusic "name=EventName" "sound=AudioBankName" "startEndVolume=0,1" "fadeTime=1" "loop=true"
 * StopMusic "name=EventName" "targetVolume=0" "fadeTime=1"
 * FadeMusic "name=EventName" "targetVolume=0" "fadeTime=1"
 * 
 */

public abstract class SoundEvent
{
    public string name = "";
    public string soundName = "";
    public float volume = 1;
    public AudioClip clip = null;
    public SoundLibrary library = null;

    protected static Dictionary<int, AudioChannel> channelRefs = new Dictionary<int, AudioChannel>();

    protected static int soundIDCounter = 100000;


    public virtual void Deserialize(params string[] paramlist)
    {
        for (int i = 0; i < paramlist.Length; i++)
        {
            string value = paramlist[i];
            string[] strings = value.Split('=');
            if (strings.Length == 2)
            {
                DeserializeAttribute(strings[0], strings[1]);
            }
        }
    }

    protected virtual void DeserializeAttribute(string type, string value)
    {
        switch (type)
        {
            case "name":
                name = value;
                break;
            case "sound":
                soundName = value;
                break;
            case "volume":
                volume = System.Convert.ToSingle(value);
                break;
        }
    }

    protected float[] GetFloatValues(string str)
    {
        string[] strings = str.Split(',');
        float[] values = new float[strings.Length];

        for (int i = 0; i < strings.Length; i++)
        {
            values[i] = System.Convert.ToSingle(strings[i]);
        }

        return values;
    }

    public virtual int FireEvent(int id)
    {
        return -1;
    }

    public static AudioChannel GetAudioChannel(int id)
    {
        if (channelRefs.ContainsKey(id))
        {
            return channelRefs[id];
        }

        return null;
    }

    public static int GetSoundID()
    {
        soundIDCounter++;
        return soundIDCounter;
    }

    public static void CleanUpChannels()
    {
        List<int> expiredChannels = new List<int>();

        foreach (int channelID in channelRefs.Keys)
        {
            // �����������ڹ�����Ƴ���û�з�ѭ�����ŵı����������������
            // �����ش������ڲ������ֵ�ʱ�����ﲻ����������Ƶ������
            // ������˷ѵײ���Դ
            if (channelRefs[channelID].source.isPlaying == false && !channelRefs[channelID].source.loop && !channelRefs[channelID].paused && !channelRefs[channelID].isMusic)
            {
                expiredChannels.Add(channelID);
            }
        }

        foreach (int channelID in expiredChannels)
        {
            channelRefs.Remove(channelID);
        }
    }
}

public class SFXEvent : SoundEvent
{
    public Vector2 minMaxPitchRange = new Vector2(1, 1);

    protected override void DeserializeAttribute(string type, string value)
    {
        base.DeserializeAttribute(type, value);

        switch (type)
        {
            case "pitch":
                minMaxPitchRange.x = minMaxPitchRange.y = System.Convert.ToSingle(value);
                break;

            case "pitchRange":
                float[] values = GetFloatValues(value);
                if (values.Length == 2)
                {
                    minMaxPitchRange.x = values[0];
                    minMaxPitchRange.y = values[1];
                }
                break;
        }
    }
}

public class PlaySFXEvent : SFXEvent
{
    public override int FireEvent(int id)
    {
        if (library != null)
        {
            clip = library.GetSoundFromLibrary(soundName);
        }

        if (clip != null)
        {
            float pitch = Random.Range(minMaxPitchRange.x, minMaxPitchRange.y);

            AudioChannel channel = Main.SoundManager.PlaySoundAt(clip, Vector3.zero, volume, pitch);

            id = GetSoundID();

            channelRefs.Add(id, channel);

            return id;
        }
        else
        {
            Log.Hsz("Warning: Couldn't find sound - " + soundName);
            return -1;
        }
    }
}

public class StartSFXLoopEvent : SFXEvent
{
    public override int FireEvent(int id)
    {
        if (clip != null && Main.SoundManager != null)
        {
            float pitch = Random.Range(minMaxPitchRange.x, minMaxPitchRange.y);

            AudioChannel channel = Main.SoundManager.PlaySoundAt(clip, Vector3.zero, volume, pitch, true);

            id = GetSoundID();

            channelRefs.Add(id, channel);

            return id;
        }
        else
        {
            Log.Hsz("Warning: Couldn't find sound - " + soundName);
            return -1;
        }
    }
}

public class StopSFXLoopEvent : SoundEvent
{
    public override int FireEvent(int id)
    {
        if (Main.SoundManager != null)
        {
            AudioChannel channel = null;
            if (channelRefs.ContainsKey(id))
            {
                channel = channelRefs[id];
                channelRefs.Remove(id);
            }

            if (channel != null)
            {
                Main.SoundManager.StopChannel(channel);
            }
            else
            {
                Log.Hsz("Trying to stop a SFX loop that hasn't been stored: " + name);
            }
        }

        return -1;
    }
}





public abstract class MusicEvent : SoundEvent
{
    public float fadeTime = 1;
    public Vector2 startEndVolume = new Vector2(0, 1);
    public bool loop = true;


    protected override void DeserializeAttribute(string type, string value)
    {
        base.DeserializeAttribute(type, value);

        switch (type)
        {
            case "fadeTime":
                fadeTime = System.Convert.ToSingle(value);
                break;
            case "startEndVolume":
                float[] values = GetFloatValues(value);
                if (values.Length == 2)
                {
                    startEndVolume.x = values[0];
                    startEndVolume.y = values[1];
                }
                break;
            case "loop":
                loop = System.Convert.ToBoolean(value);
                //Log.Hsz(loop);
                break;
        }
    }
}


public class StartMusicEvent : MusicEvent
{
    public override int FireEvent(int id)
    {
        if (clip != null && Main.SoundManager != null)
        {
            AudioChannel channel = Main.SoundManager.PlayMusic(clip, startEndVolume.x, startEndVolume.y, fadeTime, loop);

            id = GetSoundID();

            channelRefs.Add(id, channel);

            return id;
        }
        else
        {
            Log.Hsz("Warning: Couldn't find sound - " + soundName);
            return -1;
        }
    }
}

public class FadeMusicEvent : MusicEvent
{
    float targetVolume = 0;

    protected override void DeserializeAttribute(string type, string value)
    {
        base.DeserializeAttribute(type, value);

        switch (type)
        {
            case "targetVolume":
                targetVolume = System.Convert.ToSingle(value);
                break;
        }
    }

    public override int FireEvent(int id)
    {
        if (Main.SoundManager != null)
        {
            AudioChannel channel = null;
            if (channelRefs.ContainsKey(id))
            {
                channel = channelRefs[id];
            }

            if (channel != null)
            {
                Main.SoundManager.FadeMusic(channel, targetVolume, fadeTime, true);
            }
            else
            {
                Log.Hsz("Trying to fade music that hasn't been stored: " + name);
            }
        }

        return -1;
    }
}

public class StopMusicEvent : MusicEvent
{
    float targetVolume = 0;

    protected override void DeserializeAttribute(string type, string value)
    {
        base.DeserializeAttribute(type, value);

        switch (type)
        {
            case "targetVolume":
                targetVolume = System.Convert.ToSingle(value);
                break;
        }
    }

    public override int FireEvent(int id)
    {
        if (Main.SoundManager != null)
        {
            AudioChannel channel = null;
            if (channelRefs.ContainsKey(id))
            {
                channel = channelRefs[id];
                channelRefs.Remove(id);
            }

            if (channel != null)
            {
                Main.SoundManager.FadeMusic(channel, targetVolume, fadeTime);
            }
            else
            {
                Log.Hsz("Trying to stop music that hasn't been stored: " + name);
            }
        }

        return -1;
    }
}