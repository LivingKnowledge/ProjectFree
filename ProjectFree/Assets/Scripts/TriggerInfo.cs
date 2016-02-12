using UnityEngine;
using System.Collections;

public class TriggerInfo : MonoBehaviour
{
    public bool isGrounded = false;
   

    void FixedUpdate()
    {
        isGrounded = false;
    }

    void OnTriggerEnter()
    {
        isGrounded = false;
       
    }

    void OnTriggerStay()
    {
        isGrounded = true;
       
    }

    void OnCollisionEnter()
    {
        //isGrounded = true;
       
     
    }

    void OnCollisionExit()
    {
      
    }

    public bool Grounded()
    {
        return isGrounded;
    }

    public void SetGround(bool bol)
    {
        isGrounded = bol;
    }


    
    
}
