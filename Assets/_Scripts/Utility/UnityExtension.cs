using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static class UnityExtension
{
    /// <summary>
    /// Extension method to check if a layer is in a layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static bool Contains(this LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    /// <summary>
    /// Here's a quick and dirty adaptation to allow the passing of 
    /// AudioSource Objects into the mix so that you can copy the properties.
    /// may be helpful in certain situations where you want to be able to assign
    /// an AudioMixer as well as adjust other properties within the inspector.
    /// </summary>
    /// <param name="audioSetting"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    public static void PlayClipAtPoint(AudioSourceSetting audioSetting, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        AudioSource tempASource = tempGO.AddComponent<AudioSource>(); // add an audio source
        tempASource.clip = audioSetting.clip;
        tempASource.volume = audioSetting.volume;
        tempASource.pitch = audioSetting.pitch;
        tempASource.outputAudioMixerGroup = audioSetting.mixerGroup;
        tempASource.spatialBlend = audioSetting.spatialBlend;

        tempASource.Play(); // start the sound
        MonoBehaviour.Destroy(tempGO, tempASource.clip.length);
    }
}