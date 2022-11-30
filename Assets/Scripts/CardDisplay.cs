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

    public GameObject typeSprite;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        card.getSprite();
        wordText.text = card.word;
        descriptionText.text = card.text;
        sr = typeSprite.GetComponent<SpriteRenderer>();
        sr.sprite = card.background;
    }
}
