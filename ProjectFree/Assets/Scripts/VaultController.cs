﻿using UnityEngine;
using System.Collections;
using SP_PhysUtilites;

public class VaultController : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    public float vaultTime;

    public Transform vaultStart;
    public Transform vaultEnd;

    public TriggerInfo startTrigger;
    public PlayerCharacter player;

    public bool runningvault = false;



    //private static PlayerCharacter player;
    Rigidbody myRigidbody;

    public void Initialize(PlayerCharacter pl)
    {
        player = pl;
    } 

    void Start()
    {

    }

    void Update()
    {
        if (!runningvault)
            if (startTrigger.Grounded())
            {
                runningvault = true;
                // startTrigger.SetIsVaulting(true);
                player.RestrictMovement(false);
                Vector3 playervel =  player.GetPlayerVelocity();
                print("Players velocity into vault : " + playervel);
                //player.HaultPhysicsBody();

                Vector3 playerPos = player.GetPos();


                float timeforvault = PhysicsUtilities.TimeItTakesToVault
                    (playerPos.x, vaultStart.position.x, playervel.x);
                print("Time for vault distance : " + timeforvault);

                //Yf = Y0 + Vo0(T) + (0.5f)(A)(T * T)
                //Yf = Y0 + Vo0(T) + (0.5f)(A)(T)

                float a = (0.5f) * (-9.8f) * (timeforvault * timeforvault);
                float denom = 1f / timeforvault;
                float Yf = vaultEnd.position.y;
                float Y0 = playerPos.y - 2f;
                float finalYvelforvault = (-(Y0 - Yf) + a) / timeforvault;

                //startTrigger.SetIsGround(false);

                player.SetVelocity(new Vector3(playervel.x * player.GetVaultSpeed(), finalYvelforvault * vaultTime, playervel.z));
               

                StartCoroutine(enumWaitTillFinishedVault(timeforvault));

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

   

}
