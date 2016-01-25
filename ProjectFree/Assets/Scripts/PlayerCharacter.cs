using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidBody;

    public bool isGrounded;
    public LayerMask whatisGround;

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

        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("isGrounded", isGrounded);

	}
}
