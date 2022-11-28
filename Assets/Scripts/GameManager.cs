using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int pointsToWin = 3;
    [SerializeField] int enemyPoints = 0;
    [SerializeField] int playerPoints = 0;
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
    }
}
