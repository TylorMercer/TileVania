using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D myRidgidbody;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        myRidgidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    //Need to update the bullet to be something new.
    void Update()
    {
        myRidgidbody.velocity = new Vector2(xSpeed,0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
