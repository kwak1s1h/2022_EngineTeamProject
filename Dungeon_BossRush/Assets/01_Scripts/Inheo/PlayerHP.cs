using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float _playerHP;
    public float currentHP;
    // Start is called before the first frame update
    void Awake()
    {
        currentHP = _playerHP;
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
