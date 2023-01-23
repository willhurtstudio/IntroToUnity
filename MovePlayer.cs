using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    Vector3 inputDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = Vector3.zero;
        if (Input.GetKey("a"))
        {
            inputDirection += Vector3.left;
        }
        if (Input.GetKey("d"))
        {
            inputDirection += Vector3.right;
        }
        if (Input.GetKey("w"))
        {
            inputDirection += Vector3.forward;
        }
        if (Input.GetKey("s"))
        {
            inputDirection += Vector3.back; 
        }

        Move(inputDirection);
    }


    void Move(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
    }


}
