using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerFootsteps : MonoBehaviour
{
    Player player;

    public AudioSourceSetting audio;
    public MaterialClipsArrayDictionary footsteps;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void PlayStep()
    {
        if (player.IsGrounded())
        {
            RaycastHit2D hit = player.GroundBoxCast();

            if(hit.transform.TryGetComponent<Collider2D>(out Collider2D collider))
            {
                AudioClip[] arr = footsteps[collider.sharedMaterial];

                audio.clip = arr[UnityEngine.Random.Range(0, arr.Length)];

                UnityExtension.PlayClipAtPoint(audio, hit.point);
            }
        }
    }
}
