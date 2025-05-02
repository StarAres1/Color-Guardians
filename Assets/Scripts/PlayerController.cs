using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Set in Inspector")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody rb;
    public Renderer render;
    public int currentLane = 1;
    public GameObject platform;

    private State state;

    private void Awake()
    {        
        GameManager.getInstance().setCommand(new PaintSkyCommand());
        GameManager.getInstance().setCommand(new PaintGroundCommand(platform.GetComponent<Platform>()));
        state = new State();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        state.HandleMovement(this);
        state.HandleJump(this);
        state.HandleColorChange(this);    

        float targetZ = (currentLane - 1) * 3;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ChangeState(new State());
        }
    }

    public void ChangeState(State newState)
    {
        state = newState;
    }
}
