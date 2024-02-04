using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 32f;
    private bool isFacingRight = true;
    public bool isGrounded;

    [SerializeField] private Rigidbody2D rb;


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            //StartCoroutine(Jump());
        }

        //if (Input.GetKey(KeyCode.W) && rb.velocity.y > 0f)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }




    // Check when object touches "Floor"
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    // Check when object exits "Floor"
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
/*
    IEnumerator Jump()
    {
        // Calculate the additional velocity needed for a consistent jump
        float additionalVelocity = Mathf.Sqrt(2f * jumpingPower * Mathf.Abs(Physics2D.gravity.y));

        // Apply the additional velocity using ForceMode.VelocityChange for the jump
        rb.velocity = new Vector2(rb.velocity.x, additionalVelocity);

        // Wait for a short duration (you can adjust this based on your needs)
        yield return new WaitForSeconds(0.5f);

        // Simulate a more realistic fall by gradually increasing gravity effect
        float initialGravity = Physics2D.gravity.y;
        float timer = 0f;

        while (rb.velocity.y > 0)
        {
            timer += Time.deltaTime;

            // Gradually increase the effect of gravity
            float fallMultiplier = 30f; // Adjust this multiplier for the desired fall speed
            float increasedGravity = initialGravity * fallMultiplier;
            rb.velocity += Vector2.up * increasedGravity * timer * Time.deltaTime;

            yield return null;
        }*/
    }


    

