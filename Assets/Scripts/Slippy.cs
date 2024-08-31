using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slippy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRB;
    [SerializeField]
    private PhysicsMaterial2D slippyMat;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //prevents getting stuck on a platform that you can't jump on
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.rigidbody == playerRB)
        {

            if(playerRB.velocity.x > -0.2 && playerRB.velocity.x < 0.2 && playerRB.velocity.y > -0.2 && playerRB.velocity.y < 0.2)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x + 10, playerRB.velocity.y);
            }
            
        }
    }
}
