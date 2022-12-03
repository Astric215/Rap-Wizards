using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    List<Character> turnOrder;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void deleteCard(GameObject card)
    {
        //delete card from hand
        hand.GetComponent<Hand>().cards.Remove(card);
        Destroy(card);
    }
}
