using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameObjectWithTime : MonoBehaviour
{
    public float timeSeconds = 1;

    void Start()
    {
        Destroy(transform.root.gameObject, timeSeconds);
    }
}
