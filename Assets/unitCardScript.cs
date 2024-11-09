using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class unitCardScript : MonoBehaviour
{
    public GameController gameController;
    private RectTransform rectTransform;
    private bool stopped;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        rectTransform = GetComponent<RectTransform>();
        gameController.cards.Add(gameObject);
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (rectTransform.position.x > 190)
            rectTransform.position = new Vector2(190, rectTransform.position.y);
        else
        {
            if (!stopped)
                rb.velocity = new Vector3(35, 0, 0);
            else
                rb.velocity = Vector3.zero;
        }
    }

    public void UseCard()
    {
        gameController.cards.Remove(gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        stopped = true;
    }
}
