using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class enemyUnitScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    private Color defaultColor;
    public float moveSpd, bounce, health, speed, mass;
    public int typ;
    public Rigidbody2D rb;
    private GameController gameController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        transform.position = gameController.enemyPosition.position;
        health = gameController.health[typ];
        moveSpd = gameController.speed[typ];
        mass = gameController.mass[typ];
        rb.mass = mass;
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sprite.color = Color.Lerp(sprite.color, defaultColor, 0.8f);
        bounce *= 0.93f;
        bounce = Mathf.Clamp(bounce, -64, 0);
        rb.velocity = new Vector2(moveSpd * -1 - bounce, rb.velocity.y);
        Debug.Log(rb.velocity.y);
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
            sprite.color = Color.Lerp(sprite.color, new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0), 0.95f);
            bounce -= moveSpd * 2 / mass;
            if (Mathf.Abs(rb.velocity.y) < 75)
                rb.velocity = new Vector2(0, rb.velocity.y * 0.5f + moveSpd * 0.6f / mass);
            //attack enemy and take damage
            health--;
        }
    }
}
