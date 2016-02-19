using UnityEngine;
using System.Collections;
using SP_PhysicsUtils;

public class WallController : MonoBehaviour 
{
    public PlayerCharacter player;

    public TriggerInfo startTrigger;

    public Transform startDis;
    public Transform endDis;

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
	    if(!isClimbing)
        {
            if(startTrigger.Grounded())
            {
                float climbSpeed = player.GetClimbSpeed();
                Vector3 playerPos = player.GetPos();
                timeForclimb = PhysicsUtilities.TimeToReachDistAtVel
                    ( playerPos.x, startDis.position.x, climbSpeed );

                isClimbing = true;
                Vector3 playervel = player.GetPlayerVelocity();

                player.SetVelocity( new Vector3(0, player.GetClimbSpeed(),playervel.z ) );



            }
        }

        StartCoroutine( enumWaitTillFinishedWallClimb( timeForclimb ) );


	}

    IEnumerator enumWaitTillFinishedWallClimb( float time )
    {
        print( "start wait" );
        yield return new WaitForSeconds( time + 0.5f );
        print( "end wait" );
        player.RestrictMovement( true );
        isClimbing = false;
    }

}
