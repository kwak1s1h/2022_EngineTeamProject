using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// [RequireComponent(typeof(AgentMovement), typeof(AgentWeapon))]
public class AgentInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput;
    public UnityEvent OnFireButtonInput;

    private void Update()
    {
        MoveInput();
        FireInput();
    }

    private void FireInput()
    {
        if(Input.GetMouseButtonDown(0))
        OnFireButtonInput?.Invoke();
    }

    private void MoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        OnMovementInput?.Invoke(new Vector2(x, y));
    }
}
