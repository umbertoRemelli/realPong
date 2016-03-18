﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1;
    public Vector3 playerPos;

    void Update()
    {
        float yPos = transform.position.y + (Input.GetAxis("Vertical") * paddleSpeed);
        playerPos = new Vector3(-10, Mathf.Clamp(yPos, -4.5F, 4.5F), 0);
        transform.position = playerPos;
    }
}