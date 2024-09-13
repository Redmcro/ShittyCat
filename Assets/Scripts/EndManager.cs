using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
