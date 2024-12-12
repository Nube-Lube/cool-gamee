using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spellUnitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController gameController;
    public float moveSpd, health;
    public Rigidbody2D rb;
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        transform.position = gameController.spellPosition.position;
        transform.Translate(new Vector3(0, 120, 0));
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(new Vector2(moveSpd, 0));
        rb.velocity += new Vector2(0, -0);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Terrain") == true)
        {
            Destroy(gameObject);
        }
    }
}
