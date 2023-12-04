using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunControllable
{
    bool isShoot(bool isShoot = false);
    void SetShootEffects(Transform targetPoint,ParticleSystem visualEffect,List<AudioClip>clipsList,AudioSource audioSource);
}