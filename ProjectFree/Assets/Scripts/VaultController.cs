using UnityEngine;
using System.Collections;

public class VaultController : MonoBehaviour
{
    PlayerCharacter player;

    BoxCollider2D box1;
    BoxCollider2D box2;

    private float time;
    private float height;

    void Start()
    {
        box1 = GetComponent<BoxCollider2D>();
        box2 = GetComponent<BoxCollider2D>();
    }


    void OnCollisionEnter(Collision collider)
    {
        
    }

}
