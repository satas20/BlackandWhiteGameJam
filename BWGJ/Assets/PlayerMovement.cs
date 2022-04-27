using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform spwanpoint;
    public Rigidbody2D rb;
    private GameObject button;
    public float jumpForce = 3;
    public float playerSpeed = 3;
    [SerializeField]
    private bool grounded = true;
    private bool crouched = false;
    private bool jumped = false;
    AudioSource audio;
    public int jumpCount = 1;

    // Start is called before the first frame update
    void Start()
    {
       audio= gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            jump();
            crouched = false;


        }
    }
    private void FixedUpdate()
    {
        move();
    }

    void move()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * playerSpeed;


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            crouch();
        }
    }
    void jump()
    {
        if (jumpCount > 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;

            jumpCount--;
            audio.Play();


            

        }

    }
    void crouch()
    {

        if (!crouched)
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                crouched = true;
            }

        }

        if (rb.velocity.y > -8)
        {
            rb.velocity -= new Vector2(0, 30) * Time.deltaTime;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
            crouched = false;
            jumpCount = 2;

        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            transform.position = spwanpoint.position;
            DoorScript.clicked = false;
            if (button != null) 
            {
                button.gameObject.active = true;
            }

        }
        if (collision.gameObject.CompareTag("button"))
        {
            button = collision.gameObject;
            collision.gameObject.active = false;
            DoorScriptreverse.clicked = true;
            DoorScript.clicked = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumpCount = 2;
            grounded = true;
            crouched = false;
        }
    }
}
