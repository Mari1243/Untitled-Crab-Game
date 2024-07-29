using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource crabHit;
    public Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Shovel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Crab")
        {
            crabHit.Play();
        }
        else if (player.tag == "Ground" && anim.GetBool("Hit") == true)
        {
            hit.Play();
            Debug.Log("hitGround");
            
        }
        
    }
}
