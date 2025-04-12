using UnityEngine;
using UnityEngine.Serialization;

public class BoostPack : Item
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _speedPointsValue;

    public override void Use(Storage owner)
    {
        SpeedContainer speedContainer = owner.GetComponent<SpeedContainer>();
        
        if (speedContainer != null)
        {
            ParticleSystem _boostParticleSystem = Instantiate(_particleSystem, transform.position, Quaternion.identity);
            _boostParticleSystem.Play();

            speedContainer.Speed += _speedPointsValue;
            Debug.Log($"Boost pack used with {_speedPointsValue} points");
        }

        else
        {
            Debug.LogWarning($"BoostContainer not found");
        }
    }
}