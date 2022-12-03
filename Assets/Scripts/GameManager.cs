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
        if (clickedCard != null)
        {
            attack();
        }
    }
    public void attack()
    {
        //currently just deletes clicked card but since i also have a character clicked i can do math from there
        Debug.Log("deleting " + clickedCard.GetComponent<CardDisplay>().card.word);
        //delete card from hand
        hand.GetComponent<Hand>().cards.Remove(clickedCard);
        Destroy(clickedCard);
        clickedCard = null;
    }
}
