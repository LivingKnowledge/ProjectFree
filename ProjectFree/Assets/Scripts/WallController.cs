using UnityEngine;
using System.Collections;
using SP_PhysicsUtils;

public class WallController : MonoBehaviour 
{
    public PlayerCharacter player;

    public TriggerInfo startTrigger;
    public Transform startpoint;
    public Transform endpoint;

    float timeForclimb;

    public bool isClimbing = false;

    Rigidbody myRigidBody;

    public void Initialize(PlayerCharacter pl)
    {
        player = pl;
    }



	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!isClimbing && startTrigger.Grounded())
        {
	    if(Input.GetButtonDown("Climb"))
        //if(startTrigger.Grounded())
            {
                isClimbing = true;
                Vector3 playervel = player.GetPlayerVelocity();
                Vector3 playerpos = player.GetPos();
                float climbspeed = player.GetClimbSpeed();

                player.RestrictMovement(false);
                //player.HaultPhysicsBody();

                timeForclimb = PhysicsUtilities.TimeToReachDistAtVel
                   (playerpos.y,endpoint.position.y, climbspeed);
                print("Time for cliimb distance : " + timeForclimb);

                player.SetVelocity( new Vector3(0, climbspeed, playervel.z ) );


                StartCoroutine( enumWaitTillFinishedWallClimb( timeForclimb) );

            }
        }



	}

    IEnumerator enumWaitTillFinishedWallClimb( float time )
    {
        print( "start wait" );
        yield return new WaitForSeconds( time + 0.5f );
        print( "end wait" );
        player.SetMoveSpeed(2.0f);
        player.RestrictMovement( true );
        isClimbing = false;
    }

}
