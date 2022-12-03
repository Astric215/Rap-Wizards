using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    [SerializeField] int score = 0;
    [SerializeField] int pointsToWin = 3;
    [SerializeField] int enemyPoints = 0;
    [SerializeField] int playerPoints = 0;
    public GameObject hand;
    public GameObject clickedCard = null;
    public GameObject clickedChar = null;
    public GameObject turnTracker;

    public List<GameObject> turnOrder;

    bool turnStart = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(turnStart)
        {
            //this long line just sorts the list in place by speed
            turnOrder.Sort((x, y) => (y.GetComponent<CharDisplay>().character.speed + y.GetComponent<CharDisplay>().character.speedBonus).CompareTo((x.GetComponent<CharDisplay>().character.speed + x.GetComponent<CharDisplay>().character.speedBonus)));
            turnStart = false;
        }
        loadTurnTracker();

        //TODO: Fill the bar based on score var
        //TODO: Fill Turn order based on character speed
        if (clickedCard != null && clickedChar != null)
        {
            attack();
        }
    }
    public void attack()
    {
        Character chara = clickedChar.GetComponent<CharDisplay>().character;
        Card card = clickedCard.GetComponent<CardDisplay>().card;
        //check for heal, then weakness, then normal dmg
        if(card.damageType == 3)
        {
            chara.dmgTaken -= card.damageLevel;
        } else if (chara.weakness == card.damageType) {
            chara.dmgTaken += card.damageLevel * 2;
        } else {
            chara.dmgTaken += card.damageLevel;
        }
        if (chara.dmgTaken >= chara.dmgToStun)
        {
            chara.stunned = true;
        }

        Debug.Log(chara.dmgTaken + " damage dealt");
        deleteCard(clickedCard);
        clickedCard = null;
        clickedChar = null;
        nextTurn();
    }

    private void deleteCard(GameObject card)
    {
        //delete card from hand
        hand.GetComponent<Hand>().cards.Remove(card);
        Destroy(card);
    }

    private void loadTurnTracker()
    {
        Transform trackerTransform = turnTracker.transform;
        int i = 0;
        foreach (Transform child in trackerTransform)
        {
            child.GetComponent<Image>().sprite = turnOrder[i].GetComponent<CharDisplay>().character.portrait;
            i++;
        } 
    }

    private void nextTurn()
    {
        turnOrder.Add(turnOrder[0]);
        turnOrder.Remove(turnOrder[0]);
    }
}
