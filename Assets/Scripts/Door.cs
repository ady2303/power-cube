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
    public SpriteRenderer signal;


    private void Awake()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ForceField")
        {
            //Debug.Log("test");
            //transform.position = Vector3.MoveTowards(transform.position, openPos.position, step);
            //rb.AddForce(transform.up * step, ForceMode2D.Impulse);
            //signal.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ForceField")
        {
            rb.AddForce(transform.up * step, ForceMode2D.Impulse);
            signal.color = Color.green;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ForceField")
        {
            signal.color = Color.red;
        }
    }
}
