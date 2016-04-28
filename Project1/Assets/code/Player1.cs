using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {


    public float speed = 10f;

  
        void Update()
        {
            InputMovement();
        }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.up * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.up * speed * Time.deltaTime);
    }
    }