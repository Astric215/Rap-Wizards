using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;


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

    [SerializeField] float score = 0;
    float pointsToWin = 3;
    [SerializeField] float enemyPoints = 0;
    [SerializeField] float playerPoints = 0;
    public GameObject hand;
    public GameObject clickedCard = null;
    public GameObject clickedChar = null;
    public GameObject turnTracker;

    public GameObject roundBar;
    public List<GameObject> turnOrder;
    public List<GameObject> players;
    private Slider pointsBar;

    AudioSource sound;
    bool turnStart = true;
    float dmgDealt = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        pointsBar = roundBar.GetComponent<Slider>();
        turnOrder.Sort((x, y) => (y.GetComponent<CharDisplay>().character.speed + y.GetComponent<CharDisplay>().character.speedBonus).CompareTo((x.GetComponent<CharDisplay>().character.speed + x.GetComponent<CharDisplay>().character.speedBonus)));
    }

    // Update is called once per frame
    void Update()
    {
        if (turnStart)
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

        if (!turnStart && players.Contains(turnOrder[0]))
        {
            var currChar = turnOrder[0].GetComponent<CharDisplay>().character;
            Debug.Log(currChar.charName + "'s Turn");
            if (!currChar.stunned)
            {
                //draw a card
                if(hand.GetComponent<Hand>().cards.Count < 5)
                {
                    hand.GetComponent<Hand>().Draw(currChar.charName);
                } 
            } 
            else
            {
                Debug.Log(currChar.charName + " is stunned");
                currChar.stunned = false;
                nextTurn();
            }
            
        } else
        {
            clickedCard = null;
            clickedChar = null;
            enemyAttack();
        }
        //update music
        score = (dmgDealt) / 10;
        MusicManager.Instance.updateMusicParams(score);
        pointsBar.value = (score + 1) / 2;
        Debug.Log(score);

    }
    public void attack()
    {
        Character chara = clickedChar.GetComponent<CharDisplay>().character;
        Card card = clickedCard.GetComponent<CardDisplay>().card;
        //check for heal, then weakness, then normal dmg
        if (card.damageType == 3)
        {
            chara.dmgTaken -= card.damageLevel;
            dmgDealt += card.damageLevel;
        }
        else if (chara.weakness == card.damageType)
        {
            chara.dmgTaken += card.damageLevel * 2;
            dmgDealt += card.damageLevel * 2;
        }
        else
        {
            chara.dmgTaken += card.damageLevel;
            dmgDealt += card.damageLevel;
        }
        if (chara.dmgTaken >= chara.dmgToStun)
        {
            chara.stunned = true;
            chara.dmgTaken = 0;
        }

        if (!players.Contains(clickedChar))
        {
            playerPoints += 1;
        }
        else
        {
            enemyPoints += 1;
        }

        Debug.Log(chara.dmgTaken + " damage dealt to " + chara.charName);
        playSound();
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

    private void playSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(clickedCard.GetComponent<CardDisplay>().clip);
    }

    private void enemyAttack()
    {
        var enemy = turnOrder[0].GetComponent<CharDisplay>();
        Debug.Log(enemy.character.charName + "'s Turn");
        if (!enemy.character.stunned)
        {
            var card = enemy.character.deck[Random.Range(0, enemy.character.deck.Count)];
            var chara = players[Random.Range(0, players.Count)].GetComponent<CharDisplay>().character;
            if (card.damageType == 3)
            {
                chara.dmgTaken -= card.damageLevel;
            }
            else if (chara.weakness == card.damageType)
            {
                chara.dmgTaken += card.damageLevel * 2;
                dmgDealt -= card.damageLevel * 2;
            }
            else
            {
                chara.dmgTaken += card.damageLevel;
                dmgDealt -= card.damageLevel;
            }
            if (chara.dmgTaken >= chara.dmgToStun)
            {
                chara.stunned = true;
                chara.dmgTaken = 0;
            }
            Debug.Log(chara.dmgTaken + " damage dealt to " + chara.charName + " by " + enemy.character.charName);
        } else
        {
            Debug.Log(enemy.character.charName + " is stunned");
            enemy.character.stunned = false;
        }
        nextTurn();
    }
}
