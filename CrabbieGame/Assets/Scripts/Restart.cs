using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Restart : MonoBehaviour
{
    public GameObject Fade;
    public TextMeshProUGUI holesText;
    public TextMeshProUGUI killsText;
    private int holes;
    private int killCount;

    // Start is called before the first frame update
    void Awake()
    {
        killCount = PlayerPrefs.GetInt("crabsKilled");
        holes = PlayerPrefs.GetInt("holesCovered");
        Cursor.lockState = CursorLockMode.None;
    }
    void Start()
    {
        Fade.SetActive(false);
        holesText.text = holes.ToString() + "/10 Holes Covered";
        killsText.text = killCount.ToString() + " Crabs Killed";
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
