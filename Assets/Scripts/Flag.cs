using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple Flag for determining level completion
*/
public class Flag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == TagTracker.playerTag)
        {
            GameManager.Instance.LevelComplete();
        }
    }
}
