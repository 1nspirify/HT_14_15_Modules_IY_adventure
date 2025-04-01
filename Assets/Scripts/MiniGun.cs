using UnityEngine;

public class MiniGun : Item
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletSpawn;
    [SerializeField] float _shootForce;
    
    public override void UseItem(CharacterStorage characterStorage)
    {
        MakeShot();
    }

    private void MakeShot()
    {
        Rigidbody _rbBulletPrefab = Instantiate(_bulletPrefab, _bulletSpawn.position, _bulletSpawn.rotation)
            .GetComponent<Rigidbody>();
        
        ParticleSystem _bulletParticleSystem = Instantiate(ParticleSystem, _bulletSpawn.position,_bulletSpawn.rotation);
        _bulletParticleSystem.Play();
        
        _rbBulletPrefab.AddForce(_bulletSpawn.forward * _shootForce, ForceMode.Impulse);
    }
}