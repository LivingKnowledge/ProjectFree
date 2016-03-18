using UnityEngine;
using System.Collections;

public class WallTriggerInfo : MonoBehaviour
{
    public bool canClimb = false;
    PlayerCharacter player;

    void FixedUpdate()
    {
        canClimb = false;
    }

    void OnTriggerEnter()
    {
        canClimb = false;

    }

    void OnTriggerStay()
    {
        canClimb = true;

    }

    void OnCollisionEnter()
    {

    }

    void OnCollisionExit()
    {

    }

    public bool Climb()
    {
        return canClimb;
    }

    public void SetClimb(bool bol)
    {
        canClimb = bol;
    }
}
