using UnityEngine;

public class SpeedContainer : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    public float Speed
    {
        get { return _speed; }
        set
        {
            if (value <= 0)
            {
                return;
            }

            _speed = value;
        }
    }
}