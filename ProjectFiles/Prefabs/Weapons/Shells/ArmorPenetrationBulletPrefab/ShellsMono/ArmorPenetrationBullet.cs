using UnityEngine;

public class ArmorPenetrationBullet : Bullet
{
    public override void Begin()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override Rigidbody bulletRigidbody()
    {
        return rb;
    }
}
