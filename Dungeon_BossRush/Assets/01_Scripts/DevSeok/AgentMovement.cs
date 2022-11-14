using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void ChangeVelocity(Vector2 input)
    {
        Debug.Log($"x:{input.x}, y:{input.y}");
    }
}
