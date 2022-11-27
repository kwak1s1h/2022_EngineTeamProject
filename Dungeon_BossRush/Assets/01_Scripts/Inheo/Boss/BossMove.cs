using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    [SerializeField] private SpriteRenderer _sprite;

    // Start is called before the first frame update
    private void Start()
    {
        FaceTarget();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveToTarget();
    }
    private void MoveToTarget()
    {
        float dirX = _target.transform.position.x - transform.position.x;
        float dirY = _target.transform.position.y - transform.position.y;
        dirX = (dirX < 0) ? -1 : 1;
        transform.Translate(new Vector2(dirX, dirY) * _speed * Time.deltaTime);
    }
    private void FaceTarget()
    {
        if (_target.position.x - transform.position.x > 0)
        {
            _sprite.flipX = false;
        }
        else if (_target.position.x - transform.position.x < 0)
        {
            _sprite.flipX = true;
        }
        Invoke("FaceTarget", 0.5f);
    }
}
