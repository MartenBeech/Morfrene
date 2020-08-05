using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaCard : MonoBehaviour
{
    public static GameObject startSet;
    public static GameObject endSet;
    public static int iTo;
    public static GameObject prefab;
    public static GameObject parent;
    public static Card card;
    private GameObject startPoint;
    private GameObject endPoint;
    private int _to;

    private static float counterSet;
    private float counterStart;
    private float counter;




    private void Awake()
    {
        startPoint = startSet;
        endPoint = endSet;
        _to = iTo;
        counter = counterSet;
        counterStart = counterSet;
    }

    void Update()
    {
        if (counter > 0)
        {
            Vector3 dir = endPoint.transform.position - startPoint.transform.position;
            float dist = Mathf.Sqrt(
                Mathf.Pow(endPoint.transform.position.x - startPoint.transform.position.x, 2) +
                Mathf.Pow(endPoint.transform.position.y - startPoint.transform.position.y, 2));
            this.transform.Translate(dir.normalized * dist * Time.deltaTime / counterStart);
        }

        else if (counter <= 0)
        {
            string value = (Card.cards[_to].value < 10 ? Card.cards[_to].value.ToString() : "A");

            Card.Cards[_to].GetComponentInChildren<Text>().text = "     " + Card.cards[_to].element.Substring(0, 1) + "\n<size=34>" + Card.cards[_to].value + "</size>\n" + Card.cards[_to].element.Substring(0, 1) + "     ";
            if (Card.cards[_to].element == "Fire")
                Card.Cards[_to].GetComponentInChildren<Text>().color = Color.red;
            else if (Card.cards[_to].element == "Water")
                Card.Cards[_to].GetComponentInChildren<Text>().color = Color.blue;
            else if (Card.cards[_to].element == "Earth")
                Card.Cards[_to].GetComponentInChildren<Text>().color = Color.green;
            else if (Card.cards[_to].element == "Air")
                Card.Cards[_to].GetComponentInChildren<Text>().color = Color.gray;

            Card.Cards[_to].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("BattlefieldImages/" + Card.cards[_to].element + "Background");
            Card.Cards[_to].GetComponentInChildren<Image>().enabled = true;
            Destroy(gameObject);
        }

        counter -= Time.deltaTime;
    }

    public void MoveDeckCard(Card _card, int to)
    {
        prefab = Resources.Load<GameObject>("Prefabs/Card");
        parent = GameObject.Find("Animation");
        card = _card;
        iTo = to;
        startSet = Deck.Decks;
        endSet = Card.Cards[to];

        float pos = to;
        if (pos >= 10)
        {
            pos -= 10;
        }
        counterSet = 1 + (pos / 10);

        prefab.GetComponentInChildren<Image>().sprite = Deck.Decks.GetComponentInChildren<Image>().sprite;
        prefab = Instantiate(prefab, startSet.transform.position, startSet.transform.rotation, parent.transform);
    }

    public void MoveCardAsset(Card _card, int to)
    {
        
    }
}
