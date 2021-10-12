using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthBarImage;

    public void HandleHealthUpdated()
    {
        healthBarImage.fillAmount = (float) health.CurrentHealth() / health.MaxHealth() ;
    }

}
