using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthPack : Item
{
    [SerializeField] private ParticleSystem _particleSystem;

    private int _maxHealthPoints = 15;
    private int _minHealthPoints = 0;

    private int _healthPointsValue;

    private void Initialize(int _maxHealthPoints, int _minHealthPoints)
    {
        _healthPointsValue = Random.Range(_minHealthPoints, _maxHealthPoints);
    }

    public override void Use(Storage owner)
    {
        HealthContainer healthContainer = owner.GetComponent<HealthContainer>();

        if (healthContainer != null)
        {
            Initialize(_maxHealthPoints, _minHealthPoints);
            healthContainer.Health += _healthPointsValue;

            ParticleSystem _healthParticleSystem = Instantiate(_particleSystem, transform.position, Quaternion.identity);
            _healthParticleSystem.Play();

            Debug.Log($"Boost pack used with {_healthPointsValue}points");
        }
        
        else
        {
            Debug.LogWarning($"HealthContainer not found");
        }
    }
}