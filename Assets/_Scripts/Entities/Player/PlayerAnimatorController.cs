using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    public bool startGetUp = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("GetUp", startGetUp);
    }

    public void Movement(float horizontal)
    {
        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
    }

    public void IdleJump(bool enabled)
    {
        anim.SetBool("Jumping", enabled);
    }

    public void ChargeJump(bool enabled)
    {
        anim.SetBool("ChargeJump", enabled);
    }

    public bool isChargingJump()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("ChargeJump");
    }

    public bool isIdleJumping()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("IdleJump");
    }

    public bool isToJumping()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("ToJump");
    }

    public bool isJumping() // This returns if it is in a state associated with the Jump action.
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsTag("Jump");
    }

    public bool isLanding()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("Landing");
    }
}
