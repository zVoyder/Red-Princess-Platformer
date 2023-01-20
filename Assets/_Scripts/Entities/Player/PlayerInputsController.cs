using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerInputsController : MonoBehaviour
{
    InputsManager inputs;
    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        inputs = new InputsManager();
        inputs.Enable();

        inputs.Player.Movement.performed += Move;
        inputs.Player.Jump.performed += ChargeJump;
        inputs.Player.Jump.canceled += ReleaseJump;
        inputs.Player.Talk.performed += Talk;

        inputs.Player.Talk.Disable();
    }

    public void Move(InputAction.CallbackContext context)
    {
        player.Move(context.ReadValue<Vector2>().x);
    }

    public void ChargeJump(InputAction.CallbackContext context)
    {
        player.ChargeJump();
    }

    public void ReleaseJump(InputAction.CallbackContext context)
    {
        player.ReleaseJump();
    }

    public void Talk(InputAction.CallbackContext context)
    {
        player.Talk();
    }

    public void DisableMovement()
    {
        inputs.Player.Movement.Disable();
        inputs.Player.Jump.Disable();
    }

    public void EnableMovement()
    {
        inputs.Player.Movement.Enable();
        inputs.Player.Jump.Enable();

        
    }

    public void EnableTalk()
    {
        inputs.Player.Talk.Enable();
    }

    public void DisableTalk()
    {
        inputs.Player.Talk.Disable();
    }

    public void DisableAllInputs()
    {
        DisableMovement();
        DisableTalk();
    }

    public void EnableAllInputs()
    {
        EnableMovement();
        EnableTalk();
    }

}
