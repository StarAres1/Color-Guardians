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
    public GameObject platform;

    private void Awake()
    {        
        GameManager.getInstance().setCommand(new PaintSkyCommand());
        GameManager.getInstance().setCommand(new PaintGroundCommand(platform.GetComponent<Platform>()));
    }

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

        if (Input.GetKeyDown(KeyCode.A))
        {
            render.material.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            render.material.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            render.material.color = Color.blue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector3.up * jumpForce;
            isGrounded = false;
        }

        float targetZ = (currentLane - 1) * 3;

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
