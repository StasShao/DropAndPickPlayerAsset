using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    protected Rigidbody rb;
    public abstract Rigidbody bulletRigidbody();
    public abstract void Begin();
    private void Awake()
    {
        Begin();
    }
}

