using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellPlaceScript : MonoBehaviour
{
    public GameController gameController;
    public Vector2 playerMouse;
    public float movementSpd, controlSpd;
    public Rigidbody2D rb;
    public int keys;
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
            if (Input.GetKeyDown(KeyCode.Slash))
            {
                gameController.trySpell(transform);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                keys = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                keys = 1;
            }
            else
            {
                keys = 0;
            }
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moveVector *= 0.9f;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -150, 150), 80);
        rb.velocity *= 0.9f;
        rb.AddForce(moveVector * Time.deltaTime * controlSpd);
        if (keys == -1)
        {
            moveVector += new Vector2(-1, 0);
        }
        else if (keys == 1)
        {
            moveVector += new Vector2(1, 0);
        }
    }
}
