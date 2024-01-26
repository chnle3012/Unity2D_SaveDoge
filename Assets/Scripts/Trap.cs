using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private AudioSource deathSound;

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

    private void OnTriggerEnter2D(Collider2D other) {
        deathSound.Play();
    }
}
