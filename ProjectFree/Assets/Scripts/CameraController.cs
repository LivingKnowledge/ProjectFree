using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public PlayerCharacter player;
    Rigidbody mybody;

    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 7;
    public float maxOrtho = 15;


    void Start()
    {
        mybody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var playervel = mybody.velocity.x;

        if( playervel > 7 )
        {
            targetOrtho = maxOrtho;
        }
        else
        {
            targetOrtho = minOrtho;
        }

        Camera.main.fieldOfView = Mathf.Lerp( Camera.main.fieldOfView, targetOrtho, zoomSpeed * Time.deltaTime );

    }
}
