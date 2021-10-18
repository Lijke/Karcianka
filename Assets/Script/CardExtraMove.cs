using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardExtraMove : ScriptableObject
{
    public Health enemyHealth;
    public Card card;
    public abstract void CardMove();
}
