using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovesCardByMouse : MonoBehaviour
{
    private Vector2 initialPos;
    private Vector2 mousePos;
    private float deltax, deltay;
    private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Card card;
    public Vector3 startPos;
    [SerializeField] private float yOffsetWhenMouseOnCard;
    private bool selectedCardMoveUp=true;
    private Player player;
    private SelectionManager selectionManager;
    private PlayerMana playerMana;
    private void Start()
    {
        mainCamera = Camera.main;
        selectionManager = GameObject.FindGameObjectWithTag("SelectionManager").GetComponent<SelectionManager>();
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();


    }
    private void Awake()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        if(selectionManager.CurrentCardSelected != card.gameObject)
        {
            OnMouseExit();  
        }
    }
    private void OnMouseDown()
    {
        deltax = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltay = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }
    private void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x - deltax, mousePos.y - deltay);
        
    }
    
    private void OnMouseUp()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerMask);
        if(hit.collider == null)
        {
            MoveToStartPosition();
            return; 
        }
        if(playerMana.GetCurrentMana()< card.GetManaCost())
        {
            MoveToStartPosition();
            return;
        }
        GameObject enemyGameObject = hit.collider.gameObject;
        Health enemyHealth = enemyGameObject.GetComponent<Health>();
        enemyHealth.DealDamage(card.AttackDamage());
        enemyHealth.GraphicEffect(card.ParticleHit());
        StartCoroutine(card.ShuffleCardToDeckPosition());
        if(card.cardExtraMoveContainer.cardExtraMoves.Count != 0)
        {
            for (int i = 0; i < card.cardExtraMoveContainer.cardExtraMoves.Count; i++)
            {
                card.cardExtraMoveContainer.cardExtraMoves[i].CardMove();
            }
            
        }
        playerMana.ChangeManaText(card.GetManaCost());
        player.usedCards.Add(card);
        player.cardsOnTable.Remove(card);
        StartCoroutine(card.WaitAndDestroyCard());
       
        
    }
    void MoveToStartPosition()
    {

        transform.position = startPos;
        selectedCardMoveUp = true;
        
    }

    private void OnMouseOver()
    {
        selectionManager.CurrentCardSelected = card.gameObject;
        if (selectedCardMoveUp)
            MoveCardOver();
    }

    private void OnMouseExit()
    {
        if(selectionManager.CurrentCardSelected == card.gameObject)
        {
            return;
        }
        if (!selectedCardMoveUp)
        {
            MoveToStartPosition();
           
        }
    }

    private void MoveCardOver()
    {
        selectedCardMoveUp = false;
        transform.position = new Vector3(transform.position.x, transform.position.y + yOffsetWhenMouseOnCard, 0);
    }
}
