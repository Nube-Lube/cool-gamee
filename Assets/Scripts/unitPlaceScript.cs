using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unitPlaceScript : MonoBehaviour
{
    public GameController gameController;
    public Vector2 playerMouse;
    public float movementSpd, controlSpd;
    public Rigidbody2D rb;
    public bool isPlayer1;
    public int keys;
    public Vector2 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            gameController.tryPlace(transform);
        }

        if (Input.GetKey(KeyCode.W))
        {
            keys = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            keys = -1;
        }
        else
        {
            keys = 0;
        }


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moveVector *= 0.9f;
        transform.position = new Vector2(-200, Mathf.Clamp(transform.position.y, -70, 0));
        if (keys == 1)
        {
            if (!(transform.position.y < 0))
            {
                if (transform.eulerAngles.z < 60)
                {
                    transform.Rotate(0, 0, 1);
                }
            } else
            {
                transform.rotation = Quaternion.identity;
                moveVector += new Vector2(0, 1);
            }
        }
        if (keys == -1)
        {
            if (!(transform.position.y < 0) && (transform.eulerAngles.z > 0))
            {
                transform.Rotate(0, 0, -1);
            } else
            {
                transform.rotation = Quaternion.identity;
                moveVector += new Vector2(0, -1);
            }
        }
        rb.velocity *= 0.9f;
        rb.AddForce(moveVector * Time.deltaTime * controlSpd);
    }
}
