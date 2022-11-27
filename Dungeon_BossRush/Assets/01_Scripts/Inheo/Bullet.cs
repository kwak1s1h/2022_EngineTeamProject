using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDMG;
    [SerializeField] Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.GetComponent<GolemBossHP>().TakeDamage(_bulletDMG);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("SamuraiBoss"))
        {
            collision.GetComponent<SamuraiBossHP>().TakeDamage(_bulletDMG);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}
