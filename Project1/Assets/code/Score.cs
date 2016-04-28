﻿using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    public TextMesh curSco;
    public GameObject ballPref;
    public float diff; 

    GameObject ball;
    int score;

    void Update()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        curSco.text = "" + score;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            score += 1;
            Destroy(ball);

            ball= (Instantiate(ballPref, new Vector3(0, 0, 0), Quaternion.identity) as GameObject);
        }
    }

}