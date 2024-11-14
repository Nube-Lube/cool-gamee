using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBaseScript : MonoBehaviour
{
    public GameController game;
    public int money;
    public List<int> sequence1Time = new List<int>();
    public List<int> sequence1Type = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Mathf.Round(Random.value * 100) == 1)
        {
            game.placeEnemy();
        }

    }

}
