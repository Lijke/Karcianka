using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/StunAttack")]
public class StunMove : Move
{
    [SerializeField] private float howManyRoundStun = 1f;

    public override void UseMove(Health playerHealth)
    {
        playerHealth.howManyRoundHaveStun += howManyRoundStun;
    }
}
