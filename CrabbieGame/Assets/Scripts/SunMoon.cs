using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SunMoon : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public AudioSource typeAS;
    public GameObject Fade;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        Fade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCo()
    {
        StartCoroutine(TypeText("Night One: Full Moon"));
    }
    IEnumerator TypeText(string textToType)
    {
       
        textBox.text = string.Empty;


        for (int i = 0; i < textToType.Length; i++)
        {
            textBox.text += textToType[i];
            typeAS.Play();
            yield return new WaitForSeconds(0.06f);
        }

        





    }
    IEnumerator DelaySceneLoad(string scene)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }

    public void StartFade()
    {
        Fade.SetActive(true);
        StartCoroutine(DelaySceneLoad("Main"));
    }
}
