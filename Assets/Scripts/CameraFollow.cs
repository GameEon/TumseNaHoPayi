using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Camera controller to control movement of the camera transform
*/
public class CameraFollow : MonoBehaviour
{
    public float offset;
    Transform playerTransform;
    Transform selfTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(TagTracker.playerTag).transform;    
        selfTransform = transform;
    }

    void LateUpdate()
    {
        float yMin = Mathf.Clamp(playerTransform.position.y, 0, 100);
        Vector3 movePosition = new Vector3(playerTransform.position.x - offset, yMin, selfTransform.position.z);
        
        selfTransform.position = Vector3.Lerp(selfTransform.position, movePosition, Time.deltaTime * 5);
    }
}
