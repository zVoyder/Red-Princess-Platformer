using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputsController))]
[RequireComponent(typeof(PlayerAnimatorController))]
public class Player : Entity
{
    float jumpForce, bounceJumpForce, jumpDirection;
    bool hasBounced = false;

    internal PlayerAnimatorController animController;
    internal PlayerInputsController inputsController;
    
    public LayerMask bounceLayer, slidersLayer;
    public float minJumpForce = 3f, maxJumpForce = 10f;
    public float chargeJumpSpeed = 10f, bounceForceDecay;

    override protected void Start()
    {
        base.Start();

        inputsController = GetComponent<PlayerInputsController>();
        animController = GetComponent<PlayerAnimatorController>();
        jumpForce = minJumpForce;
    }


    private void Update()
    {
        if (animController.isChargingJump())
        {
            if (jumpForce < maxJumpForce)
                jumpForce += chargeJumpSpeed * Time.deltaTime;
        }

        if (!IsGrounded())
        {
            if (bounceJumpForce > 0)
                bounceJumpForce -= bounceForceDecay * Time.deltaTime;
        }

        animController.Movement(Mathf.Abs(horizontal));
        animController.IdleJump(!IsGrounded());
    }


    void FixedUpdate()
    {
        if (IsGrounded() && !animController.isChargingJump() && !animController.isLanding())
        {   
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    #region PlayerActions

    public void ChargeJump()
    {
        if (IsGrounded() && !animController.isLanding())
        {
            animController.ChargeJump(true);
            ResetVelocity();
        }
    }

    public void ReleaseJump()
    {
        if (animController.isChargingJump())
        {
            hasBounced = false;
            jumpDirection = horizontal;

            animController.ChargeJump(false);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            bounceJumpForce = jumpForce / 2; // I base the bounceup force on the initial jump force
            jumpForce = minJumpForce;
        }
    }

    #endregion

    public void Freeze()
    {
        horizontal = 0;
        ResetVelocity();
        inputsController.DisableMovement();
    }

    public void DeFreeze()
    {
        inputsController.EnableMovement();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (UnityExtension.Contains(bounceLayer, col.gameObject.layer))
        {
            if (!IsGrounded() && !hasBounced)
            {
                hasBounced = true;
                audios.Play("Bump");
                rb.AddForce(bounceJumpForce * Vector2.up, ForceMode2D.Impulse);
                rb.AddForce(-jumpDirection * bounceJumpForce * Vector2.right, ForceMode2D.Impulse);
            }
        }
    }
}
