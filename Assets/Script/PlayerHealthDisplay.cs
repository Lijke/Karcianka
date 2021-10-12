using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private TextMeshProUGUI playerHealthText;

    private void Start()
    {
        playerHealthText.text = playerHealth.CurrentHealth().ToString();
    }
    public void HandleHealthUpdated()
    {
        playerHealthText.text = playerHealth.CurrentHealth().ToString();
    }
}
