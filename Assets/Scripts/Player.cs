using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player controller class
*/
public class Player : MonoBehaviour
{
    public float maxRunSpeed;
    bool isRunning;
    public float speed;
    public Vector2 jumpSpeed;

    public bool isOnGround;
    bool canControl = true;

    Rigidbody2D rbody;
    Transform selfTransform;
    public Transform spawnPoint;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        selfTransform = transform;
        SpawnPlayerOnPoint();
    }

    void SpawnPlayerOnPoint()
    {
        selfTransform.position = spawnPoint.position;
    }

    public void CanControl(bool control)
    {
        canControl = control;
    }

    void FixedUpdate()
    {
        if (canControl)
        {//Store the current horizontal input in the float moveHorizontal.
            float moveHorizontal = Input.GetAxis("Horizontal");

            //Store the current vertical input in the float moveVertical.
            float moveVertical = Input.GetAxis("Vertical");

            if (moveHorizontal > 0)
            {
                //Facing right
                selfTransform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (moveHorizontal < 0)
            {
                //Facing left
                selfTransform.rotation = new Quaternion(0, -180, 0, 0);
            }

            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            if (Input.GetKey(KeyCode.D))
            {
                rbody.velocity = new Vector2(speed, rbody.velocity.y);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rbody.velocity = new Vector2(-speed, rbody.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                rbody.velocity = Vector2.zero;
                rbody.velocity = jumpSpeed;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            isRunning = true;
            animator.SetInteger("state", 1);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            isRunning = false;
            animator.SetInteger("state", 0);
            rbody.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            animator.SetInteger("state", 2);
        }
    }

    void ResetJump()
    {
        if (isRunning)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }
    }

    public void PlayerDie()
    {
        SpawnPlayerOnPoint();
        GameManager.Instance.ResetGame();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagTracker.groundTag)
        {
            animator.SetInteger("state", 0);
        }
        if (collision.gameObject.tag == TagTracker.killTriggerTag)
        {
            PlayerDie();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagTracker.groundTag)
        {
            isOnGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagTracker.groundTag)
        {
            isOnGround = false;
        }
    }
}
