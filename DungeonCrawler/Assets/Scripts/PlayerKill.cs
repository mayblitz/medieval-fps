using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour, IKillable
{
    public void Kill()
    {
        print("game over");
    }
}
