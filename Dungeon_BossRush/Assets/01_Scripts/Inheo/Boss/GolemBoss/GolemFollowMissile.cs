using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemFollowMissile : MonoBehaviour
{
    Rigidbody2D _rigid;
    [SerializeField] private Transform _target;
    public bool follow = true;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDMG;

    [SerializeField] private SpriteRenderer _sprite;
    
    public float rotSpeed = 200f;

    // Start is called before the first frame update
    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _target = GameObject.Find("Player").GetComponent<Transform>();

        _sprite = GetComponent<SpriteRenderer>();
        FaceTarget();
        Destroy(gameObject, 3f);
    }
    
    // Update is called once per frame
    private void Update()
    {
        MoveToTarget();
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, rotSpeed * Time.deltaTime));
    }
   
    public void MoveToTarget()
    {
        //float dirX = _target.transform.position.x - transform.position.x;
        //float dirY = _target.transform.position.y - transform.position.y;
        //dirX = (dirX < 0) ? -1 : 1;
        //transform.Translate(new Vector2(dirX, dirY) * _bulletSpeed * Time.deltaTime);
        if (follow)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _bulletSpeed * Time.deltaTime);
        }
        else
        {
            _rigid.velocity = Vector2.zero;
        }
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
        Invoke("FaceTarget", 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(_bulletDMG);
            Destroy(gameObject);
            Debug.Log("hit");
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}
