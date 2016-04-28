using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
{


    public float speed = 10f;


    void Update()
    {
        InputMovement();
    }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.K))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.up * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.M))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.up * speed * Time.deltaTime);
    }
}