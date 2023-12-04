using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerBase player;
    void Update()
    {
        player.PlayerBehavior();
    }
}
