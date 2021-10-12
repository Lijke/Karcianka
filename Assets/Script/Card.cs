using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite image;
    [SerializeField] private string cardName;
    [SerializeField] private int attackDamage;
    [SerializeField] private int manaCost;
    [SerializeField] private GameObject particleHit;
    private Transform deckTransform;
    [SerializeField] private TextMeshProUGUI manaText;
    public CardExtraMoveContainer cardExtraMoveContainer;
    private void Start()
    {
        deckTransform = GameObject.FindGameObjectWithTag("Deck").GetComponent<Transform>();
        manaText.text = manaCost.ToString();
    }

    public GameObject ParticleHit()
    {
        return particleHit;
    }
    public int GetManaCost()
    {
        return manaCost;
    }
    public int AttackDamage()
    {
        return attackDamage;
    }
    public IEnumerator ShuffleCardToDeckPosition()
    {
        Debug.Log("SHUFFLE");
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, deckTransform.position, time / 1);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = deckTransform.position;
    }
    public IEnumerator ShuffleCardToBoardPosition(Vector3 positionOnDeck)
    {
        float time = 0;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(transform.position, positionOnDeck, time / 1);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = positionOnDeck;
    }
    public IEnumerator WaitAndDestroyCard()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }
    public void SetAciveTrue()
    {
        gameObject.SetActive(true);
    }
}

