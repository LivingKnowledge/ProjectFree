using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float climbSpeed;
    private float originalSpeed;
    public float vaultspeed;

    private Rigidbody myRigidBody;
    public TriggerInfo vaultTrigger;
    public TriggerInfo wallTrigger;
    Transform myTransform;

    public bool canMove = true;
    public bool inAir = false;

    void FixedUpdate()
    {

       CheckMaxSpeed();
        
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

        if( canMove == true && !inAir )
        {
            HandleJumping();

        }

    }

    public void RestrictMovement(bool on)
    {
        canMove = on;
    }


    void HandleJumping()
    {
        //if (startTrigger.Grounded());
        //if(startTrigger.Grounded() == false && !inAir)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce);
                //startTrigger.SetIsGrounded(false);
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, 0);
                myTransform.Translate(new Vector3(myRigidBody.velocity.x * Time.deltaTime, myRigidBody.velocity.y * Time.deltaTime, 0));
                //startTrigger.SetGround(false);
                inAir = true;
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
            moveSpeed+= Time.deltaTime;

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

    public float GetClimbSpeed()
    {
        return climbSpeed;
    }

    
    

}