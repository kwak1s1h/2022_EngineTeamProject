using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SamuraiState { Attack1State, Attack2State, UltState }
public class SamuraiController : MonoBehaviour
{
    [SerializeField]
    private SamuraiState bossState;
    private SamuraiAttack bossAttack;
    private SamuraiBossHP bossHP;


    private float _changeAttackType = 3;

    // Start is called before the first frame update
    void Start()
    {
        bossHP = GetComponent<SamuraiBossHP>();
        bossAttack = GetComponent<SamuraiAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_changeAttackType <= 0)
        {
            int rand = Random.Range(1, 3);
            if (rand == 1)
            {
                StartCoroutine(Attack1());
            }
            if (rand == 2)
            {
                StartCoroutine(Attack2());
            }
            _changeAttackType = Random.Range(2, 4);
        }
        _changeAttackType -= Time.deltaTime;
    }

    public void ChangeState(SamuraiState newState)
    {
        StopCoroutine(bossState.ToString());

        bossState = newState;

        StartCoroutine(bossState.ToString());
    }

    private IEnumerator Attack1()
    {
        bossAttack.StartFiring(SamuraiAttackType.Attack1);
        yield return null;
    }
    private IEnumerator Attack2()
    {
        bossAttack.StartFiring(SamuraiAttackType.Attack2);
        yield return null;
    }

    public IEnumerator Ult()
    {
        bossAttack.StartFiring(SamuraiAttackType.UltAttack);
        yield return null;
    }
}
