using UnityEngine;
using System.Collections;
using SP_PhysicsUtils;

public class SlideController : MonoBehaviour
{
    public PlayerCharacter player;

    public SlidingTriggerInfo startTrigger;
    public Transform endpoint;

    float timeForslide;

    public bool isSliding = false;

    Rigidbody myRigidBody;
    Animator myanim;
    

    public void Initialize(PlayerCharacter pl)
    {
        player = pl;
    }

    // Use this for initialization
    void Start()
    {
        myanim = player.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        if (!isSliding && startTrigger.Slide())
        {
            if (Input.GetButtonDown("Slide"))
            //if(startTrigger.Grounded())
            {
                isSliding = true;
                Vector3 playervel = player.GetPlayerVelocity();
                Vector3 playerpos = player.GetPos();
                float slidespeed = player.moveSpeed / 2;

                player.RestrictMovement(false);
                //player.HaultPhysicsBody();

                timeForslide = PhysicsUtilities.TimeToReachDistAtVel
                   (playerpos.z, endpoint.position.z, slidespeed);
                print("Time for slide distance : " + timeForslide);
                float timeis = timeForslide / 60.0f;

                player.SetVelocity(new Vector3(0, 0, slidespeed));

                myanim.SetBool("IsSliding" , isSliding);
                myanim.speed = 1.0f;

                StartCoroutine(enumWaitTillFinisheSlide(timeForslide));


            }



        }
    }


    IEnumerator enumWaitTillFinisheSlide(float time)
    {
        print("start wait");
        yield return new WaitForSeconds(time + 0.5f);
        print("end wait");

        //player.SetMoveSpeed(2.0f);
        player.RestrictMovement(true);
        isSliding = false;
        myanim.SetBool("IsSliding", isSliding);
    }
}
