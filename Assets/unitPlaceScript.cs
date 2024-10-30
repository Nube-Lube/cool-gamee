using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitPlaceScript : MonoBehaviour
{
    public GameController gameController;
    public Vector2 playerMouse;
    public CapsuleCollider capCollider;
    public float movementSpeed;
    public Rigidbody2D rb;
    public bool isPlayer1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity *= 0.9f;
        switch (isPlayer1)
        {
            case true:
                if (Input.GetKey(KeyCode.F))
                {
                    gameController.tryPlace1(playerMouse.x, playerMouse.y);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    rb.AddForce(new Vector2(0, 1));
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(new Vector2(-1, 0));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.AddForce(new Vector2(0, -1));
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(new Vector2(1, 0));
                }
                break;

            case false:
                if (Input.GetKeyDown(KeyCode.Slash))
                {
                    gameController.tryPlace2(playerMouse.x, playerMouse.y);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddForce(new Vector2(0, 1));
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.AddForce(new Vector2(-1, 0));
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce(new Vector2(0, -1));
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.AddForce(new Vector2(1, 0));
                }
                break;
        }

        if (!isPlayer1 && Input.GetKeyDown(KeyCode.Slash))
        {
            gameController.tryPlace2(playerMouse.x, playerMouse.y);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("unit"))
            Physics.IgnoreCollision(other.collider, capCollider);
    }
}
