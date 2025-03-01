using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class unitScript : MonoBehaviour
{
    // Start is called before the first frame
    public float moveSpd, bounce, health, mass;
    private bool ko;
    private SpriteRenderer sprite;
    public int typ;
    private Color defaultColor;
    private GameController gameController;
    public Rigidbody2D rb;
    private CapsuleCollider2D capCollider;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        capCollider = GetComponent<CapsuleCollider2D>();
        capCollider.offset = gameController.unitShapes[typ].offset;
        capCollider.size = gameController.unitShapes[typ].size;
        transform.position = gameController.unitPosition.position;
        transform.localScale = gameController.unitPosition.localScale * 1.5f;
        rb = GetComponent<Rigidbody2D>();
        health = gameController.health[typ] * gameController.healthStat;
        moveSpd = gameController.speed[typ] * gameController.speedStat;
        mass = gameController.mass[typ];
        rb.mass = mass;
        ko = false;
        rb.velocity = gameController.unitPosition.transform.right * moveSpd * 3;
        if (typ == 2)
        {
            rb.drag = 0.4f;
            rb.gravityScale = 0f;
        }
    }

    void Update()
    {
        if (health < 1 && !ko)
        {
            OnDeath();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!ko)
        {
            sprite.color = Color.Lerp(sprite.color, defaultColor, 0.8f);
            //rb.AddForce(new Vector2(moveSpd, 0));
            bounce *= 0.93f;
            bounce = Mathf.Clamp(bounce, -64, 0);
            if (typ == 2)
                rb.velocity = new Vector2(moveSpd / ((transform.position.y + 170) / 85) + bounce, Mathf.Clamp(rb.velocity.y, -50, 50));
            else
                rb.velocity = new Vector2(moveSpd + bounce, rb.velocity.y);
        }
        else if (transform.position.y < -120)
        {
            Destroy(gameObject);
        }    
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
            sprite.color = Color.Lerp(sprite.color, new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0), 0.95f);
            bounce -= moveSpd * 2f / mass;
            if (Mathf.Abs(rb.velocity.y) < 75)
                rb.velocity = new Vector2(0, rb.velocity.y * 0.5f + moveSpd * 0.6f / mass);
            //attack enemy and take damage
            health--;
        }
    }

    private void OnDeath()
    {
        ko = true;
        foreach (Collider2D c in gameObject.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f, 0.6f);
        rb.velocity = new Vector2(Random.value * 25 - 45, Random.value * 25 + 50);
        rb.gravityScale = 20;
        rb.freezeRotation = false;
        rb.angularVelocity = Random.value * 150 - 75;
    }
}
