using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float horizontalThrust = 10000f;
    public float verticalThrust = 10000f;

    public float shipMass = 1f;
    public float drag = 1f;
    public float maxDrag = 30f;
    public float maxSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Import rigidbody component from the Ship
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called every x amount of time (Unity suggests to use it when working with rigidbodies)
    void FixedUpdate()
    {
        // Get player input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // compute force vector and apply it to the Ship
        Vector2 force = new Vector2(horizontalThrust * horizontal * Time.deltaTime, verticalThrust * vertical * Time.deltaTime);

        // modify rigidbody properties
        rigidbody2d.AddForce(force);
        rigidbody2d.mass = shipMass;
        rigidbody2d.drag = drag;

        // increase drag when the Ship's speed is over maxSpeed
        if (rigidbody2d.velocity.magnitude > maxSpeed)
        {
            rigidbody2d.drag = maxDrag;
        }

        if (force.magnitude == 0 && rigidbody2d.velocity.magnitude != 0)
        {
            rigidbody2d.drag = maxDrag/2;
        }
    }
}
