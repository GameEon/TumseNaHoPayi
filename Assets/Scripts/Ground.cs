using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Base class for ground
*/

public class Ground : MonoBehaviour
{
    public bool isBreakable;
    public BoxCollider2D[] boxCollider;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        boxCollider = GetComponents<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < boxCollider.Length; i++)
        {
            boxCollider[i].size = spriteRenderer.size;
        }
        EnableObject(true);
    }

    void EnableObject(bool enabled)
    {
        for (int i = 0; i < boxCollider.Length; i++)
        {
            boxCollider[i].enabled = enabled;
        }
        spriteRenderer.enabled = enabled;
    }

    public void GlobalReset()
    {
        EnableObject(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagTracker.playerTag)
        {
            if (isBreakable)
            {
                EnableObject(false);
            }
        }
    }
}
