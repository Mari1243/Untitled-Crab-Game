using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //kill count
    public TextMeshProUGUI killCount;
    public int killcount = 0;

    //health
    public int holesCovered = 0;
    public int playerHealth = 100;
    public int damage = 5;
    public int lowHealth = 15;
    public Slider healthBar;
    public GameObject bloodLow;


    // Start is called before the first frame update
    void Start()
    {
        bloodLow.SetActive(false);
        healthBar.maxValue = 100;
        healthBar.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        healthBar.value = playerHealth;
        killCount.text = killcount.ToString();
        if (healthBar.value == 0)
        {
            PlayerPrefs.SetInt("crabsKilled", killcount);
            PlayerPrefs.SetInt("holesCovered", holesCovered);
            StartCoroutine(DelaySceneLoad("Dead"));
        }

        else if (playerHealth < lowHealth)
        {
            bloodLow.SetActive(true);
        }

       

        
    }
    IEnumerator DelaySceneLoad(string scene)
    {
       
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(scene);
    }

}
