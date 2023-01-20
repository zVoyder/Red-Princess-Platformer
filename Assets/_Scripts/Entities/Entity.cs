using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EntityAudios))]
public class Entity : MonoBehaviour
{
    public LayerMask walkableLayers;
    public float speed = 5f;
    public bool isFacingRight;

    protected float horizontal;

    protected Rigidbody2D rb;
    protected SpriteRenderer sprite;
    protected DialogueManager dialogueReference;
    protected EntityAudios audios;

    protected virtual void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        dialogueReference = GetComponentInChildren<DialogueManager>();

        rb = GetComponent<Rigidbody2D>();
        audios = GetComponent<EntityAudios>();
    }

    protected void ResetVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    public bool IsGrounded()
    {
        return GroundBoxCast();
    }

    public RaycastHit2D GroundBoxCast()
    {
        return Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y), new Vector2(.5f, .2f), 0, Vector2.down, 0.2f, walkableLayers);
        //return Physics2D.Raycast(transform.position, Vector2.down, 1f, walkableLayers);
    }

    public void StayGrounded()
    {
        if (IsGrounded())
        {
            RaycastHit2D hit = GroundBoxCast();
            transform.position = new Vector2(transform.position.x, hit.point.y);
            Debug.Log(hit.point.y);
        }
    }

    protected void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            sprite.flipX = !sprite.flipX;
        }
    }

    public void SetDialogueReference(DialogueManager dm)
    {
        dialogueReference = dm;
    }

    public void Talk()
    {
        dialogueReference.DisplayNextSentence();
    }

    public void Move(float horizontal)
    {
        this.horizontal = horizontal;

        Flip();
    }

    public bool isMoving()
    {
        Debug.Log(horizontal);
        return horizontal != 0;
    }
}
