using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("TestScene");
    }
}
