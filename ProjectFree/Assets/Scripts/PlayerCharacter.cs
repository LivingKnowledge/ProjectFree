using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float climbSpeed;

    private Rigidbody2D myRigidBody;

    public bool isGrounded;
    public bool isClimbing;
    public bool wallCheck;
    public bool facingRight = true;

    public LayerMask whatisGround;
    public LayerMask whatisWall;

    public Transform wallCheckPoint;

    private Collider2D mycollider;

    private Animator myAnimator;

    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        mycollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        isGrounded = Physics2D.IsTouchingLayers(mycollider, whatisGround);

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(isGrounded == true)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
        }

        if(!isGrounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, whatisWall);

            if(facingRight)
            {
                if(wallCheck)
                {
                    HandleWallClimbing();
                }
            }
        }



        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("isGrounded", isGrounded);

	}

    void HandleWallClimbing()
    {
        myRigidBody.velocity = new Vector2(0, climbSpeed);

        isClimbing = true;

        if(facingRight)
        {
            //myRigidBody.AddForce(new Vector2())
        }
    }
}
