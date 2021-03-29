using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    [SerializeField] private float horsePower = 0f;
    [SerializeField] private GameObject centerOfMassObject;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMassObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (isOnGround())
        {
            // Move the vehicle forward based on vertical input
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            // Rotates the vehicle based on horizontal input
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            rpm = Mathf.Round((speed % 30) * 40);

            speedometerText.SetText("Speed: " + speed + "Mph");
            rpmText.SetText("RPM: " + rpm);
        }
    }

    private bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }

        else
        {
            return false;
        }


    }
}
