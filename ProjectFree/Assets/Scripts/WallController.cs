﻿using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour 
{
    public PlayerCharacter player;

    public TriggerInfo startTrigger;

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
                isClimbing = true;
                Vector3 playervel = player.GetPlayerVelocity();

                player.SetVelocity( new Vector3(0, player.GetClimbSpeed(),playervel.z ) );

            }
        }

        StartCoroutine( enumWaitTillFinishedVault( 0.6f + 0.5f ) );


	}

    IEnumerator enumWaitTillFinishedVault( float time )
    {
        print( "start wait" );
        yield return new WaitForSeconds( time + 0.5f );
        print( "end wait" );
        //player.RestrictMovement( true );
        isClimbing = false;
    }

}