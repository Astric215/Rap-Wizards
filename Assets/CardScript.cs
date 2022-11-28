using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public Text cardText;
    public string textToShow;
    // Start is called before the first frame update
    void Start()
    {
        cardText.text = textToShow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readText(string myText)
    {
        textToShow = myText;
        cardText.text = textToShow;
        //can add other stuff here to read and update the card text
    }
}
