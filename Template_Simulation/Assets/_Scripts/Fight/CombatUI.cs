using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    [SerializeField] Fighter fighter;

    [SerializeField] Slider healthSlider;
    [SerializeField] Slider manaSlider;

    private void Start()
    {
        healthSlider.maxValue = fighter.MaxHealth;
        manaSlider.maxValue = fighter.MaxMana;
    }

    private void Update()
    {
        if (fighter.CurrentHealth <= 0)
        {
            healthSlider.gameObject.SetActive(false);
            manaSlider.gameObject.SetActive(false);
        }
            

        healthSlider.value = fighter.CurrentHealth;
        manaSlider.value = fighter.CurrentMana;
    }
    private void LateUpdate()
    {
        if (fighter.CurrentHealth <= 0)
        {
           GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}
