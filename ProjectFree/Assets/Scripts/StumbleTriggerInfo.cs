using UnityEngine;
using System.Collections;

public class StumbleTriggerInfo : MonoBehaviour 
{

    public bool isStumbiing = false;

    void FixedUpdate()
    {
        isStumbiing = false;
    }

    void OnTriggerEnter()
    {
        isStumbiing = false;

    }

    void OnTriggerStay()
    {
        isStumbiing = true;

    }

    void OnCollisionEnter()
    {
        

    }

    void OnCollisionExit()
    {

    }

    public bool Stumble()
    {
        return isStumbiing;
    }

    public void SetisStumble(bool on)
    {
        isStumbiing = on;
    }
}
