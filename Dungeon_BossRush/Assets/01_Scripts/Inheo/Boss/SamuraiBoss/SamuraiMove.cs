using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _dashSpeed;

    [SerializeField] private GameObject _dash;

    private float _currentSpeed;

    [SerializeField] private SpriteRenderer _sprite;

    Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        _currentSpeed = _speed;
        FaceTarget();
        Invoke("DoDash",4);
    }

    // Update is called once per frame
    private void Update()
    {
        MoveToTarget();
    }

    private void DoDash()
    {
        Invoke("DoDash",4);
        StartCoroutine(Dash());
        Debug.Log("Dash");
    }
    private void MoveToTarget()
    {
        float dirX = _target.transform.position.x - transform.position.x;
        float dirY = _target.transform.position.y - transform.position.y;
        dirX = (dirX < 0) ? -1 : 1;
        transform.Translate(new Vector2(dirX, dirY) * _currentSpeed * Time.deltaTime);
    }
    private void FaceTarget()
    {
        if (_target.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
            _dash.transform.localScale = new Vector3(40,50,0);
        }
        else if (_target.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
            _dash.transform.localScale = new Vector3(-10,14,0);
        }
        Invoke("FaceTarget", 0.5f);
    }

    public IEnumerator Dash()
    {
        _dash.SetActive(true);
        _currentSpeed = _dashSpeed;
        yield return new WaitForSeconds(0.2f);
        _dash.SetActive(false);
        _currentSpeed = _speed;

        StopCoroutine(Dash());
    }
}
