using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float climbSpeed;
    private float originalSpeed;
    public float vaultspeed;
    public float slidespeed;

    float oldRot;

    private Rigidbody myRigidBody;
    public TriggerInfo vaultTrigger;
    public TriggerInfo wallTrigger;
    Transform myTransform;

    public bool canMove = true;
    public bool inAir = false;
    public bool isSliding = false;


    void OnCollisionEnter()
    {
        inAir = false;
    }

    void FixedUpdate()
    {

       CheckMaxSpeed();
        
       if(canMove)
       {
           HandleSpeed();
       }

       if (canMove == true && !inAir)
       {
           HandleJumping();

       }

        if (!isSliding && !inAir)
        {
            HandleSlide();
        }

        if (isSliding && !inAir)
        {
            HandleunSlide();
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


    }

    public void RestrictMovement(bool on)
    {
        canMove = on;
    }


    void HandleJumping()
    {
        if (Input.GetButtonDown("Jump") && !isSliding)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, 0);
            myTransform.Translate(new Vector3(myRigidBody.velocity.x * Time.deltaTime, 
                myRigidBody.velocity.y * Time.deltaTime, 0));
            inAir = true;
        }
    }

    void HandleSpeed()
    {
        if (isSliding)
        {
            myRigidBody.velocity = new Vector3(0, -slidespeed, 0);
            myTransform.Translate(new Vector3(myRigidBody.velocity.x * Time.deltaTime,
                myRigidBody.velocity.y * Time.deltaTime, 0));
        }


        if (!isSliding)
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0);
            myTransform.Translate(new Vector3(myRigidBody.velocity.x * Time.deltaTime,
                myRigidBody.velocity.y * Time.deltaTime, 0));

        }

    }

    void HandleSlide()
    {
        if (Input.GetKey("down") && !isSliding)
        {

            isSliding = true;
            myTransform.Rotate(Vector3.forward, 90, Space.Self);
        }
    }

    void HandleunSlide()
    {
        if (Input.GetButtonDown("unSlide") && isSliding)
        {
            isSliding = false;
            myTransform.Rotate(Vector3.forward, -90, Space.Self);
        }
    }


    void CheckMaxSpeed()
    {
        if (moveSpeed < 10 && !isSliding)
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