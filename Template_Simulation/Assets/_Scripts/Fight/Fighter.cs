using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Entity
{
    public float CurrentHealth;
    public float MaxHealth = 100;

    public float CurrentMana;
    public float MaxMana = 100;

    private float BaseDefense=5;
    private float RoundDefense;
    public float Defense => BaseDefense + RoundDefense;

    private float BaseAttack=10;
    private float RoundAttack;
    public float Attack => BaseAttack + RoundAttack;

    private float BaseSpeed;
    private float RoundSpeed;
    public float Speed => BaseSpeed + RoundSpeed;

    public List<FightCommandTypes> PossibleCommands;

    public static Action OnChange;

    public bool IsAlive => CurrentHealth > 0;


    // Start is called before the first frame update
    void Awake()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
    }

    

    public void TakeDamage(float damage)
    {
        float realDamage = damage - (BaseDefense + RoundDefense);
        realDamage = Mathf.Max(realDamage, 0);

        CurrentHealth -= realDamage;

        OnChange?.Invoke();
        if (CurrentHealth < 0)
            Die();
    }

    public void Mana(int mana)
    {
        if (CurrentMana >= mana)
        {
            CurrentMana -= mana;
           
            OnChange?.Invoke();
        }
        else if (CurrentHealth + CurrentMana - mana > 0)
        {
          
            CurrentHealth -= mana - CurrentMana;

            CurrentMana = 0;

            OnChange?.Invoke();
        }
        else
        {
            CurrentHealth = 1;
            CurrentMana = 0;
            if (BaseAttack > 1)
            BaseAttack -=1;
        }
    }

    public void Die()
    {
        //Destroy(gameObject);
        CurrentHealth = -1;
        GetComponent<SpriteRenderer>().color = Color.gray;
       
    }

    public void AddDefense(float amount)
    {
        RoundDefense += amount;
        OnChange?.Invoke();
    }

    public void AddAttack(float amount)
    {
        RoundAttack += amount;
        OnChange?.Invoke();
    }

    public void AddDefensePermanent(float amount)
    {
        BaseDefense += amount;
        OnChange?.Invoke();
    }

    public void AddAttackPermanent(float amount)
    {
        BaseAttack += amount;
        OnChange?.Invoke();
    }

    public void AddSpeed(float amount)
    {
        RoundSpeed += amount;
        OnChange?.Invoke();
    }

    public void ResetFighter()
    {
        RoundDefense = 0;
        RoundAttack = 0;
        RoundSpeed = 0;
        OnChange?.Invoke();
    }

    public void SetParameters(int hp, int mana ,int attack, int defense)
    {
        MaxHealth = hp;
        CurrentHealth = MaxHealth;

        MaxMana = mana;
        CurrentMana = MaxMana;

        BaseAttack = attack;
        BaseDefense = defense;

        RoundDefense = 0;
        RoundAttack = 0;
        RoundSpeed = 0;
    }
}
