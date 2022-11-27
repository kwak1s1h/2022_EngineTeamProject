using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GolemAttackType { MeleeAttack, ChargeAttack, FollowMissile, LaserAttack }

public class GolemAttack : MonoBehaviour
{
    Animator animator;

    [SerializeField] private GameObject _charge;
    [SerializeField] private GameObject _followMissile;
    [SerializeField] private GameObject _laser;

    [SerializeField] private Transform attackPos;
    public Vector2 boxSize;

    [SerializeField] private float meleeDMG;

    GolemBossHP bossHP;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StopAllCoroutines();
        bossHP = GetComponent<GolemBossHP>();
    }
    private void Update()
    {
        if (bossHP.currentHP <= 0)
        {
            StopAllCoroutines();
        }
    }

    public void StartFiring(GolemAttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(GolemAttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator MeleeAttack()
    {
        animator.SetTrigger("Melee");
        yield return new WaitForSeconds(0.5f);
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHP>().TakeDamage(meleeDMG);
                Debug.Log("ulthit");
            }
        }
        Debug.Log("hit");
        animator.SetTrigger("Idle");
        StopCoroutine(MeleeAttack());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackPos.position, boxSize);
    }
    private IEnumerator ChargeAttack()
    {
        int count = 30;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        animator.SetTrigger("Charge");
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("Idle");
        for (int i = 0; i < count; i++)
        {
            GameObject clone = Instantiate(_charge, attackPos.transform.position, Quaternion.identity);
            float angle = weightAngle + intervalAngle * i;
            float x = Mathf.Cos(angle * Mathf.PI / 180);
            float y = Mathf.Sin(angle * Mathf.PI / 180);
            clone.GetComponent<GolemChargeBullet>().MoveTo(new Vector3(x, y, 0));
        }
        intervalAngle += 30;
        weightAngle += 1;
        StopCoroutine(ChargeAttack());
    }
    private IEnumerator FollowMissile()
    {
        int count = 1;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        animator.SetTrigger("Arm");
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Idle");
        for (int i = 0; i < count; i++)
        {
            GameObject clone = Instantiate(_followMissile, attackPos.transform.position, Quaternion.identity);
            float angle = weightAngle + intervalAngle * i;
            float x = Mathf.Cos(angle * Mathf.PI / 180);
            float y = Mathf.Sin(angle * Mathf.PI / 180);
        }
        intervalAngle += 30;
        weightAngle += 1;
        StopCoroutine(FollowMissile());
    }

    private IEnumerator LaserAttack()
    {
        animator.SetTrigger("Laser");
        _laser.SetActive(true);
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Idle");
        if (bossHP.currentHP <= 0)
        {
            _laser.SetActive(false);
        }
    }

}
