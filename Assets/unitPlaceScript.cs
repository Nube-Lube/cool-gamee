using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitPlaceScript : MonoBehaviour
{
    public GameController gameController;
    public Vector2 playerMouse;
    public bool isPlayer1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1 && Input.GetKeyDown(KeyCode.F))
        {
            gameController.tryPlace1(playerMouse.x, playerMouse.y);
        }

        if (!isPlayer1 && Input.GetKeyDown(KeyCode.Slash))
        {
            gameController.tryPlace2(playerMouse.x, playerMouse.y);
        }
    }
}
