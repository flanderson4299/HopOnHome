using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private bool grounded;

    private Vector3 mousePos;

    [SerializeField]
    private LineRenderer line;

    [SerializeField]
    public Camera cam;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Text percentText;
    private float percent;

    private ParticleSystem particles;

    [SerializeField]
    private AudioSource jump;
    [SerializeField]
    private AudioSource land;

    private string location;
    public string Location
    {
        get { return location; }
        set { location = value; }
    }

    [SerializeField]
    public Pause pause;

    
    // Start is called before the first frame update
    void Start()
    {

        location = "Spring";
        grounded = true;
        particles = GetComponent<ParticleSystem>();

    }

    
    void Update()
    {
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //sets a max distance the line renders to from the player (max jump velocity)
        Vector2 distance = mousePos - this.transform.position;
        if(distance.magnitude > 10)
        {
            distance = distance.normalized * 10;
        }

        line.SetPosition(1, distance);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.PauseGame();
        }

        if (grounded)
        {
            if (Input.GetMouseButtonDown(0))
            {

                animator.SetBool("grounded", false);

                Vector3 dif = mousePos - this.transform.position;
                float xMax = 15f;
                float yMax = 9f;
                float veloMax = 25f;
                float newX = dif.x / xMax * veloMax;
                float newY = dif.y / yMax * veloMax;
                
                //sets jump velocity based on mouse position
                if (dif.x > xMax)
                {
                    newX = veloMax;
                }
                else if (dif.x < -xMax)
                {
                    newX = -veloMax;
                }
                if (dif.y > yMax)
                {
                    newY = veloMax;
                }
                Vector2 newVelo = new Vector2(newX, newY);

                
                this.GetComponent<Rigidbody2D>().velocity = newVelo;

                if(newVelo.y > 0)
                {
                    jump.Play();
                }
                
            }
            
            animator.SetFloat("yVelo", this.GetComponent<Rigidbody2D>().velocity.y);
            
        }
        //slows decent if falling for long enough
        if (this.GetComponent<Rigidbody2D>().velocity.y < -40)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 40), ForceMode2D.Impulse);
        }
 
        percent = (this.GetComponent<Rigidbody2D>().position.y / 275) * 100;

        percentText.text = Mathf.Round(percent) + "%";
  
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            grounded = false;
            animator.SetBool("grounded", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.tag == "Ground")
        {
            grounded = true;
            animator.SetBool("grounded", true);
        }

        if(this.GetComponent<Rigidbody2D>().velocity.y < -25)
        {
            particles.Play();
            land.Play();
        }
        
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            grounded = true;
            animator.SetBool("grounded", true);
        }

        particles.Stop();

    }
}
