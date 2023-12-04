using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunMechanicSystem
{
    using PoolSystems;
    public class GunController:IGunControllable
    {
        private Pooler<Bullet> _pooler;
        private Transform _bulletContainer;
        private List<Bullet> _bullets = new();
        private List<float> _bulletTimers = new();
        private IGunControllable _iGuncontrollable;
        private float _bulletLifeTime;
        public GunController()
        {
            
        }
        public GunController(Bullet bulletPrefab,int bulletCount,bool isAutoExpand,Transform bulletContainer,float bulletLifeTime,out IGunControllable igunControllable)
        {
            _bulletContainer = bulletContainer;
            _bulletLifeTime = bulletLifeTime;
            igunControllable = new GunController();
            _iGuncontrollable = igunControllable;
            _pooler = new Pooler<Bullet>(bulletPrefab, bulletCount,isAutoExpand,bulletContainer);
        }

        public bool isShoot(bool isShoot = false)
        {
            return isShoot;
        }

        public void SetShootEffects(Transform targetPoint,ParticleSystem visualEffect, List<AudioClip> clipsList, AudioSource audioSource)
        {
            visualEffect.transform.position = targetPoint.position;
            visualEffect.transform.rotation = targetPoint.rotation;
            visualEffect.Play();
            audioSource.clip = clipsList[Randomizer(clipsList.Count)];
            audioSource.Play();
        }

        public void Shoot(bool shoot,float shootForce, ParticleSystem visualEffect, List<AudioClip> clipsList, AudioSource audioSource)
        {
            BulletLifeTimer();
            if (_iGuncontrollable.isShoot(shoot))
            {
                var bull = _pooler.GetFreeElement();
                _iGuncontrollable.SetShootEffects(_bulletContainer, visualEffect, clipsList, audioSource);
                if (!_bullets.Contains(bull)) { _bullets.Add(bull); _bulletTimers.Add(new float()); }
                bull.transform.position = _bulletContainer.position;
                bull.transform.rotation = _bulletContainer.rotation;
                var rb = bull.bulletRigidbody();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                bull.transform.parent = null;
                rb.AddForce(rb.transform.forward * shootForce, ForceMode.Impulse);
            }

        }
        private void BulletLifeTimer()
        {
            
            for (int i = 0; i < _bullets.Count; i++)
            {
                if (_bullets[i].gameObject.activeInHierarchy)
                {
                    _bulletTimers[i] += 0.2f * Time.deltaTime;
                    if (_bulletTimers[i] >= _bulletLifeTime) { _bulletTimers[i] = 0; _bullets[i].gameObject.SetActive(false); _bullets[i].transform.parent = _bulletContainer; }
                }
            }
        }
        private int Randomizer(int count)
        {
            return Random.Range(0,count);
        }
    }
}