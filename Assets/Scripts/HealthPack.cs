using Random = UnityEngine.Random;
using UnityEngine;

public class HealthPack : Item
{
    private int _maxHealthPoints = 15;
    private int _minHealthPoints = 0;

    private void Awake()
    {
        Initialize(_maxHealthPoints, _minHealthPoints);
    }

    public int HealthPointsValue { get; set; }

    public void Initialize(int _maxHealthPoints, int _minHealthPoints)
    {
        HealthPointsValue = Random.Range(_minHealthPoints, _maxHealthPoints);
    }

    public override void UseItem(CharacterStorage characterStorage)
    {
        Instantiate(ParticleSystem, transform.position, Quaternion.identity);
        characterStorage.AddHealthPoints(HealthPointsValue);
        
        Debug.Log($"Boost pack used with {HealthPointsValue}points");
    }
}