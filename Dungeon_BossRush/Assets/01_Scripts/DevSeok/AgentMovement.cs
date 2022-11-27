using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField] private float _speed;

    [SerializeField] private SpriteRenderer _playerRenderer;

    private bool _canDash = true;
    private bool _isDashing;
    [SerializeField] private float _dashSpeed;
    private float _dashTime = 0.3f;
    private float _dashCoolTime = 1f;

    private float _curSpeed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _curSpeed = _speed;
    }

    void Update()
    {

    }

    public void ChangeVelocity(Vector2 input)
    {
        _rigid.velocity = input.normalized * _curSpeed;
    }

    public void FlipAgent(Vector2 mousePos)
    {
        _playerRenderer.flipX = transform.position.x > mousePos.x;
    }

    public void IsDash()
    {
        if (_canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        _canDash = false;
        _isDashing = true;
        //dashing
        _curSpeed = _dashSpeed;
        yield return new WaitForSeconds(0.2f);
        _curSpeed = _speed;
        yield return new WaitForSeconds(_dashTime);
        _isDashing = false;
        GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(_dashCoolTime);
        _canDash = true;
    }
}
