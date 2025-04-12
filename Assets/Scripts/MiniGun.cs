using UnityEngine;

public class MiniGun : Item
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private float _shootForce;
    [SerializeField] private ParticleSystem ParticleSystem;

    public override void Use(Storage owner)
    {
        MakeShot();
    }

    private void MakeShot()
    {
        Rigidbody bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, _bulletSpawn.rotation);

        ParticleSystem _bulletParticleSystem =
            Instantiate(ParticleSystem, _bulletSpawn.position, _bulletSpawn.rotation);
        _bulletParticleSystem.Play();

        bullet.AddForce(_bulletSpawn.forward * _shootForce, ForceMode.Impulse);
    }
}