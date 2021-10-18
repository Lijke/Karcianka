using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ExtraMove/Vulnerable")]
public class VulnerableEffect : CardExtraMove
{
    [SerializeField] private int howManyRoundVulnerable;
    public override void CardMove()
    {
        enemyHealth.howManyRoundVulerable += howManyRoundVulnerable;
    }
}
