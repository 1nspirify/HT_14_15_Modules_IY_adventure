using UnityEngine;
using UnityEngine.Serialization;

public abstract class Item : MonoBehaviour
{
    public abstract void Use(Storage owner);
}

