using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public Sprite front;
    public Sprite left;
    public Sprite right;
    public Sprite back;

    public float moveSpeed;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (movement.y > 0)
        {
            spriteRenderer.sprite = back;
        }
        else if (movement.y < 0)
        {
            spriteRenderer.sprite = front;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.sprite = right;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.sprite = left;
        }

        rigidbody2d.MovePosition(rigidbody2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}