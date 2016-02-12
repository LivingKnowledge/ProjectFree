using UnityEngine;
using System.Collections;

public class WallManager : MonoBehaviour 
{

    public PlayerCharacter player;
    WallController[] walls;

	// Use this for initialization
	void Start () 
    {
        walls = GetComponentsInChildren<WallController>();

        for( int i = 0; i < walls.Length; ++i )
        {
            walls[i].Initialize( player );
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
	

	}
}
