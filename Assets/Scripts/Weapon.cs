using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Vector2 _mousePos;
    private Vector2 _playerPos;
    private Transform _playerTr;
    private Camera _camera;
    protected virtual void Start()
    {
        _camera = Camera.main;
        _playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        RotateToCursor();
        Attack();
    }

    void Attack()
    {
        DoAttack();
    }
    void RotateToCursor()
    {
        _playerPos = _playerTr.position;
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        //Находим промежуточные значения между курсором и текущей позицией игрока
        Vector2 tempLerp = Vector2.Lerp(_mousePos, _playerPos, 0.1f);
        tempLerp -= _playerPos;
        tempLerp.Normalize();
        tempLerp *= 0.8f;
        transform.position = tempLerp + _playerPos;
        //Находим градусную меру угла положения курсора
        float angleToMouse = Mathf.Atan2(_mousePos.y - _playerPos.y, _mousePos.x - _playerPos.x) *
                             Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angleToMouse);
    }

    protected abstract void DoAttack();
}
