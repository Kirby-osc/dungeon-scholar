using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float _amount;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<Hero>().Amount += _amount;
            print("You've earned "+_amount+" coins!");
            Destroy(gameObject);
        }
    }
}
