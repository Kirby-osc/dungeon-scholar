using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private static Hero _hero;
    
    public delegate void HealthChanged(float h);

    public event HealthChanged HealthChange;
    private float Health { get; set; } = 3.0f;
    public float Amount { get; set; }

    void Awake()
    {
        CheckInstance();
    }
    public void TakeDamage()
    {
        this.Health--;
        print(Health);
        HealthChange.Invoke(Health);
        if (Health==0)
        {
         print("You're dead!");
        }
    }

    private void CheckInstance()
    {
        if (_hero==null)
        {
            _hero = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
