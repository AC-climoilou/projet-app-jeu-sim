using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat("SoundVolume", defaultValue: 1f);
        set => PlayerPrefs.SetFloat("SoundVolume", value);
    }

    public static bool ObjectParticles
    {
        get => PlayerPrefs.GetInt("ObjectParticles", defaultValue: 1) == 1 ? true : false;
        set => PlayerPrefs.SetInt("ObjectParticles", value ? 1 : 0);
    }

    public static bool MuteSound
    {
        get => PlayerPrefs.GetInt("MuteSound", defaultValue: 0) == 1 ? true : false;
        set => PlayerPrefs.SetInt("MuteSound", value ? 1 : 0);
    }
}
