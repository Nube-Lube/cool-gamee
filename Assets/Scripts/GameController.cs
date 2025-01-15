using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject shop, playerUnit, spellUnit, player1Hold, player2Hold, conveyor1Place, conveyor2Place, unitCard, spellCard, enemyUnit, newUnit, newEnemy, newCard, newSpell;
    public Transform enemyPosition, spellPosition, unitPosition;
    public Vector3 spellCardPos;
    public Shader k;
    public bool paused;
    public float progress;
    public int healthStat, speedStat, typ, cardCt;
    [Header ("Cover Images")]
    public List<Sprite> cardImages = new List<Sprite>();
    public List<Sprite> spellImages = new List<Sprite>();
    [Header ("Runtime List")]
    public List<GameObject> cards = new List<GameObject>();
    public List<int> type = new List<int>();
    public List<GameObject> spells = new List<GameObject>();
    public List<int> spellType = new List<int>();
    [Header ("Unit Attributes")]
    public List<int> health = new List<int>();
    public List<int> speed = new List<int>();
    public List<float> mass = new List<float>();
    public List<CapsuleCollider2D> unitShapes = new List<CapsuleCollider2D>();
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
            if (Mathf.Round(Random.value * 5) == 1 && (cards.Count == 0 || cards[cards.Count - 1].transform.position.x >= -150))
            {
                typ = (int)Mathf.Round(Random.value * (cardCt - 1));
                typ = 1;
                newCard = Instantiate(unitCard, conveyor1Place.transform);
                cards.Add(newCard);
                type.Add(typ);
                newCard.GetComponent<SpriteRenderer>().sprite = cardImages[typ];
            }

            if (Mathf.Round(Random.value * 14) == 1 && (spells.Count == 0 || spells[spells.Count - 1].transform.position.x <= 250))
            {
                typ = (int)Mathf.Round(Random.value * (cardCt - 1));
                newSpell = Instantiate(spellCard, conveyor2Place.transform);
                spells.Add(newSpell);
                spellType.Add(typ);
                newSpell.GetComponent<SpriteRenderer>().sprite = spellImages[typ];
            }
        }
    }

    public void placeEnemy()
    {
        if (!paused)
        {
            if (Mathf.Round(Random.value * 5) == 1)
            {
                newEnemy = Instantiate(enemyUnit);
                newEnemy.GetComponent<enemyUnitScript>().typ = 1;//(int)Mathf.Round(Random.value * (cardCt - 1));
            }
        }
    }

    public void tryPlace(Transform pos)
    {
        if (!paused)
        {
            if (cards.Count > 0)
            {
                unitPosition = pos;
                newUnit = Instantiate(playerUnit);
                newUnit.GetComponent<unitScript>().typ = type[0];
                cards[0].GetComponent<unitCardScript>().UseCard();
            }
        }
    }

    public void trySpell(Transform pos)
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