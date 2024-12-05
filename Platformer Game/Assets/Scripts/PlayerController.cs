using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //Movement Variables
    Rigidbody2D rb;
    public float jumpForce;
    public float speed;

    // Ground check
    public bool isGrounded;

    public GameManager gm;

    //Animation variables
    Animator anim;
    public bool moving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        //variables to mirror the player
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x); //take absolute value of the current x scale, this is always positive


        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
            moving = true;
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
            moving = true;
        }
        if (Input.GetKey("w") && isGrounded || Input.GetKey(KeyCode.UpArrow) && isGrounded) 
        {
            // velocity is a vector 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d") || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            moving = false;
        }
       
        anim.SetBool("IsMoving", moving);
        transform.position = newPosition;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("i hit the ground");
            isGrounded = true;
        }
        if (collision.gameObject.tag.Equals("Coin"))
        {
            //score goes up. ++ means add 1
            gm.score++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("VictoryFloor"))
        {
            Debug.Log("change scene");
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.tag.Equals("ShooterBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }
    }
   
}
