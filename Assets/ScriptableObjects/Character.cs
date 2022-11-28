using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string name;
    public string description;
    public bool stunned;
    public Sprite artwork;

    public int speed;
    public int dmgToStun;
}
