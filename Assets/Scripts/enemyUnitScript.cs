using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyUnitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpd, bounce, health, speed;
    public int type;
    public Rigidbody2D rb;
    private GameController gameController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        transform.position = gameController.enemyPosition.position;
        health = gameController.health[type];
        moveSpd = gameController.speed[type];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bounce *= 0.93f;
        bounce = Mathf.Clamp(bounce, -64, 0);
        rb.velocity = new Vector2(moveSpd * -1 - bounce, rb.velocity.y);
    }
    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Terrain") == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpd * 1.5f);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("unit") == true)
        {
            bounce -= moveSpd * 2;
            rb.velocity = new Vector2(moveSpd * 0.5f, rb.velocity.y + moveSpd * 0.5f);
            //attack enemy and take damage
            health--;
        }
    }
}
