using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DeleteGameobjectOnClipEnd : MonoBehaviour
{
    void Start()
    {
        Destroy(transform.root.gameObject, GetComponent<AudioSource>().clip.length);   
    }
}
