using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject Fade;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void Start()
    {
        Fade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu ()
    {
        StartCoroutine(DelaySceneLoad("MainMenu"));
    }
    public void RestartGame()
    {
        StartCoroutine(DelaySceneLoad("Main"));
    }
    IEnumerator DelaySceneLoad(string scene)
    {
        Fade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }
}
