using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject,3f);
    }
}
