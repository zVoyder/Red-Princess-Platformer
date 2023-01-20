using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FootstepsSFX
{
    public AudioSourceSetting audioSetting;
    public MaterialClipsArrayDictionary sfxs;
}

public class EntityAudios : MonoBehaviour
{
    public FootstepsSFX footsteps;
    public StringAudioSourceSettingDictionary actionsSFX; 

    Entity entity;

    private void Start()
    {
        entity = GetComponent<Entity>();
    }

    public void Play(string key)
    {
        UnityExtension.PlayClipAtPoint(actionsSFX[key], transform.position);
    }

    public void PlayStep() //Called by the animations
    {
        RaycastHit2D hit = entity.GroundBoxCast();

        if (hit.transform.TryGetComponent<Collider2D>(out Collider2D collider) && entity.IsGrounded())
        {
            if (collider.sharedMaterial != null)
            {
                AudioClip[] arr = footsteps.sfxs[collider.sharedMaterial];
                footsteps.audioSetting.clip = arr[UnityEngine.Random.Range(0, arr.Length)];
                UnityExtension.PlayClipAtPoint(footsteps.audioSetting, hit.point);
            }
        }
    }
}
