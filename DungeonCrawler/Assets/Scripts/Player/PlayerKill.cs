using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour, IKillable
{
    public void Kill(int force, Direction direction)
    {
        print("game over");
    }
}
