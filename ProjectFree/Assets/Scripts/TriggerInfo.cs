using UnityEngine;
using System.Collections;

public class TriggerInfo : MonoBehaviour
{
    public bool isGrounded = false;
    public bool isClimbing = false;

    void FixedUpdate()
    {
        isGrounded = false;
    }

    void OnTriggerEnter()
    {
        isGrounded = false;
        //isClimbing = true;
    }

    void OnTriggerStay()
    {
        isGrounded = true;
       
    }

    void OnCollisionEnter()
    {
        //isGrounded = true;
        isClimbing = true;
     
    }

    void OnCollisionExit()
    {
        isClimbing = false;
    }

    public bool Grounded()
    {
        return isGrounded;
    }

    public void SetGround(bool bol)
    {
        isGrounded = bol;
    }

    public bool Climbing()
    {
        return isClimbing;
    }
    
    
}
