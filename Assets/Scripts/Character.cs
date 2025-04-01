using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;

    public int Health
    {
        get => _health;
        protected set => _health = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
}