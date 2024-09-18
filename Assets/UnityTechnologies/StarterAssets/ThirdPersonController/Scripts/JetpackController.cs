using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    public float jumpForce = 10f; // Force applied when jumping
    public float ascendSpeed = 5f; // Speed while holding jump button
    public float maxJetpackTime = 5f; // Max time to use the jetpack
    private float currentJetpackTime;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentJetpackTime = maxJetpackTime;
    }

    void Update()
    {
        // Check if grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Jetpack control
        if (Input.GetButton("Jump") && currentJetpackTime > 0)
        {
            ActivateJetpack();
        }

        // Recharge jetpack over time
        if (currentJetpackTime < maxJetpackTime && !Input.GetButton("Jump"))
        {
            currentJetpackTime += Time.deltaTime; // Adjust recharge rate if needed
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        currentJetpackTime = maxJetpackTime; // Reset jetpack time after jump
    }

    void ActivateJetpack()
    {
        rb.velocity = new Vector3(rb.velocity.x, ascendSpeed, rb.velocity.z);
        currentJetpackTime -= Time.deltaTime; // Decrease jetpack time
    }
}
