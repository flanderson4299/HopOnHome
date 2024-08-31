using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField]
    private GameObject mark;
    [SerializeField]
    private AudioSource sfx;
    private bool played;
    // Start is called before the first frame update
    void Start()
    {
        mark.SetActive(false);
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        mark.SetActive(true);
        if (!played)
        {
            sfx.Play();
            played = true;
        }
        
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        mark.SetActive(false);
        played = false;
    }
}
