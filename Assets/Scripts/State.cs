using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Enemy_Slime es;
    
    public void SetEnemySlime(Enemy_Slime es)
    {
        this.es = es;
    }

    private void Awake()
    {
        es = GameObject.FindObjectOfType<Enemy_Slime>();
    }

    private void FixedUpdate()
    {
        ExecuteSlimeState();
    }

    protected abstract void ExecuteSlimeState();
}

public class IsMovingState : State
{
    public float moveTimer = 3.5f;
    
    protected override void ExecuteSlimeState()
    {
       // this.es.isMoving = true;
        if (moveTimer>=0)
        {
            es.Move();
        this.es.anim.SetBool("isMoving",true);
        moveTimer -= Time.fixedDeltaTime;
        }
        else
        {
            moveTimer = 3.5f;
            es.ChangeState(gameObject.AddComponent<IsNotMovingState>());
            Destroy(es.GetComponent<IsMovingState>());
        }
    }
}

public class IsNotMovingState : State
{
    public float stopTimer = 4f;
    protected override void ExecuteSlimeState()
    {
       // es.isMoving = false;
        es.anim.SetBool("isMoving",false);
        stopTimer -= Time.fixedDeltaTime;
        if (stopTimer<=0)
        {
            stopTimer = 4f;
            es.ChangeState(gameObject.AddComponent<IsMovingState>());
            Destroy(es.GetComponent<IsNotMovingState>());

        }
    }
}
