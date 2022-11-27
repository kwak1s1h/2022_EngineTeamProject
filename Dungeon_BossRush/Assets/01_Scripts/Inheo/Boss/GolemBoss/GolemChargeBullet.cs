using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemChargeBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDMG;

    [SerializeField] Vector3 direction;

    [SerializeField] private SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = rotation;
        Destroy(gameObject, 4f);
    }
    private void Update()
    {
        transform.position += direction * _bulletSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 dir)
    {
        direction = dir;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(_bulletDMG);
            Destroy(gameObject);
            Debug.Log("hit");
        }
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}
