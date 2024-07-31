using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Flashlight : MonoBehaviour
{
    
    public GameObject flashOne;
    public GameObject flashTwo;
    public GameObject flashThree;
    public GameObject flashFour;
    public GameObject Flashlightt;

    public Animator Flashes;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


        if(Flashlightt.activeInHierarchy)
        {
            StartCoroutine(Battery());
        }

    }
    IEnumerator Battery()
    {

        yield return new WaitForSeconds(20f);
        Flashes.SetBool("flashOne", true);
        yield return new WaitForSeconds(20f);
        Flashes.SetBool("flashTwo", true);
        yield return new WaitForSeconds(20f);
        Flashes.SetBool("flashThree", true);
        yield return new WaitForSeconds(20f);
        Flashes.SetBool("flashFour", true);

    }
   
}

