using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text wordText;
    public TMP_Text descriptionText;

    public string clip;
    bool isObjectClicked;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        getSprite(card);
        wordText.text = card.word;
        descriptionText.text = card.text;

        switch (card.damageType)
        {
            case 1:
                clip = "event:/SFX/Fire";
                break;
            case 2:
                clip = "event:/SFX/Ice";
                break;
            case 3:
                clip = "event:/SFX/Protect";
                break;
            case 4:
                clip = "event:/SFX/Electric";
                break;
            case 5:
                clip = "event:/SFX/Poison";
                break;
            default:
                clip = "event:/SFX/Fire";
                break;
        }
    }
    void OnMouseDown() //Detects when you click the gameObject that contains this script
    {
        isObjectClicked = true;
        GameManager.Instance.clickedCard = gameObject;
    }

    void OnMouseUp() //Detects when you stop clicking on the gameObject that contains this script
    {
        isObjectClicked = false;
        //Your script here
    }



    public void getSprite(Card card)
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        switch (card.damageType)
        {
            case 1:
                sr.sprite = Resources.Load<Sprite>("Sprites/Cards/Card_Fire");
                break;
            case 2:
                sr.sprite = Resources.Load<Sprite>("Sprites/Cards/Card_Ice");
                break;
            case 3:
                sr.sprite = Resources.Load<Sprite>("Sprites/Cards/Card_Protect");
                break;
            case 4:
                sr.sprite = Resources.Load<Sprite>("Sprites/Cards/Card_Shock");
                break;
            case 5:
                sr.sprite = Resources.Load<Sprite>("Sprites/Cards/Card_Toxic");
                break;
            default:
                sr.sprite = Resources.Load<Sprite>("Sprites/Cards/Card_Neutral");
                break;
        }

    }
}
