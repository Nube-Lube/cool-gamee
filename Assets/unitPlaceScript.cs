using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitPlaceScript : MonoBehaviour
{
    public GameController gameController;
    public Vector2 playerMouse;
    public float movementSpd, controlSpd;
    public Rigidbody2D rb;
    public bool isPlayer1;
    public Vector2 moveVector;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        moveVector *= 0.9f;
        switch (isPlayer1)
        {
            case true:
                transform.position = new Vector2(-200, transform.position.y);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    gameController.tryPlace(playerMouse.x, playerMouse.y, transform);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    moveVector += new Vector2(0, 1);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    moveVector += new Vector2(-1, 0);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    moveVector += new Vector2(0, -1);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    moveVector += new Vector2(1, 0);
                }
                break;

            case false:
                transform.position = new Vector2(-220, transform.position.y);

                if (Input.GetKeyDown(KeyCode.Slash))
                {
                    gameController.tryPlace(playerMouse.x, playerMouse.y, transform);
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
                break;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity *= 0.9f;
        rb.AddForce(moveVector * Time.deltaTime * controlSpd);
    }
}
