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

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        getSprite(card);
        wordText.text = card.word;
        descriptionText.text = card.text;  
    }

    public void getSprite(Card card)
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        switch (card.damageType)
        {
            case 1:
                sr.sprite = Resources.Load<Sprite>("Sprites/Card_Fire");
                break;
            case 2:
                sr.sprite = Resources.Load<Sprite>("Sprites/Card_Ice");
                break;
            case 3:
                sr.sprite = Resources.Load<Sprite>("Sprites/Card_Protect");
                break;
            case 4:
                sr.sprite = Resources.Load<Sprite>("Sprites/Card_Shock");
                break;
            case 5:
                sr.sprite = Resources.Load<Sprite>("Sprites/Card_Toxic");
                break;
            default:
                sr.sprite = Resources.Load<Sprite>("Sprites/Card_Neutral");
                break;
        }

    }
}
