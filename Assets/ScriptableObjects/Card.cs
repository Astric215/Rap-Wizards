using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string word;
    public Sprite background;
    public int damageType = 1;
    public int damageLevel = 1;
    public int rhyme = 1;
    public string text;

    public void getSprite ()
    {
        switch (damageType) 
        {
            case 1:
                background = Resources.Load<Sprite>("Sprites/FireC_S 1");
                break;
            case 2:
                background = Resources.Load<Sprite>("Sprites/IceC_S");
                break;
            case 3:
                background = Resources.Load<Sprite>("Sprites/ProtecC_S");
                break;
            case 4:
                background = Resources.Load<Sprite>("Sprites/ShockC_S");
                break;
            case 5:
                background = Resources.Load<Sprite>("Sprites/ToxicC_S");
                break;
            default:
                background = Resources.Load<Sprite>("Sprites/NeutralC_S 1");
                break;
        }

    }
}
