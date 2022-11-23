using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _pos;
    [SerializeField] private float _coolTime;

    private float _curTime;

    [SerializeField] private SpriteRenderer _gunRenderer;

    void Update()
    {
    }

    public void SetWeaponAngle(Vector2 mousePos)
    {
        Vector2 dir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        _gunRenderer.flipY = transform.position.x > mousePos.x;
    }
    public void Shooting()
    {
        if (_curTime <= 0)
        {
            Instantiate(_bullet, _pos.position, transform.rotation);
            _curTime = _coolTime;
        }
        _curTime -= Time.deltaTime;
    }
}
