using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Card> playerCards;
    public List<Card> usedCards;
    public List<Card> cardsOnTable;
    public List<Card> unusedCards;
    public List<Card> GetCards()
    {
        return playerCards;
    }

}
