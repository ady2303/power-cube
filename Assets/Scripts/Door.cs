using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Door : MonoBehaviour
{
    public float step;
    public Transform openPos;
    public Transform closePos;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ForceField")
        {
            //transform.position = Vector3.MoveTowards(transform.position, openPos.position, step);
            rb.AddForce(transform.up * step, ForceMode2D.Impulse);
        }
    }
}
