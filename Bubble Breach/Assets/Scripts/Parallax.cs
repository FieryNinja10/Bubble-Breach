using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, width, startPosX, startPosY;
    public GameObject cam;

    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        width = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.position = new Vector3(startPosX, startPosY, transform.position.z);

        if (cam.transform.position.x > startPosX + length) startPosX += length;
        else if (cam.transform.position.x < startPosX - length) startPosX -= length;

        if (cam.transform.position.y > startPosY + width) startPosY += width;
        else if (cam.transform.position.y < startPosY - width) startPosY -= width;
    }
}
