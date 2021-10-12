using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private HealthDisplay healthDisplay;
    [SerializeField] private PlayerHealthDisplay playerHealthDisplay;

    public bool isStuned;
    public float howManyRoundHaveStun;
    public static event Action DieEnemy;
    public static event Action DiePlayer;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public int MaxHealth()
    {
        return maxHealth;
    }
    public int CurrentHealth()
    {
        return currentHealth;
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public void SetHealth(int newHealth)
    {
        currentHealth = newHealth;
    }

    public void DealDamage(int damageAmmount)
    {

        currentHealth -= damageAmmount;
        if (currentHealth < 1)
        {
            DieEnemy();
        }
        healthDisplay.HandleHealthUpdated();
    }
    public void DealDamageToPlayer(int damageAmmount)
    {

        currentHealth -= damageAmmount;

        if (currentHealth < 1)
        {
            DiePlayer();
        }
        playerHealthDisplay.HandleHealthUpdated();
    }
    public void GraphicEffect(GameObject particleHit)
    {
        if(particleHit == null)
        {
            return;
        }
        GameObject particle = Instantiate(particleHit, transform.position, Quaternion.identity);
        StartCoroutine(DestroyParticle(particle));
    }
    IEnumerator DestroyParticle(GameObject particle)
    {
        yield return new WaitForSeconds(2);
        DestroyImmediate(particle);
    }

}
