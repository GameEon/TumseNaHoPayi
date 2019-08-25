using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple Transition for end game
*/
public class MoveToTransition : MonoBehaviour
{
    Transform selfTransform;
    public float destinationY = 1;
    public float currentY;
    // Start is called before the first frame update
    void Start()
    {
        selfTransform = transform;
        currentY = selfTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        selfTransform.position = Vector3.Lerp(selfTransform.position, new Vector3(selfTransform.position.x, currentY, selfTransform.position.z), Time.deltaTime * 5);
    }

    public void PlayerWon()
    {
        currentY = destinationY;
    }
}
