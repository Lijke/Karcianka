using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMana : MonoBehaviour
{
    [SerializeField] private int maxMana;
    [SerializeField] public int currentMana;
    [SerializeField] private TextMeshProUGUI manaText;
    private void Start()
    {
        currentMana = maxMana;
        manaText.text = currentMana.ToString();
    }
    public int GetMaxMana()
    {
        return maxMana;
    }
    public int GetCurrentMana()
    {
        return currentMana;
    }

    public void ChangeManaText(int manaCost)
    {
        currentMana -= manaCost;
        manaText.text = currentMana.ToString();
    }
    public void ChangeManaText()
    {
        manaText.text = currentMana.ToString();
    }
    
}
