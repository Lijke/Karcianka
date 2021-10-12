using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour
{
    [SerializeField] private Transform cardMainTransform;
    [SerializeField] private Player player;
    [SerializeField] private float xOffset;
    [SerializeField] private int howManyCardOnTable = 3;
    [SerializeField] private SpawnCardPositionController spawnCardPositionController;
    public static SpawnCards instance;

    void Start()
    {
        SpawnCard();
        instance = this;
    }

    private void SpawnCard()
    {
        List<Card> playerCards = player.GetCards();
        for (int i = 0; i < howManyCardOnTable; i++)
        {
            Vector3 positionCard = new Vector3(cardMainTransform.position.x + xOffset*i, cardMainTransform.position.y, 0);
            var card=Instantiate(playerCards[i], positionCard,Quaternion.identity );
            player.cardsOnTable.Add(card);
        }
        for (int i = howManyCardOnTable; i < player.GetCards().Count; i++)
        {
            
            var card = Instantiate(playerCards[i], transform.position, Quaternion.identity);
            card.gameObject.SetActive(false);
            player.unusedCards.Add(card);
        }
        spawnCardPositionController.OrderTheCards();
    }
    //dzieje siê po rundzie gracza
    public void SpawnCard(int ammountOfCard)
    {
        Debug.Log(ammountOfCard);
        if(player.unusedCards.Count < 1)
        {
            ShuffleUsedCards();
        }
        for (int i = 0; i < ammountOfCard; i++)
        {
            
            player.unusedCards[i].SetAciveTrue();
            
            spawnCardPositionController.OrderTheCard();
            player.cardsOnTable.Add(player.unusedCards[i]);
            player.unusedCards.Remove(player.unusedCards[i]);
        }
        spawnCardPositionController.OrderTheCards();
    }
    //po turze gracze
    public void ShuffleCard()
    {
        //Przenosimy karty które, nie zosta³y uzyte do used card
        for (int i = 0; i < player.cardsOnTable.Count; i++)
        {
            StartCoroutine(player.cardsOnTable[i].ShuffleCardToDeckPosition());
            StartCoroutine(player.cardsOnTable[i].WaitAndDestroyCard());
            player.usedCards.Add(player.cardsOnTable[i]);
        }
        //Czyscimy stól
        player.cardsOnTable.Clear();
        //Dajemy graczowi X kart z unsued
        for (int j = 0; j < howManyCardOnTable; j++)
        {
            if (player.unusedCards.Count < 3)
            {
                ShuffleUsedCards();
            }

            player.cardsOnTable.Add(player.unusedCards[j]);
            player.unusedCards.Remove(player.unusedCards[j]);
        }
        StartCoroutine(spawnCardPositionController.OrderTheCardWhenEnemyTurnIsOver());
    }
    private void ShuffleUsedCards()
    {
        for (int i = 0; i < player.usedCards.Count; i++)
        {
            player.unusedCards.Add(player.usedCards[i]);
        }
        player.usedCards.Clear();
    }

}
