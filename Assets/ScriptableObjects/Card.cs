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
                background = Resources.Load<Sprite>("Sprites/Card_Fire 1");
                break;
            case 2:
                background = Resources.Load<Sprite>("Sprites/Card_Ice");
                break;
            case 3:
                background = Resources.Load<Sprite>("Sprites/Card_Protect");
                break;
            case 4:
                background = Resources.Load<Sprite>("Sprites/Card_Shock");
                break;
            case 5:
                background = Resources.Load<Sprite>("Sprites/Card_Toxic");
                break;
            default:
                background = Resources.Load<Sprite>("Sprites/Card_Neutral 1");
                break;
        }

    }
}
