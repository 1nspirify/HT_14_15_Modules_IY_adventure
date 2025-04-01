using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ParticleSystem ParticleSystem;
    public abstract void UseItem(CharacterStorage characterStorage);
}