using GunMechanicSystem;
using System.Collections.Generic;
using UnityEngine;

public class BerettaGun : Gun
{
    [Header("Drag bullet prefab")]
    [SerializeField] private Bullet _bullet;
    [Space(5)]
    [Header("Select bullet count")]
    [Range(1,30)][SerializeField] private int _bulletCount;
    [Space(5)]
    [Header("Auto expand bullets in container")]
    [SerializeField] private bool _isAutoExpand;
    [Space(5)]
    [Header("Bullet container parent")]
    [SerializeField] private Transform _bulletContainer;
    [Space(5)]
    [Header("Select value of bullet life time")]
    [Range(0.1f,100.0f)][SerializeField] private float _bulletLifeTime;
    [Space(5)]
    [Header("Select value of shoot power")]
    [Range(0.1f, 10000.0f)][SerializeField] private float _shootForcePower;
    [Space(5)]
    [Header("Select particle effect to shoot effect")]
    [SerializeField] private ParticleSystem _shootEffect;
    [Space(5)]
    [Header("Select AudioSource to play shoot sounds")]
    [SerializeField] private AudioSource _audioSource;
    [Space(5)]
    [Header("Drag all audio clip sounds to randomize shoot sound")]
    [SerializeField] private List<AudioClip> _audioClipList;
    public override GunController m_gunController()
    {
        return gunController;
    }
    public override IGunControllable m_iGunControllable()
    {
        return _igunControllable;
    }
    public override void Shoot()
    {
        m_gunController().Shoot(Input.GetMouseButtonDown(0),_shootForcePower,_shootEffect,_audioClipList,_audioSource);
       
    }
    public override void Begin()
    {
        gunController = new GunController(_bullet, _bulletCount, _isAutoExpand, _bulletContainer,_bulletLifeTime,out _igunControllable);
    }

   
}
