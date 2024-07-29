using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Movement : MonoBehaviour
{
    public PlayerInRange range;

    public Transform target;
    public float speed = 2f;
    public Rigidbody rb;
    public Animator CrabWalk;
    public Animator shovel;

    //position
    private float distanceBetween;
    public float distance;
    private float xPos;
    private float zPos;
    public Vector3 desiredPos;

    //retreat
    public bool canMove = true;
    public float retreat = 10f;
    public bool invulnerable = false;
    public float invulnerability = 2f;

    //die
    public GameObject crab;
    public bool dead = false;
    public Animator blood;
    public bool HitPlayer = false;

    //audio
    public AudioSource walk;

    //health
    public Health health;
    

    void Awake()
    {
        
    }

    void Start()
    {
        //Vector3 desiredPos = new Vector3(xPos, transform.position.y, transform.position.z);
    }
    void Update()
    {
        
        FollowPlayer();
       
    }
    void GameOver()
    {
        print("dead");
    }
    void FollowPlayer()
    {
       


       if (canMove == true)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rb.MovePosition(pos);
            transform.LookAt(target);
        }
      
       else if (dead == false)
        {
            Vector3 playerDirection = target.position - transform.position;
            Vector3 oppositeDirection = transform.position - playerDirection;
            Vector3 pos = Vector3.MoveTowards(transform.position, oppositeDirection, speed * Time.deltaTime);

            rb.MovePosition(pos);
            transform.LookAt(target);
            
        }
      
        

    }
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "HITPLAYER")
        {
                health.playerHealth = health.playerHealth - health.damage;
                blood.SetBool("Hit", true);
                StartCoroutine(RunAwayFast());
            
           

        }

        else if (player.tag == "ShovelHit")
        {
            StartCoroutine(Die());
        }

    }

    void OnTriggerStay(Collider player)
    {
        
        if (player.tag == "Light" && !invulnerable)
        {
            StartCoroutine(RunAway());
        }
       


    }

    IEnumerator RunAway()
    {
        CrabWalk.SetBool("Retreat", true);
        canMove = false;
        invulnerable = true;
        yield return new WaitForSeconds(retreat);
        CrabWalk.SetBool("Retreat", false);
        canMove = true;
        yield return new WaitForSeconds(invulnerability);
        invulnerable = false;
        


    }
    IEnumerator RunAwayFast()
    {
        CrabWalk.SetBool("Retreat", true);
        canMove = false;
        yield return new WaitForSeconds(0.5f);
        blood.SetBool("Hit", false);
        yield return new WaitForSeconds(1f);
        crab.SetActive(false);

    }
 
    IEnumerator Die()
    {
        health.killcount++;
        canMove = false;
        dead = true;
        CrabWalk.SetBool("Die", true);
        yield return new WaitForSeconds(0.5f);
        crab.SetActive(false);
    }
    
    public void PlayAS()
    {
        walk.Play();
    }
}