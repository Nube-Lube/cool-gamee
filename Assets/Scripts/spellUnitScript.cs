using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellUnitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpd, health;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(new Vector2(moveSpd, 0));
        //rb.velocity = new Vector2(moveSpd, rb.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Terrain") == true)
        {
            Destroy(gameObject);
        }
    }
}
