using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _pos;
    [SerializeField] private float _coolTime;

    private float _curTime;

    [SerializeField] private SpriteRenderer _renderer;

    Vector3 flipMove = Vector3.zero;

    void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if(z > 90 || z < -90)
        {
            flipMove = Vector3.left;
            _renderer.flipY = true;
        }
        else if (z < 90 || z > -90)
        {
            flipMove = Vector3.right;
            _renderer.flipY = false;
        }

        if (_curTime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(_bullet, _pos.position, transform.rotation);
            }
            _curTime = _coolTime;
        }
        _curTime -= Time.deltaTime;
    }
}
