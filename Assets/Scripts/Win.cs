using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField]
    private GameObject award;
    [SerializeField]
    private AudioSource sfx;
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private AudioClip winning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        //awards the player with a coin when colliding with the finish area
        if(collider.tag == "Player")
        {
            award.SetActive(true);
            sfx.Play();
            music.clip = winning;
            music.Play();
        }
    }
}
