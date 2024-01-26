using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.y < -5f){
            Destroy(gameObject);
        }
        
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(rb.velocity.x, -speed * GameManager.speedRate);
    }
}
