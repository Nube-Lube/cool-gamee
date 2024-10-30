using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject playerUnit, player1Hold, player2Hold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tryPlace1(float x, float y)
    {
        Instantiate(player1Hold, player1Hold.transform);
    }

    public void tryPlace2(float x, float y)
    {
        Instantiate(player2Hold, player2Hold.transform);
    }
}
