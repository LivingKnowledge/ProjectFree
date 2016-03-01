using UnityEngine;
using System.Collections;
using SP_PhysicsUtils;

public class VaultController : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    public float vaultTime;

    public Transform vaultStart;
    public Transform vaultEnd;
    public Transform stumblevaultend;
    public Transform stumbleJumpTrans;
    

    public TriggerInfo startTrigger;
    public StumbleTriggerInfo stumbleTrigger;
    public PlayerCharacter player;

    float mVaultSpeed = 1;
    float mStumbleStartSpeed = 2;

    public bool runningvault = false;
    public bool hasStumbled = false;
    public bool runningStumbleVautl = false;
    public float vaultspeed = 5;

    //private static PlayerCharacter player;
   

    public void Initialize(PlayerCharacter pl)
    {
        player = pl;
    } 

    void Start()
    {

    }

    void Update()
    {
        if( !runningvault)
            if(Input.GetButtonDown("Jump"))
            if (startTrigger.Grounded())
            {
                runningvault = true;
                Vector3 playervel =  player.GetPlayerVelocity();
                print("Players velocity into vault : " + playervel);
                //player.HaultPhysicsBody();
                player.RestrictMovement( false );

                Vector3 playerPos = player.GetPos();


                float timeforvault = PhysicsUtilities.TimeToReachDistAtVel
                    (playerPos.x, vaultEnd.position.x, playervel.x);
                print("Time for vault distance : " + timeforvault);

                //Yf = Y0 + Vo0(T) + (0.5f)(A)(T * T)
                //Yf = Y0 + Vo0(T) + (0.5f)(A)(T)

                float a = (0.5f) * (-9.8f) * (timeforvault * timeforvault);
                float denom = 1f / timeforvault;
                float Yf = vaultEnd.position.y;
                float Y0 = playerPos.y - 2f;
                float finalYvelforvault = -((Y0 - Yf) + a) / timeforvault;

                player.SetVelocity(new Vector3(playervel.x , finalYvelforvault , playervel.z));
               

                StartCoroutine(enumWaitTillFinishedVault(timeforvault));

            }

            
            
            if(stumbleTrigger.Stumble())
            {
                Vector3 playerStumblevel = player.GetPlayerVelocity();
                player.RestrictMovement(false);
                player.HaultPhysicsBody();
                hasStumbled = true;
                player.SetVelocity( new Vector3( mStumbleStartSpeed, playerStumblevel.y, 0 ) );
                //player.SetVelocity()

            }

            if( hasStumbled && !stumbleTrigger.Stumble() )
            {
                //if(!runningStumbleVautl)
                //runningvault = true;
                runningStumbleVautl = true;
                Vector3 playervel = player.GetPlayerVelocity();
                print( "Players velocity into vault : " + playervel );
                player.RestrictMovement( false );
                //player.HaultPhysicsBody();

                Vector3 playerPos = player.GetPos();


                float timeforvault = PhysicsUtilities.TimeToReachDistAtVel
                    ( playerPos.x, stumblevaultend.position.x, vaultspeed + 1);
                print( "Time for vault distance : " + timeforvault );

                //Yf = Y0 + Vo0(T) + (0.5f)(A)(T * T)
                //Yf = Y0 + Vo0(T) + (0.5f)(A)(T)

                float a = (0.5f) * (-11.0f) * (timeforvault * timeforvault);
                float denom = 1f / timeforvault;
                float Yf = stumblevaultend.position.y;
                float Y0 = playerPos.y - 2f;
                float finalYvelforvault = -((Y0 - Yf) + a) / timeforvault;

                player.SetVelocity( new Vector3(playervel.x, finalYvelforvault, playervel.z ) );


                StartCoroutine(enumWaitTillHasFinishedStumbled( timeforvault) );
            }
        

            

    }

    IEnumerator enumWaitTillFinishedVault(float time)
    {
        print("start wait");
        yield return new WaitForSeconds(time + 0.5f);
        print("end wait");
        player.RestrictMovement(true);
        runningvault = false;
    }

    IEnumerator enumWaitTillHasFinishedStumbled(float time)
    {
        print( "start Stumble time" );
        yield return new WaitForSeconds( time + 0.5f );
        print( "end stumble time" );
        player.RestrictMovement( true );
        hasStumbled = false;
        runningStumbleVautl = false;
    }

   

}
