using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyUnitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpd, health, speed;
    public Rigidbody2D rb;
    private GameController gameController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        transform.position = gameController.enemyPosition.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpd * -1, rb.velocity.y);
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
            //attack enemy and take damage
            health--;
        }
    }
}
