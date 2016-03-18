using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float climbSpeed;
    public float vaultspeed;
    float slidespeed;
    float orgianlCapheight;
    Vector3 orginalCapcenter;

    private Animator myanim;
    private Rigidbody myRigidBody;
    Transform myTransform;
    CapsuleCollider myCapsule;
    public WallTriggerInfo walltrigg;

    public bool canMove = true;
    public bool inAir = false;
    public bool isSliding = false;
    public bool isClimbing = false;


    void OnCollisionEnter()
    {
        inAir = false;
        myanim.SetBool("InAir", inAir);
        //canMove = true;

        
        myanim.SetBool("InAir", inAir);

    }

    void OnCollisionExit()
    {
        //isClimbing = false;
        //myanim.SetBool("canClimb", isClimbing);
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            CheckMaxSpeed();

        }
        
       if(canMove)
       {
           HandleSpeed();
       }

       if (canMove && !inAir)
       {
           HandleJumping();

       }



    }

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myTransform = GetComponent<Transform>();
        myanim = GetComponent<Animator>();
        myCapsule = GetComponent<CapsuleCollider>();

        orgianlCapheight = myCapsule.height;
        orginalCapcenter = myCapsule.center;

    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (walltrigg.Climb())
        {

            HandleWallClimb();
        }

    }

    public void RestrictMovement(bool on)
    {
        canMove = on;
    }


    void HandleJumping()
    {
        if (Input.GetButtonDown("Jump") && !inAir)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, 0);
            myTransform.Translate(new Vector3(myRigidBody.velocity.x * Time.deltaTime, 
                myRigidBody.velocity.y * Time.deltaTime, 0));
            inAir = true;
            //canMove = false;

            myanim.SetBool("InAir", inAir);
            myanim.speed = 3.0f;

            //myanim.SetFloat("Jumpforce", myRigidBody.velocity.y);
            //myanim.speed = 3.0f;
        }
    }

    void HandleSpeed()
    {
        if (canMove)
        {
            myRigidBody.velocity = new Vector3(0, myRigidBody.velocity.y, moveSpeed);
            myTransform.Translate(new Vector3(0,
                myRigidBody.velocity.y * Time.deltaTime, myRigidBody.velocity.z * Time.deltaTime));

            myanim.SetFloat( "Speed", myRigidBody.velocity.z );
            myanim.speed = 3.0f;

        }

    }

    void HandleWallClimb()
    {
        if (Input.GetButton("Climb"))
        {
            //isClimbing = true;
            myRigidBody.velocity = new Vector3(0, climbSpeed, 0);
            myTransform.Translate(new Vector3(0,
                myRigidBody.velocity.y * Time.deltaTime, 0));

            myanim.SetBool("canClimb", walltrigg.Climb());
            myanim.speed = 3.0f;
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

    public void SetMoveSpeed(float sp)
    {
        moveSpeed = sp;
    }

    public float GetVaultSpeed()
    {
        return vaultspeed;
    }

    public float GetClimbSpeed()
    {
        return climbSpeed;
    }

    public bool GetinAir()
    {
        return inAir;
    }



}