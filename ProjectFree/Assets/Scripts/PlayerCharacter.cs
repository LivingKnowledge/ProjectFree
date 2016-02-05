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
    public float vaultspeed;

    public static Rigidbody vaultVariables;
    private Rigidbody myRigidBody;
    public TriggerInfo startTrigger;
    Transform myTransform;

    public bool canMove = true;

    void FixedUpdate()
    {

       ///CheckMaxSpeed();
        
       if(canMove)
       {
           HandleSpeed();
       }


    }

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myTransform = GetComponent<Transform>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            HandleSpeed();

            HandleJumping();

            HandleWallClimbing();

            
        }


        if (moveSpeed > 7 && moveSpeed < 10)
        {
            targetOrtho = zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, maxOrtho, minOrtho);
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
           
        }

    }

    public void RestrictMovement(bool on)
    {
        canMove = on;
    }

    void HandleWallClimbing()
    {
        //if(startTrigger.Climbing())
        if(startTrigger.Climbing())
        {
            myRigidBody.velocity = new Vector3(0, climbSpeed);
            //startTrigger.SetIsClimbing(true);
        }
        //isGrounded = true;
    }

    void HandleJumping()
    {
        //if (startTrigger.Grounded());
        if(startTrigger.Grounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce);
                //startTrigger.SetIsGrounded(false);
            }
        }
    }

    void HandleSpeed()
    {
        //if(startTrigger.Grounded())
        //myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y);
        //myTransform.Translate (new Vector3(moveSpeed, myRigidBody.velocity.y, 0));
        myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0);
        myTransform.Translate(new Vector3(myRigidBody.velocity.x * Time.deltaTime, 
            myRigidBody.velocity.y * Time.deltaTime, 0));
    }

    void CheckMaxSpeed()
    {
        if (moveSpeed < 10)
        {
            moveSpeed++;

        }
    }

    public void HaultPhysicsBody()
    {
        myRigidBody.velocity = Vector3.zero;
    }

    public Vector3 GetPlayerVelocity()
    {
        return myRigidBody.velocity;
    }

    public Vector3 GetPos()
    {
        return myTransform.position;
    }

    public void SetVelocity(Vector3 vel)
    {
        myRigidBody.velocity = vel;
    }

    public float GetVaultSpeed()
    {
        return vaultspeed;
    }

    
    

}