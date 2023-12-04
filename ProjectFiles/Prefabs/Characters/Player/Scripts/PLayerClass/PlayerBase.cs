using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLayerMechanicSystems;
public abstract class PlayerBase : MonoBehaviour
{
    protected Character _character;
    protected IPlayerControllable _iPlayerControllable;
    [SerializeField]private Transform _gunPosition;
    public abstract Character character();
    public abstract IPlayerControllable m_iplayerControllable();
    public abstract void PlayerBehavior();
    public abstract void Begin();
    private void OnTriggerEnter(Collider other)
    {
        character().OnPickUpGun(other);
    }
    private void Start()
    {
        _character = new(_gunPosition,out _iPlayerControllable);
        Begin();
    }
}
