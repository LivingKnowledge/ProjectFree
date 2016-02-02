using UnityEngine;
using System.Collections;

public class VaultController : MonoBehaviour
{
    private float time;
    private float vFinal;
    private float vStart;
    private float velocityI;
    private float velocityF;
    private float denom;
    private float quadratic;
    public float a;
    public float b1;
    public float b2;
    public float c;
    private float acceleration = Physics.gravity.y;

    public GameObject vaultStart;
    public GameObject vaultEnd;
    public GameObject player;


    //private static PlayerCharacter player;
    public Rigidbody myRigidbody;


    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }


        if(vaultStart == null)
        {
            vaultStart = GameObject.FindGameObjectWithTag("VaultStart");

        }

        if (vaultEnd == null)
        {
            vaultEnd = GameObject.FindGameObjectWithTag("VaultStart");

        }

    }

    void OnTriggerEnter( Collider col )
    {
        myRigidbody = col.GetComponent<Rigidbody>();
        
        vStart = vaultStart.transform.position.x;
        vFinal = vaultEnd.transform.position.x;
        velocityI = myRigidbody.velocity.x;

        a = 0.5f * acceleration * vStart;
        b1 = velocityI * velocityI;
        b2 = -velocityI;
        c = vStart;
        denom = 1 / (2 * 0.5f * acceleration);
        quadratic = Mathf.Sqrt(b1 - 4 * a) * denom;

        time = quadratic;
        
            
        velocityF = velocityI + acceleration * time;
        

        myRigidbody.velocity = new Vector3(0, 0);

        Debug.LogWarning("Collision apparent!");
    }

    void OnTriggerExit(Collider col)
    {
        Debug.LogWarning("Collision Exited!");
    }

    void OnCollisionEnter(Collision collider)
    {
        Debug.LogWarning("Collison apparent!");
    }

}
