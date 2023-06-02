
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public Transform goal;
    public float speed = 5f;
    public float turnSpeed = 180f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate the angle between the bot and the goal
        Vector2 direction = goal.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Avoid obstacles by turning away from them
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 2f, LayerMask.GetMask("Obstacle"));
        if (hit.collider != null)
        {
            // Turn away from the obstacle
            angle = hit.point.x < transform.position.x ? angle + 90f : angle - 90f;
        }

        // Move towards the goal
        movement.Set(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}