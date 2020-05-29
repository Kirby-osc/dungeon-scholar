using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Hero goHero;
    [SerializeField] private List<Image> hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void OnEnable()
    {
        goHero.HealthChange += OnHealthChange;  
    }
    

   public void OnHealthChange(float health)
    {
        switch (health)
        {
         case 3:
             hearts[3].sprite = emptyHeart;
             break;
         case 2:
             hearts[2].sprite = emptyHeart;
             break;
         case 1:
             hearts[1].sprite = emptyHeart;
             break;
         case 0:
             hearts[0].sprite = emptyHeart;
             break;
        }
    }
}
