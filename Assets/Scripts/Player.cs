using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool facingRight;
    [SerializeField] private float moveSpeed;
    [SerializeField] private AudioSource fruitSound;
    Rigidbody2D rb;
    public static bool isDead;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(!ButtonController.isClick)
        {
            Move();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }

    private void Move()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPos.y >= -3.5f)
            {
                if((touchPos.x < 0 && facingRight) || (touchPos.x > 0 && !facingRight))
                {
                    Flip();
                }

                if(touchPos.x < 0)
                {
                    rb.velocity = new Vector2(-moveSpeed * GameManager.speedRate, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(moveSpeed * GameManager.speedRate, rb.velocity.y);
                }
            }
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            isDead = true; 
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Fruit"))
        {
            fruitSound.Play();
            GameManager.score++;
            Destroy(collision.gameObject);
        }
    }
}
