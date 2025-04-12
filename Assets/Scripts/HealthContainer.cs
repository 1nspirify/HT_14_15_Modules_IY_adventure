using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health
    {
        get { return _health; }
        set
        {
            if (value <= 0)
            {
                return;
            }

            _health = value;
        }
    }
}