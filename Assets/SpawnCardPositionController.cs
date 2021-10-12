using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCardPositionController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<Card> cards;
    [SerializeField] private int xOffset;
    [SerializeField] private List<Transform> cardsTransform;
    [SerializeField] private Transform deckPosition;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OrderTheCards();
        }
    }


    public void OrderTheCards()
    {
        cards = player.cardsOnTable;
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 positionCard = new Vector3(cardsTransform[i].transform.position.x + xOffset, cardsTransform[i].transform.position.y, 0);
            cards[i].GetComponent<MovesCardByMouse>().startPos = positionCard;
            cards[i].transform.position = positionCard;
        }
    }
    public void OrderTheCard()
    {
        cards = player.cardsOnTable;
        StartCoroutine(player.unusedCards[0].ShuffleCardToBoardPosition(new Vector3(
           cardsTransform[cards.Count].transform.position.x,
           cardsTransform[cards.Count].transform.position.y,
           0)));

        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 positionCard = new Vector3(cardsTransform[i].transform.position.x + xOffset, cardsTransform[i].transform.position.y, 0);
            cards[i].GetComponent<MovesCardByMouse>().startPos = positionCard;
            cards[i].transform.position = positionCard;
        }
    }
    public IEnumerator OrderTheCardWhenEnemyTurnIsOver()
    {
        cards = player.cardsOnTable;
        Debug.Log(cards.Count);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 positionCard = new Vector3(cardsTransform[i].transform.position.x + xOffset, cardsTransform[i].transform.position.y, 0);

            cards[i].gameObject.SetActive(true);
            StartCoroutine(cards[i].ShuffleCardToBoardPosition(positionCard)) ;
            cards[i].GetComponent<MovesCardByMouse>().startPos = positionCard;
        }
    }
}
