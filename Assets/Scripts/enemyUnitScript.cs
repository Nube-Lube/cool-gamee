using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyUnitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpd;
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
        rb.AddForce(new Vector2(moveSpd * -1, 0));
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Terrain") == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpd * 0.9f);
        }
    }
}
