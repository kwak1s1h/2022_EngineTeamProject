using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GolemBossState { MeleeState, ChargeState, FollowState, LaserState }
public class GolemBossController : MonoBehaviour
{
    [SerializeField]
    private GolemBossState bossState;
    private GolemAttack bossAttack;
    private GolemBossHP bossHP;
    private BoxCollider2D attackRange;
    Animator animator;

    private bool meleeRange;

    private float _changeAttackType = 5;

    // Start is called before the first frame update
    void Start()
    {
        bossAttack = GetComponent<GolemAttack>();
        bossHP = GetComponent<GolemBossHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHP.currentHP <= bossHP._bossHP * 0.3)
        {
            StartCoroutine(LaserAttack());
        }

        if (_changeAttackType <= 0)
        {
            if (meleeRange)
            {
                StartCoroutine(MeleeAttack());
            }
            else
            {
                int rand = Random.Range(1, 3);
                if (rand == 1)
                {
                    Debug.Log("1");
                    StartCoroutine(ChargeAttack());
                }
                if (rand == 2)
                {
                    Debug.Log("2");
                    StartCoroutine(FollowAttack());
                }
            }
            _changeAttackType = Random.Range(2, 4);
        }
        _changeAttackType -= Time.deltaTime;
    }
    public void ChangeState(GolemBossState newState)
    {
        StopCoroutine(bossState.ToString());

        bossState = newState;

        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MeleeAttack()
    {
        bossAttack.StartFiring(GolemAttackType.MeleeAttack);
        yield return null;
    }
    private IEnumerator ChargeAttack()
    {
        bossAttack.StartFiring(GolemAttackType.ChargeAttack);
        yield return null;
    }
    private IEnumerator FollowAttack()
    {
        bossAttack.StartFiring(GolemAttackType.FollowMissile);
        yield return null;
    }
    private IEnumerator LaserAttack()
    {
        bossAttack.StartFiring(GolemAttackType.LaserAttack);
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            meleeRange = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            meleeRange = false;
        }
    }
}
