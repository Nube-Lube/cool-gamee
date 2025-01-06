using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spellCardScript : MonoBehaviour
{
    public GameController gameController;
    private RectTransform rectTransform;
    private Rigidbody2D rb;
    public bool stopped, destroy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        destroy = false;
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        transform.position = gameController.spellCardPos;
        //gameController.spells.Add(gameObject);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy && GetComponent<Animation>().isPlaying == false)
            Destroy(gameObject);
    }
    void FixedUpdate()
    {
        if (gameController.spells.IndexOf(gameObject) == 0)
            stopped = false;
        else if (gameController.spells[gameController.spells.IndexOf(gameObject) - 1].transform.position.x < transform.position.x - 28f)
            stopped = false;
        else
            stopped = true;
        if (transform.position.x < 107)
            stopped = true;
        if (!stopped)
            rb.velocity = new Vector3(-28, 0, 0);
        else
            rb.velocity = Vector3.zero;
            //transform.position += new Vector3(-1, 0, 0);
    }

    public void UseCard()
    {
        gameController.spellType.Remove(gameController.spells.IndexOf(gameObject));
        gameController.spells.Remove(gameObject);
        GetComponent<Animation>().Play();
        GetComponent<BoxCollider2D>().enabled = false;
        destroy = true;

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("fff");
        stopped = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        stopped = false;
    }
}
