using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string charName;
    public bool stunned;
    public Sprite artwork;

    public int speed;
    public int dmgToStun;
    public int weakness;

    public List<Card> deck;
}
