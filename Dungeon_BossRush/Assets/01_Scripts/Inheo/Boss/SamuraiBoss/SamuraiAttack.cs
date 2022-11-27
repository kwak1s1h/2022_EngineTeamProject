using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum SamuraiAttackType { Attack1, Attack2, UltAttack }

public class SamuraiAttack : MonoBehaviour
{
    Animator animator;
    SamuraiBossHP bossHP;
    SamuraiMove samuraiMove;

    public Transform pos;
    public Transform ultPos;
    public Vector2 boxSize;
    public Vector2 ultSize;

    public GameObject ultImage;
    public GameObject ultExplosion;

    [SerializeField] private float DMG;
    [SerializeField] private float ultDMG;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bossHP = GetComponent<SamuraiBossHP>();
        samuraiMove = GetComponent<SamuraiMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHP.currentHP <= 0)
        {
            StopAllCoroutines();
        }
    }

    public void StartFiring(SamuraiAttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(SamuraiAttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    private IEnumerator Attack1()
    {
        StartCoroutine(samuraiMove.Dash());
        animator.SetTrigger("Attack1");
        yield return new WaitForSeconds(0.4f);
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                //collision.GetComponent<GolemBossHP>().TakeDamage(_bulletDMG);
                Debug.Log("hit");
            }
        }
        //공격
        animator.SetTrigger("Dash");
    }
    private IEnumerator Attack2()
    {
        StartCoroutine(samuraiMove.Dash());
        animator.SetTrigger("Attack2");
        yield return new WaitForSeconds(0.4f);
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHP>().TakeDamage(DMG);
                Debug.Log("hit");
            }
        }
        //공격
        animator.SetTrigger("Dash");
    }
    private IEnumerator UltAttack()
    {
        animator.SetTrigger("Ult");
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("IsUlt");
        ultImage.SetActive(true);
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.75f);
        Time.timeScale = 1f;
        ultImage.SetActive(false);
        Instantiate(ultExplosion, ultPos.transform.position, Quaternion.identity);
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(ultPos.position, ultSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHP>().TakeDamage(ultDMG);
                Debug.Log("ulthit");
            }
        }
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Dash");
    }
}
