using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Water : MonoBehaviour
{
    public float playerSpeedModifier = 3;
    public float surfaceOffset;
    public GameObject[] splashes;

    private float originalPlayerSpeed = 7;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent<Entity>(out Entity ent))
        {
            Splash(collision.transform);

            originalPlayerSpeed = ent.speed;
            ent.speed = playerSpeedModifier;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Entity>(out Entity ent))
        {
            Splash(collision.transform);
            ent.speed = originalPlayerSpeed;
        }
    }

    private void Splash(Transform tr)
    {
        Instantiate(splashes[Random.Range(0, splashes.Length)], new Vector2(tr.position.x, transform.position.y + surfaceOffset), transform.rotation);
    }
}
