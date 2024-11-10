using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unitCardScript : MonoBehaviour
{
    public GameController gameController;
    private RectTransform rectTransform;
    public bool stopped;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        gameController.cards.Add(gameObject);
        GetComponent<BoxCollider2D>().enabled = true;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (gameController.cards.IndexOf(gameObject) == 0)
            stopped = false;
        if (rectTransform.position.x > 190)
            stopped = true;
        if (!stopped)
            transform.position += new Vector3(1, 0, 0);
    }

    public void UseCard()
    {
        gameController.cards.Remove(gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        stopped = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        stopped = false;
    }
}
