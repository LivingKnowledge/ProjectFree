using UnityEngine;
using System.Collections;

public class SlideManager : MonoBehaviour
{
    public PlayerCharacter player;
    SlideController[] slides;
    // Use this for initialization

    void Start()
    {
        slides = GetComponentsInChildren<SlideController>();

        for (int i = 0; i < slides.Length; ++i)
        {
            slides[i].Initialize(player);
        }
    }


    // Update is called once per frame
    void Update ()
    {
	



	}
}
