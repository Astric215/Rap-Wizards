using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Card : ScriptableObject
{
    public string word;
    public int damageType = 1;
    public int damageLevel = 1;
    public int rhyme = 1;
    public string text;
}
