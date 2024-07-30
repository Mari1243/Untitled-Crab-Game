using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject Fade;
   
    void Start()
    {
        Fade.SetActive(false);
    }
    public void PlayGame()
    {
        StartCoroutine(DelaySceneLoad("LevelONE"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator DelaySceneLoad(string scene)
    {
        Fade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }
    
}
