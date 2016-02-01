using UnityEngine;
using System.Collections;

public class VaultController : MonoBehaviour
{
    public float time;
    public float newVeclocity;
    
    void Start()
    {
       
    }

    void OnTriggerEnter( Collider col )
    {
       
    }


    void OnCollisionEnter(Collision collider)
    {
        Debug.LogWarning("Collison apparent!");
    }

}
