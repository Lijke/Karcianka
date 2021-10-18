using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ExtraMove/Attack All Enemy Effect")]
public class AttackAllEnemy : CardExtraMove
{
    private  GameObject[] enemyGameObjects;
    private List<Health> enemyHealths;
    public override void CardMove()
    {
        enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //Dodajemy Health Skrypt
        for (int i = 0; i < enemyGameObjects.Length; i++)
        {
            if (enemyGameObjects[i].GetComponent<Health>() != null)
            {
                enemyHealths.Add(enemyGameObjects[i].GetComponent<Health>());
            }
        }
        //Atakujemy + particle  
        foreach (var item in enemyHealths)
        {
            item.DealDamage(card.AttackDamage());
            item.GraphicEffect(card.ParticleHit());
        }
       
    }
}
