using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeakyTrap : MonoBehaviour
{
  [SerializeField] private float trapDelay;
  [SerializeField] private Collider2D col;
  [SerializeField] private Animator anim;
  [SerializeField] private bool isActivated = false;
  private float _tDel;

  private void Awake()
  {
   _tDel = trapDelay;
  }

  private void Update()
  {
    _tDel -= Time.deltaTime;
    if (_tDel <= 0)
    {
      switch (isActivated)
      {
        case false:
          PeaksOn();
          isActivated = true;
          break;
        case true:
          PeaksOff();
          isActivated = false;
          break;
      }
      _tDel = trapDelay;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag=="Player")
    {
      other.GetComponent<Hero>().TakeDamage();
    }
  }

  void PeaksOn()
  {
    col.enabled = true;
    anim.SetBool("isEnable",true);
  }

  void PeaksOff()
  {
    col.enabled = false;
    anim.SetBool("isEnable",false);
  }
}
