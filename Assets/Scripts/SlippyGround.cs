using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlippyGround : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody == playerRB)
        {
            playerRB.sharedMaterial = slippyMat;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.rigidbody == playerRB)
        {
            playerRB.sharedMaterial = null;
        }
    }

}
