using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ExtraMove/Gain Card")]
public class GainOneCard : CardExtraMove
{
    [SerializeField] private int ammountOfCards;
    public override void CardMove()
    {
        SpawnCards.instance.SpawnCard(ammountOfCards);
    }
}
