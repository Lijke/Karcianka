using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Health playerHealth;
    [SerializeField] private List<Move> moves;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    public void EnemyChoseMove()
    {
        EnemyUseAttackMove();
    }
    private void EnemyUseAttackMove()
    {
        moves[0].UseMove(playerHealth);
        
        GameManager.Instance.ChangePlayerTurn();
    }
}
