using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Set in Inspector")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    Renderer render;
    private int currentLane = 1;
    public bool isGrounded = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentLane > 0)
        {
            currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentLane < 2)
        {
            currentLane++;
        }

        if (Input.GetKeyDown(KeyCode.A) && currentLane < 2)
        {
            render.material.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.S) && currentLane < 2)
        {
            render.material.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            render.material.color = Color.blue;
        }

        float targetZ = (currentLane - 1) * 3;

        Vector3 targetPosition = new Vector3 (transform.position.x, transform.position.y, targetZ);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector3.up * jumpForce;
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
