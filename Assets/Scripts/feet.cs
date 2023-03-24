using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet : MonoBehaviour
{
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            player.isGrounded = true;
            player.acceleration = Vector2.zero;
            player.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            player.isGrounded = false;
        }
    }
}
