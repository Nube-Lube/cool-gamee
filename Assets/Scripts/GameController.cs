using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerUnit, spellUnit, player1Hold, player2Hold, conveyorMask, conveyor2Mask, unitCard, spellCard, enemyUnit, newUnit, newEnemy, newCard, newSpell;
    public Transform enemyPosition, spellPosition;
    public List<GameObject> cards = new List<GameObject>(), spells = new List<GameObject>();
    public List<int> type = new List<int>();
    public List<int> health = new List<int>();
    public List <int> speed = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnCards", 3, 1);
        InvokeRepeating("placeEnemy", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnCards()
    {
        if (Mathf.Round(Random.value * 3) == 1 && (cards.Count == 0 || cards[cards.Count - 1].transform.position.x >= -150))
        {
            newCard = Instantiate(unitCard, conveyorMask.transform);
            cards.Add(newCard);
            type.Add((int)Mathf.Round(Random.value * 1));
        }

        if (Mathf.Round(Random.value * 6) == 1 && (spells.Count == 0 || cards[cards.Count - 1].transform.position.x <= 150))
        {
            newSpell = Instantiate(spellCard, conveyor2Mask.transform);
            spells.Add(newSpell);
        }
    }

    public void placeEnemy()
    {
        if (Mathf.Round(Random.value * 2) == 1)
        {
            int typ = (int)Mathf.Round(Random.value * 1);
            newEnemy = Instantiate(enemyUnit);
            newEnemy.GetComponent<unitScript>().health = health[typ];
            newEnemy.GetComponent<unitScript>().moveSpd = speed[typ];
        }
    }

    public void tryPlace(float x, float y, Transform pos)
    {
        if (cards.Count > 0)
        {
            newUnit = Instantiate(playerUnit, pos);
            newUnit.GetComponent<unitScript>().health = health[type[0]];
            newUnit.GetComponent<unitScript>().moveSpd = speed[type[0]];
            cards[0].GetComponent<unitCardScript>().UseCard();
        }
    }

    public void trySpell(float x, float y, Transform pos)
    {
        if (spells.Count > 0)
        {
            newSpell = Instantiate(spellUnit, pos);
            spells[0].GetComponent<spellCardScript>().UseCard();
        }
    }

}
