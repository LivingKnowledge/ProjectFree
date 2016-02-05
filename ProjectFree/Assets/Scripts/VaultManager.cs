using UnityEngine;
using System.Collections;

public class VaultManager : MonoBehaviour {

    public PlayerCharacter player;
    VaultController[] vaults;
	// Use this for initialization

	void Start ()
    {
        vaults = GetComponentsInChildren<VaultController>();
        
        for(int i=0;i<vaults.Length;++i)
        {
            vaults[i].Initialize(player);
        }    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
