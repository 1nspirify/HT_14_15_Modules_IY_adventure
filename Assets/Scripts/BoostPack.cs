using UnityEngine;

public class BoostPack : Item
{
    [SerializeField] private int _speedPointsValue;
    public int SpeedPointsValue => _speedPointsValue;

    public override void UseItem(CharacterStorage characterStorage)
    {
        Instantiate(ParticleSystem, transform.position, Quaternion.identity);
        characterStorage.AddSpeedPoints(SpeedPointsValue);
        
        Debug.Log($"Boost pack used with {SpeedPointsValue} points");
    }
}