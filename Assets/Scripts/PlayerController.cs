using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontal_dir;
    public float speed;

    public float jump_force;
    public float fall_multiplier = 2.5f; //to set gravity to 2.5x when falling
    public float short_jump_multiplier = 2f; //to set gravity to 2x for short jump

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_dir = Input.GetAxisRaw("Horizontal");
        jump();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal_dir * speed, rb.velocity.y);
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jump_force;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fall_multiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (short_jump_multiplier - 1) * Time.deltaTime;
        }
    }
}
