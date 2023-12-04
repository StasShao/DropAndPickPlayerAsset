using UnityEngine;
using GunMechanicSystem;
public abstract class Gun : MonoBehaviour
{
    protected GunController gunController;
    protected IGunControllable _igunControllable;
    public abstract GunController m_gunController();
    public abstract void Begin();
    public abstract void Shoot();
    public abstract IGunControllable m_iGunControllable();
    private void Start()
    {
        Begin();
    }
}
