using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameobjectOnEndAnimation : MonoBehaviour
{
    void Start()
    {
        Animator anim = GetComponent<Animator>();

        Destroy(transform.root.gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }
}
