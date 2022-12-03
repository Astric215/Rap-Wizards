using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharDisplay : MonoBehaviour
{
    public Character character;

    private SpriteRenderer sr;

    bool isObjectClicked;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = character.artwork;
    }

    void OnMouseDown() //Detects when you click the gameObject that contains this script
    {
        isObjectClicked = true;
        GameManager.Instance.clickedChar = gameObject;
    }

    void OnMouseUp() //Detects when you stop clicking on the gameObject that contains this script
    {
        isObjectClicked = false;
        //Your script here
    }
}
