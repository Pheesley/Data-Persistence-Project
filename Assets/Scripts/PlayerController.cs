using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rigidbody component so Boat can interact with physical objects

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float turnSpeed = 5;
    private float horizontalInput;
    private float verticalInput;
    private float xBound = 9;
    private float zBound = 9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        //two ways to do if statements
        //prevents player from going outside the Water Plane
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        if (transform.position.z < -zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
    }
}
