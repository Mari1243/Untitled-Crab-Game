using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudios : MonoBehaviour
{
    public AudioSource hover;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HoverPLay()
    {
        hover.Play();
    }
    public void ClickPLay() { click.Play(); }
}
