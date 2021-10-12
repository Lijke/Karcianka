using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTurn;

    public EnemyAttack enemyAttack;
    private static GameManager instance;
    private SpawnCards spawnCards;
    [SerializeField] private PlayerMana playerMana;

    private void Awake()
    {
        Health.DieEnemy += Die;
        Health.DiePlayer += DiePlayer;
    }


    private void OnDisable()
    {
        Health.DieEnemy -= Die;
        Health.DiePlayer -= DiePlayer;
    }

    private void Die()
    {
        Debug.Log("DIE");
        
    }
    private void DiePlayer()
    {
        Debug.Log("Die Player");
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }
    private void Start()
    {
        enemyAttack = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAttack>();
        spawnCards = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnCards>();
    }
    public void ChangePlayerTurn()
    {
       
        isPlayerTurn = true;
     

    }
    public void ChangeToEnemyTurn()
    {
        StopAllCoroutines();
        spawnCards.ShuffleCard();
        isPlayerTurn = false;
        playerMana.currentMana = playerMana.GetMaxMana();
        playerMana.ChangeManaText();
        enemyAttack.EnemyChoseMove();
    }
}
