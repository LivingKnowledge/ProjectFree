using UnityEngine;
using System.Collections;

public class SlidingTriggerInfo : MonoBehaviour {

    public bool canSlide = false;
    PlayerCharacter player;

    void FixedUpdate()
    {
        canSlide = false;
    }

    void OnTriggerEnter()
    {
        canSlide = false;

    }

    void OnTriggerStay()
    {
        canSlide = true;

    }

    void OnCollisionEnter()
    {
       
    }

    void OnCollisionExit()
    {

    }

    public bool Slide()
    {
        return canSlide;
    }

    public void SetSlide(bool bol)
    {
        canSlide = bol;
    }
}
