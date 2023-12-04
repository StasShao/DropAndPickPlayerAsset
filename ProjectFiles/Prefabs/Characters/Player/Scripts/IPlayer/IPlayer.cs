using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPlayerControllable
{
    bool isDroppedGun { get; }
    void dropGun(bool isDrop);
}