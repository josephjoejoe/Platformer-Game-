using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Spike"))
        {
            Debug.Log("ive died");
            Die();
        }
    }
    void Die()
    {
        Respawn();
    }
    void Respawn()
    {
        transform.position = startPos;
    }
}
