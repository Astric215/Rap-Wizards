using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text wordText;
    public TMP_Text descriptionText;

    public AudioClip clip;
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
                clip = Resources.Load<AudioClip>("SFX/fire");
                break;
            case 2:
                clip = Resources.Load<AudioClip>("SFX/ice");
                break;
            case 3:
                clip = Resources.Load<AudioClip>("SFX/protect");
                break;
            case 4:
                clip = Resources.Load<AudioClip>("SFX/electric");
                break;
            case 5:
                clip = Resources.Load<AudioClip>("SFX/poison");
                break;
            default:
                clip = Resources.Load<AudioClip>("SFX/fire");
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
