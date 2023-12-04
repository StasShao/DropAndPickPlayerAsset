using PLayerMechanicSystems;
using UnityEngine;

public class PlayerGuner : PlayerBase
{
    public override void Begin()
    {
        
    }
    public override Character character()
    {
        return _character;

    }
    public override IPlayerControllable m_iplayerControllable()
    {
        return _iPlayerControllable;
    }

    public override void PlayerBehavior()
    {
        character().PlayerShoot();
        m_iplayerControllable().dropGun(Input.GetMouseButtonDown(1));

    }
}
