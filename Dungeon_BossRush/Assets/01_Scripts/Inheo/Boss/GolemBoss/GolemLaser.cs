using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemLaser : MonoBehaviour
{
    public Transform laserFirePoint;

    public float rotSpeed = 150f;

    [SerializeField] private float _laserDMG;

    private void Start()
    {
        laserFirePoint = GetComponent<Transform>();
    }
    private void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, rotSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(_laserDMG);
            Debug.Log("hit");
        }
    }
}
