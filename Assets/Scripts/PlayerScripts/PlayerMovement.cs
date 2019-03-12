using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float translation;
    private float straffe;
    public float rotationRate;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Input.GetAxis() is used to get the user's input
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);


        // Control Player Rotation
        // Get arrow key input and rotates accordingly
        float horizontalTurn = Input.GetAxis("HorizontalLook");
        Vector3 rotation = new Vector3(0.0f, horizontalTurn, 0.0f);
        rb.angularVelocity = rotation * rotationRate;
        
    }

}
