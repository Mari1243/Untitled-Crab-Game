using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawns : MonoBehaviour
{
    //covers
    

    //spawns
    public float spawnRate = 10f;
    public bool canSpawn = true;
    public GameObject crab;
    public GameObject spawner;
    private int spawnCount = 0;
    public int spawnMax = 30;

    [SerializeField]
    public GameObject holeOne;
    public GameObject holeTwo;
    public GameObject holeThree;
    public GameObject holeFour;

    public Health health;



    // Start is called before the first frame update
    void Start()
    {
        holeTwo.SetActive(false);
        holeThree.SetActive(false);
        holeFour.SetActive(false);
        InvokeRepeating("SpawnCrab", 1.0f, spawnRate);
        //spawnPosition = new Vector3(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        


    }
    void SpawnCrab()
    {
        if (canSpawn == true && !holeFour.activeInHierarchy && spawnCount < spawnMax)
        {

            Instantiate(crab, spawner.transform.position, spawner.transform.rotation);
            spawnCount ++;

        }
        
    }
   
    void OnTriggerEnter(Collider player)
    {

        if (player.tag == "ShovelHit")
        {
          
            if (holeOne.activeInHierarchy)
            {
                holeOne.SetActive(false);
                holeTwo.SetActive(true);
            }
            else if (holeTwo.activeInHierarchy)
            {
                holeTwo.SetActive(false);
                holeThree.SetActive(true);
            }
            else if (holeThree.activeInHierarchy)
            {
                health.holesCovered++;
                holeThree.SetActive(false);
                holeFour.SetActive(true);
               
            }


        }
    }
}

