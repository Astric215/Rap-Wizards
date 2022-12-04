using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform leftPos;
    public Transform rightPos;
    public GameObject CardPrefab;

    public List<GameObject> cards;
    // Start is called before the first frame update
    void Start()
    {
        Draw("Singer");
        Draw("Singer");
        Draw("Singer");
        Draw("Singer");
    }

    // Update is called once per frame
    void Update()
    {
        float space = (rightPos.position.x - leftPos.position.x) / (cards.Count - 1);
        float curr_Space = leftPos.position.x;
        foreach (GameObject i in cards)
        {
            if(cards.Count == 1)
            {
                curr_Space += (rightPos.position.x - leftPos.position.x) / 2;
            }
            i.transform.position = new Vector3(curr_Space, rightPos.position.y, i.transform.position.z);
            curr_Space += space;
        }
    }

    public void Draw(string character)
    {
        var variables = GameObject.Find(character).GetComponent<CharDisplay>();
        GameObject cardObj = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        cardObj.GetComponent<CardDisplay>().card = variables.character.deck[Random.Range(0, variables.character.deck.Count)];
        cards.Add(cardObj);
    }
}
