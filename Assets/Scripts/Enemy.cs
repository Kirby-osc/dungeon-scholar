using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health { get; set; } = 10.0f;
    public float spd= 1f;
    private Rigidbody2D _rb;
    public Animator anim;
    public Transform _playerTr;
    public float currentHealth;
    public GameObject drop;

    public Collider2D _col;
    // Update is called once per frame
    private void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        currentHealth = Health;
    }

   protected virtual void FixedUpdate()
    {
    Move();    
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth<=0)
        {
            EnemyDies();
        }
        else
        {
            anim.SetTrigger("Hit");
        }
    }

    private void EnemyDies()
    {
        _col.enabled = false;
        anim.SetTrigger("DeathHit");
        Instantiate(drop, transform.position, transform.rotation);
        Destroy(gameObject, 0.2f);
    }

    public void Move()
    {
        Vector2 playerPos = _playerTr.position;
        Vector2 tempPos = Vector2.MoveTowards(this.transform.position, playerPos, 
            spd * Time.fixedDeltaTime);
        this.transform.position = tempPos;
        if ((playerPos.x-transform.position.x)<0)
        {
            this.transform.eulerAngles=new Vector3(0,180);
        }
        else
        {
             this.transform.eulerAngles=new Vector3(0,0);
        }
    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<Hero>().TakeDamage();
        }
    }
}
