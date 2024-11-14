using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject playerUnit, player1Hold, player2Hold, conveyorMask, unitCard, enemyUnit;
    public List<GameObject> cards = new List<GameObject>();
    public List<int> mass = new List<int>();
    public List <int> speed = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnCards", 3, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnCards()
    {
        if (Mathf.Round(Random.value * 3) == 1 && (cards.Count == 0 || cards[cards.Count - 1].transform.position.x >= -150))
        {
            Instantiate(unitCard, conveyorMask.transform);
        }
    }

    public void placeEnemy()
    {
        Instantiate(enemyUnit);
    }

    public void tryPlace(float x, float y, Transform pos)
    {
        if (cards.Count > 0)
        {
            cards[0].GetComponent<unitCardScript>().UseCard();
            Instantiate(playerUnit, pos);
        }
    }

}
