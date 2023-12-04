using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLayerMechanicSystems
{
    public class  Character:IPlayerControllable
    {
        private List<Collider> _enteringTriggerCach = new();
        private List<Gun> _gunList = new();
        private Transform _gunPosition;
        private bool _isArmed;
        private IPlayerControllable _iPlayerControllable;
        public bool isDroppedGun { get; private set; }
        public void dropGun(bool isDrop)
        {
            isDroppedGun = isDrop;
        }
        public Character()
        {
            
        }
        public Character(Transform gunPosition,out IPlayerControllable iplayerControllable)
        {
            _gunPosition = gunPosition;
            _iPlayerControllable = new Character();
            iplayerControllable = _iPlayerControllable;

        }
        private bool TryGetGun(out Gun gun)
        {
            foreach (var element in _gunList)
            {
                if(element.gameObject.activeInHierarchy)
                {
                    gun = element;
                    return true;
                }
            }
            gun = null;
            return false;
        }
        public Gun GetActiveGun()
        {
            if (TryGetGun(out Gun gun)) { return gun; }
            return null;
        }
        public void AddGun(Gun gun,bool isActiveByDefault = false)
        {
            if(_gunList.Contains(gun)) { return; }
            gun.gameObject.SetActive(isActiveByDefault);
            Debug.Log("Gun added");
            _gunList.Add(gun);

        }
        private void DropGun()
        {
            if (_iPlayerControllable.isDroppedGun)
            {
                if (!GetActiveGun()) return;
                var droppedGun = GetActiveGun();
                for (int i = 0; i < _gunList.Count; i++)
                {
                    if (droppedGun == _gunList[i]) { _enteringTriggerCach[i].enabled = true; _enteringTriggerCach.Remove(_enteringTriggerCach[i]); }
                }
                droppedGun.transform.parent = null;
                _gunList.Remove(droppedGun);
                _isArmed = false;
            }
        }
        public void PlayerShoot()
        {
            DropGun();
            if (!GetActiveGun()) return;
            GetActiveGun().Shoot(); 
        }
        public void OnPickUpGun(Collider col)
        {
            if(_isArmed) return;
            if (col.TryGetComponent<Gun>(out Gun gun)) { AddGun(gun, true); 
                _enteringTriggerCach.Add(col); 
                Debug.Log("Cached");gun.transform.position = _gunPosition.position;
                gun.transform.rotation = _gunPosition.rotation;gun.transform.parent = _gunPosition;
                col.enabled = false;
                _isArmed = true;
            }
        }

        
    }
}