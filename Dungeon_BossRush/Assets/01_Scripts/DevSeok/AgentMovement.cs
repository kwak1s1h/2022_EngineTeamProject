using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField] private float _speed;

    [SerializeField] private SpriteRenderer _playerRenderer;

    private bool canDash = true;
    private bool isDashing;
    private float dashPower = 24f;
    private float dashTime = 0.5f;
    private float dashCoolTime = 1f;

    [SerializeField] private TrailRenderer tr;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public void ChangeVelocity(Vector2 input)
    {
        _rigid.velocity = input.normalized * _speed;
    }

    public void FlipAgent(Vector2 mousePos)
    {
        _playerRenderer.flipX = transform.position.x > mousePos.x;
    }

    public void IsDash()
    {
        StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        canDash = false;
        isDashing = true;
        //dashing
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDashing = false;
        GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}
