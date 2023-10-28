using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float speedForce;
    bool canJump = false;
    Vector2 direction;
    public GameObject PlayerUnmoving;
    public GameObject PlayerMoving;
    

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            movementHandling();      
    }

    private void movementHandling()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Set the direction based on the input.
        direction = new Vector2(horizontalInput * speedForce, rigidbody2d.velocity.y);

        // Apply the direction to the rigidbody.
        rigidbody2d.velocity = direction;
    } 

    void OnCollisionStay2D(Collision2D collision)
    {
        PlayerUnmoving.SetActive(true);
        PlayerMoving.SetActive(false);

        // Check if the player is in contact with a floor or platform.
        if (collision.gameObject.CompareTag("Obstacle")) // Assuming you've tagged your ground objects as "Ground."
        {
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rigidbody2d.velocity = new Vector2(0.0f, speedForce);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        PlayerMoving?.SetActive(true);
        PlayerUnmoving.SetActive(false);
        // Reset the flag when the player is no longer in contact with a floor or platform.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            canJump = false;
        }
    }
}
