using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;

// [RequireComponent(typeof(AgentMovement), typeof(AgentWeapon))]
public class AgentInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput;
    public UnityEvent OnFireButtonInput;
    public UnityEvent<Vector2> OnMousePositionChange;
    public UnityEvent OnDashButtonInput;

    private void Update()
    {
        MoveInput();
        FireInput();
        GetMousePos();
        DashInput();
    }

    private void DashInput()
    {
        if(Input.GetMouseButtonDown(1))
        OnDashButtonInput?.Invoke();
    }

    private void FireInput()
    {
        if(Input.GetMouseButton(0))
        OnFireButtonInput?.Invoke();
    }

    private void MoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        OnMovementInput?.Invoke(new Vector2(x, y));
    }

    private void GetMousePos() 
    {
        OnMousePositionChange?.Invoke(Define.MainCam.ScreenToWorldPoint(Input.mousePosition));
    }
}
