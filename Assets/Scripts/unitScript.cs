using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class unitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpd, bounce, health;
    public int typ;
    private GameController gameController;
    public Rigidbody2D rb;
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        health = gameController.health[typ] * gameController.healthStat;
        moveSpd = gameController.speed[typ] * gameController.speedStat;
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
        bounce *= 0.93f;
        bounce = Mathf.Clamp(bounce, -64, 0);
        rb.velocity = new Vector2(moveSpd + bounce, rb.velocity.y);
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
            bounce -= moveSpd * 2f;
            rb.velocity = new Vector2(0, rb.velocity.y + moveSpd * 0.5f);
            //attack enemy and take damage
            health--;
        }
    }
}
