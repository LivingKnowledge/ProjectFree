using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{

    //carmer
    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 20;
    public float maxOrtho = 100;


    public float moveSpeed;
    public float jumpForce;
    public float climbSpeed;
    private float originalSpeed;


    private Rigidbody myRigidBody;

    public bool isGrounded = false;
    public bool isClimbing = false;
    public bool wallCheck = false;
    public bool facingRight = true;

    public LayerMask whatisGround;
    public LayerMask whatisWall;

    public Transform wallCheckPoint;

    private Collider mycollider;

    private Animator myAnimator;

    void OnCollisionEnter(Collision col)
    {
     
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.LogWarning("Ground hit?");

        }
        else if (col.gameObject.tag == "Wall")
        {
            isClimbing = true;
            Debug.LogWarning("Wall Hit?");
        }
        
    }

    void OnCollisionExit(Collision col)
    {
        isClimbing = false;
    }
    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        originalSpeed = moveSpeed;

        mycollider = GetComponent<Collider>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moveSpeed < 10)
        {
            moveSpeed+=2 * Time.deltaTime;

        }
        //moveSpeed *= Time.deltaTime;
        myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y);

        if (isGrounded)
        {
            HandleJumping();
            
        }
        else if (isClimbing && !isGrounded)
        {
            moveSpeed = originalSpeed;
            HandleWallClimbing();
        }
     

            if (moveSpeed > 7 && moveSpeed < 10)
            {
                targetOrtho = zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, maxOrtho, minOrtho);
                Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
                
                //if(isClimbing)
                //{
                //
                //    targetOrtho = zoomSpeed;
                //    targetOrtho = Mathf.Clamp(-targetOrtho, minOrtho, maxOrtho);
                //    Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
                //}
            }


    }


    void HandleWallClimbing()
    {
        myRigidBody.velocity = new Vector3(0, climbSpeed);
        //isClimbing = false;
        //isGrounded = true;
    }

    void HandleJumping()
    {
        if (Input.GetButtonDown("Jump"))
        {

            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    

}