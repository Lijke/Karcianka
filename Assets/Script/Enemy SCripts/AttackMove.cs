using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/AttackMove")]
public class AttackMove : Move
{
    [SerializeField] private int damage;

    public override void UseMove(Health playerHealth)
    {
        playerHealth.DealDamageToPlayer(damage);
        playerHealth.GraphicEffect(particleHit);

    }
}
