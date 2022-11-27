using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiBossHP : MonoBehaviour
{
    public float _bossHP;
    public float currentHP;
    
    private PolygonCollider2D _collider;

    SamuraiController _controller;

    Animator animator;

    private bool _isUlt = true;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHP = _bossHP;
        _collider = GetComponent<PolygonCollider2D>();
        _controller = GetComponent<SamuraiController>();
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            GetComponent<SamuraiMove>().enabled = false;
            GetComponent<SamuraiController>().enabled = false;
            GetComponent<SamuraiAttack>().enabled = false;
            Destroy(gameObject, 7);
            animator.SetTrigger("Idle");
            Invoke("DeathAnim", 2f);
            _collider.enabled = false;
        }

    }

    private void Update()
    {
        if (currentHP < _bossHP * 0.2 && _isUlt)
        {
            StartCoroutine(_controller.Ult());
            _isUlt = false;
        }
    }
    private void DeathAnim()
    {
        animator.SetTrigger("Death");
    }
}
