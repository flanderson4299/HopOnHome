using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startPos, height, startPosY;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float parallaxEffect;
    [SerializeField]
    private float parallaxY;

    public float StartPosY
    {
        set { startPosY = value; }
    }

    public float StartPosX
    {
        set { startPos = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        startPosY = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        float tempY = (cam.transform.position.y * (1 - parallaxY));
        float distY = (cam.transform.position.y * parallaxY);

        transform.position = new Vector3(startPos + dist, startPosY + distY, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;

        if (tempY > startPosY + height) startPosY += height;
        else if (tempY < startPosY - height) startPosY -= height;
    }
}
