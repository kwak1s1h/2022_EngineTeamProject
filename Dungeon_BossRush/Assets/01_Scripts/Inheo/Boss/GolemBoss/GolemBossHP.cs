using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossHP : MonoBehaviour
{
    public float _bossHP;
    private PolygonCollider2D _collider;

    Animator animator;

    public float currentHP;

    private bool _guarded = false;

    private void Awake()
    {
        currentHP = _bossHP;
        _collider = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= _bossHP * 0.4 && !_guarded)
        {
            StartCoroutine(Guard());
        }

        if (currentHP <= 0)
        {
            GetComponent<BossMove>().enabled = false;
            GetComponent<GolemBossController>().enabled = false;
            GetComponent<GolemAttack>().enabled = false;
            Destroy(gameObject, 7);
            _collider.enabled = false;
            Invoke("DeathAnim", 3);
        }
    }
    private void DeathAnim()
    {
        animator.SetTrigger("Dead");
    }

    private IEnumerator Guard()
    {
        _guarded = true;
        _collider.enabled = false;
        GameObject.Find("GolemBoss").GetComponent<BossMove>().enabled = false;
        GameObject.Find("GolemBoss").GetComponent<GolemBossController>().enabled = false;
        animator.SetTrigger("Guard");
        currentHP = currentHP + _bossHP * 0.2f;
        yield return new WaitForSeconds(3);
        GameObject.Find("GolemBoss").GetComponent<BossMove>().enabled = true;
        GameObject.Find("GolemBoss").GetComponent<GolemBossController>().enabled = true;
        _collider.enabled = true;
        animator.SetTrigger("Idle");
    }
}
