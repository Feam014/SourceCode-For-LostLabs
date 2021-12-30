using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] Image healthBar;
    public float CurrentHealth;
    [SerializeField] float MaxHealth = 100f;
    public CharacterMovement movement;
    [SerializeField] Text texty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = movement.health;
        healthBar.fillAmount = CurrentHealth / MaxHealth;

        texty.text = CurrentHealth.ToString("0");
    }
}
