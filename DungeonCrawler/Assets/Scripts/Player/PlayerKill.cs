using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKill : MonoBehaviour, IKillable
{
    public bool IsDead { get; private set; }

    public void Kill()
    {
        IsDead = true;
        SceneManager.LoadScene("GameOver");
    }
}
