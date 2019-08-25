using System.Collections;
using UnityEngine;

/*
 * Spikes behavior inherits from Ground for initializing collider bounds and sprite size
*/
public class Spikes : Ground
{
    Vector3 currentPosition;
    Transform spikeTransform;

    void Awake()
    {
        currentPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == TagTracker.playerTag)
        {
            StartCoroutine(DieSlowly(collider));
        }
    }

    IEnumerator DieSlowly(Collider2D collider)
    {
        collider.gameObject.GetComponent<Player>().CanControl(false);
        yield return new WaitForSeconds(0.5f);
        collider.gameObject.GetComponent<Player>().PlayerDie();
    }

    void Update()
    {
        if (spikeTransform == null)
            spikeTransform = transform;
        spikeTransform.position = Vector3.Lerp(spikeTransform.position, currentPosition, Time.deltaTime * 5);
    }

    public void EnableSpikes(float yPosition)
    {
        currentPosition = new Vector3(spikeTransform.position.x, yPosition, 1);
    }
}
