using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Move : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    [SerializeField] private float speed;

    [SerializeField] private Light2D light2D;
    [SerializeField] private GameObject floor;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody2d.velocity = (new Vector2(Input.GetAxis("Horizontal"), 0)) * speed;

        // 조명, 바닥, 카메라 이동
        floor.transform.position = new Vector2(transform.position.x, floor.transform.position.y);
        light2D.transform.position = new Vector2(transform.position.x, light2D.transform.position.y);
    }
}
