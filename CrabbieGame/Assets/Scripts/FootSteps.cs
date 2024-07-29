using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource sandOne;
    public AudioSource sandTwo;
    public AudioSource waterOne;
    public AudioSource waterTwo;
    public AudioSource rockOne;
    public AudioSource rockTwo;

    private Collider playerColl;


    public bool sand;
    public bool rock;
    public bool water;
    // Start is called before the first frame update
    void Start()
    {
        rock = true;
       playerColl = GameObject.Find("Player").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOne()
    {
        if (sand == true)
        {
            sandOne.Play();
        }
        else if(water == true) { waterOne.Play(); }
        else if (rock == true) { rockOne.Play(); }


    }
    public void PlayTwo()
    {
        if (sand == true)
        {
            sandTwo.Play();
        }
        else if (water == true) { waterTwo.Play(); }
        else if(rock == true) { rockTwo.Play(); }

    }
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Water")
        {
            water = true;
            sand = false;
            rock = false;
        }
        else if (player.tag == "Ground")
        {
           sand = true;
            water = false;
            rock = false;
        }
        else if(player.tag == "Rock")
        {
            rock = true;
            water = false;
            sand = false;
        }
        
    }
    void OnTriggerStay(Collider player)
    {
        if (player.tag == "Water")
        {
            water = true;
            sand = false;
            rock = false;
        }
        else if (player.tag == "Ground")
        {
            sand = true;
            water = false;
            rock = false;
        }
        else if (player.tag == "Rock")
        {
            rock = true;
            water = false;
            sand = false;
        }
    }
}
