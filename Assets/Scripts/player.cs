using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool isGrounded = false;
    public Vector2 velocity = Vector2.zero;
    public Vector2 acceleration = Vector2.zero;
    public GameObject fireball;
    public float lastShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Flip sprite based on direction of movement
        if (velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void FixedUpdate()
    {
        if(!isGrounded)
        {
            velocity += acceleration;
            acceleration = acceleration * 0.85f - new Vector2(0, 0.0125f);
        }

        //Horizontal movement and jumping functionality with built-in gravity code
        velocity.x = Input.GetAxisRaw("Horizontal");
        Vector3 movement = velocity;
        transform.position += 2 * Time.deltaTime * movement;

        if (Input.GetButton("Jump") && isGrounded)
        {
            acceleration.y += 0.3f;
            isGrounded = false;
        }

        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }

    }

    //shoot fireball that is rotated towards the mouse
    public void Shoot()
    {
        //Add if to check cooldown of 2s
        if(Time.time - lastShot >= 2f){
            lastShot = Time.time;
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            GameObject projectile = Instantiate(fireball, transform.position, Quaternion.Euler(0, 0, -angle));
        }
    }

}
