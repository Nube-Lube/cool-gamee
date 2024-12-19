using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject shop, playerUnit, spellUnit, player1Hold, player2Hold, conveyorMask, conveyor2Mask, unitCard, spellCard, enemyUnit, newUnit, newEnemy, newCard, newSpell;
    public Transform enemyPosition, spellPosition;
    public bool paused;
    public List<GameObject> cards = new List<GameObject>(), spells = new List<GameObject>();
    public List<int> type = new List<int>();
    public List<int> spellType = new List<int>();
    public List<int> health = new List<int>();
    public List<int> speed = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnCards", 3, 1);
        InvokeRepeating("placeEnemy", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!paused)
            {
                Pause();
            } else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        shop.SetActive(true);
        paused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        shop.SetActive(false);
        paused = false;
    }
    public void spawnCards()
    {
        if (!paused)
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
                spellType.Add((int)Mathf.Round(Random.value * 1));
            }
        }
    }

    public void placeEnemy()
    {
        if (!paused)
        {
            if (Mathf.Round(Random.value * 2) == 1)
            {
                newEnemy = Instantiate(enemyUnit);
                newEnemy.GetComponent<enemyUnitScript>().type = (int)Mathf.Round(Random.value * 1);
            }
        }
    }

    public void tryPlace(float x, float y, Transform pos)
    {
        if (!paused)
        {
            if (cards.Count > 0)
            {
                newUnit = Instantiate(playerUnit, pos);
                newUnit.GetComponent<unitScript>().health = health[type[0]];
                newUnit.GetComponent<unitScript>().moveSpd = speed[type[0]];
                cards[0].GetComponent<unitCardScript>().UseCard();
            }
        }
    }

    public void trySpell(float x, float y, Transform pos)
    {
        if (!paused)
        {
            if (spells.Count > 0)
            {
                newSpell = Instantiate(spellUnit, pos);
                spells[0].GetComponent<spellCardScript>().UseCard();
            }
        }
    }

}