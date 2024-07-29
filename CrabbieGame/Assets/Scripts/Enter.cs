using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enter : MonoBehaviour
{
    public GameObject block;



    public GameObject spawner;
    public GameObject spawner1;
    public GameObject spawner11;
    public GameObject spawner111;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner22;
    public GameObject spawnerFour;
    public GameObject spawnerThree;
    public TextMeshProUGUI subtitle;

    public GameObject flashlight;
    public GameObject shovel;
    public GameObject shovelOne;

    public AudioSource flashAS;
    public AudioSource shovelAS;

    //checks
    private bool hasFlashlight = false;
    public bool hasShovel = false;
    private bool hasSpawner = false;
    public Animator anim;
    private bool seeMoon = false;
    private bool seeShovel = false;
    public bool pickUp;





    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Dialogue").GetComponent<Animator>();
        spawner.SetActive(false);
        spawner2.SetActive(false);
        subtitle.text = "";
        flashlight.SetActive(false);
        shovel.SetActive(false);
        hasShovel = false;
        spawnerThree.SetActive(false);
        spawnerFour.SetActive(false);
        spawner22.SetActive(false);
        spawner3.SetActive(false);
        spawner.SetActive(false);
        spawner1.SetActive(false);
        spawner11.SetActive(false);
        spawner111.SetActive(false);
    
}

    // Update is called once per frame
    void Update()
    {
        if (pickUp == true && Input.GetKeyDown(KeyCode.E) && shovelOne.activeInHierarchy)
        {

            StartCoroutine(TypeText("I'm going to need this."));
            hasShovel = true;
            shovelAS.Play();
            shovel.SetActive(true);
            shovelOne.SetActive(false);
            //StartCoroutine(TypeText("I'm going to need this."));
        }

        if (shovel.activeInHierarchy && hasSpawner == true)
        {
            spawner.SetActive(true);
            spawner1.SetActive(true); spawner11.SetActive(true);
            spawner111.SetActive(true);
            
        }
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "DiaOne" && hasFlashlight == false)

        {

            hasFlashlight = true;
            flashAS.Play();
            flashlight.SetActive(true);
            //subtitle.text = "It's already so dark.";
            StartCoroutine(TypeText("It's already so dark"));
        }
        else if (player.tag == "DiaTwo" && seeShovel == false)
        {

            seeShovel = true;
            StartCoroutine(TypeText("A shovel.."));
        }
        else if (player.tag == "DiaThree" && seeMoon == false)
        {
            StartCoroutine(TypeText(""));
            seeMoon = true;
        }
        else if (player.tag == "DiaFour" && hasShovel == false)
        {
            
            StartCoroutine(TypeText("I feel like I'm forgetting something"));
           
            //seeMoon = true;
            
        }
        else if (player.tag == "DiaFour" && hasShovel == true)
        {
            block.SetActive(false);
            
            hasSpawner = true;
        }
        else if (player.tag == "PickUp")
            {
                pickUp = true;
            }
        else if(player.tag == "Spawn2")
        {
            spawner2.SetActive(true);
            spawner22.SetActive(true);
        }
        else if (player.tag == "Spawn3")
        {
           spawner3.SetActive(true);
           
            spawnerThree.SetActive(true);
        }
        else if (player.tag == "Spawn4")
        {
           spawner4.SetActive(true);
            spawnerFour.SetActive(true);
            
        }






    }
    void OnTriggerExit(Collider player)
    {
        if (player.tag == "PickUp")
        {
            pickUp = false;
        }
    }





    IEnumerator TypeText(string textToType)
    {
        anim.SetBool("Start", true);
        subtitle.text = textToType;
        yield return new WaitForSeconds(3f);
        anim.SetBool("Start", false);
        subtitle.text = "";



    }
 
}
