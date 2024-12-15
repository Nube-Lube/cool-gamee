using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellPlaceScript : MonoBehaviour
{
    public GameController gameController;
    public Vector2 playerMouse;
    public float movementSpd, controlSpd;
    public Rigidbody2D rb;
    public Vector2 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (!gameController.paused)
        {
            moveVector *= 0.9f;
            transform.position = new Vector2(transform.position.x, 80);

            if (Input.GetKeyDown(KeyCode.Slash))
            {
                gameController.trySpell(playerMouse.x, playerMouse.y, transform);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVector += new Vector2(0, 1);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveVector += new Vector2(-1, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveVector += new Vector2(0, -1);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveVector += new Vector2(1, 0);
            }
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity *= 0.9f;
        rb.AddForce(moveVector * Time.deltaTime * controlSpd);
    }
}
