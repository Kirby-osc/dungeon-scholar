using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slime : Enemy
{
 private State _slimeState;
 public bool isMoving = false;

 private void Start()
 {
  _slimeState=gameObject.AddComponent<IsNotMovingState>();
 }

 protected override void FixedUpdate()
 {
  
 }

 public void ChangeState(State state)
 {
  this._slimeState = state;
 }
}
