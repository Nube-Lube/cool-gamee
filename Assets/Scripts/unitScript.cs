using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpd, health;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(new Vector2(moveSpd, 0));
        rb.velocity = new Vector2(moveSpd, rb.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Terrain") == true)
        {
            //jump if hit terrain
            rb.velocity = new Vector2(rb.velocity.x, moveSpd * 1.5f);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("enemyUnit") == true)
        {
            rb.velocity = new Vector2(moveSpd * -0.5f, rb.velocity.y + moveSpd * 0.5f);
            //attack enemy and take damage
            health--;
        }
    }
}
