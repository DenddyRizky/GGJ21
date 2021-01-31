using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{

    public enum Sound
    {
       gunshot,
       laserbeam,
       tentsweep_1,tentsweep_2,tentsweep3,tentsweep4,
       edeath1,edeath2,edeath3,edeath4,
       door,
       portal,
       spawn1,spawn2,spawn3,spawn4,spawn5,spawn_6,
       hit1,hit2,hit3,hit4,hit5,
       ehit1,ehit2,ehit3,ehit4,ehit5,ehit6,
       walkN,walkF,walkRS
    }

    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audiosource = soundGameObject.AddComponent<AudioSource>();
        audiosource.PlayOneShot();
    }

//    private static AudioClip GetAudioClip(Sound sound)
//    {
//        Debug.Log("Before foreach");
//        foreach (AudioStorage.SoundAudioClip soundAudioClip in AudioStorage.i.soundAudioClipArray)
//        {
//            if (soundAudioClip.sound == sound)
//            {
//                return soundAudioClip.audioClip;
//            }
//            else
//            {
//                Debug.LogError("foreach not ignored");
//            }
//        }
//        Debug.LogError("audioclip for " + sound + " not found!");
//        return null;
//    }
}