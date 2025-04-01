using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 10f;

    private void Update()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}

// - логика UseItem 
// - abs 
// - родителя item навешивать на объект
// - 