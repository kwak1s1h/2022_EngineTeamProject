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

    void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
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
