using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private Sprite oldbg1;
    [SerializeField]
    private Sprite oldbg2;
    [SerializeField]
    private Sprite oldbg3;
    [SerializeField]
    private Sprite oldbg4;
    [SerializeField]
    private Sprite oldbg5;
    [SerializeField]
    private Sprite oldbg6;

    [SerializeField]
    private string location;

    [SerializeField]
    private Rigidbody2D player;
    [SerializeField]
    private Player mainp;


    private Sprite[] sprites;
    private Sprite[] oldSprites;

    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private Color seasonColor;

    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private AudioClip newSong;

    // Start is called before the first frame update
    void Start()
    {

        oldSprites = new Sprite[6];


        oldSprites[0] = oldbg1;
        oldSprites[1] = oldbg2;
        oldSprites[2] = oldbg3;
        if (oldbg4 != null)
        {
            oldSprites[3] = oldbg4;
        }
        if (oldbg5 != null)
        {
            oldSprites[4] = oldbg5;
        }
        if (oldbg6 != null)
        {
            oldSprites[5] = oldbg6;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        //changes parallax background layers and landing particle colors depending on which section the player is in
            if (collider.tag == "Player")
            {
                for (int i = 0; i < 6; i++)
                {
              
                        background.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = oldSprites[i];
                        foreach (Transform childTransform in background.transform.GetChild(i).transform)
                        {

                            childTransform.GetComponent<SpriteRenderer>().sprite = oldSprites[i];
                        }

                    
                }

            }
            ParticleSystem.MainModule ma = particles.main;
            ma.startColor = seasonColor;      

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(mainp.Location != this.location)
        {
            music.clip = newSong;
            music.Play();
            mainp.Location = this.location;
        }
        
    }

}
