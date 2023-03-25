using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 0.04f;
    player Player;

    // Start is called before the first frame update
    void Start()
    {
        //grab object of type player from scene
        Player = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per physics update
    void FixedUpdate()
    {
        //Move forwards based on rotation
        transform.position += transform.up * speed;
    }

    //Destroy object on collision with 9
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Add velocity to player based on distance from projectile
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        if(distance < 2.5f)
            Player.velocity += (Vector2)(Player.transform.position - transform.position) * 3f;
        Destroy(this.gameObject);
    }
}
