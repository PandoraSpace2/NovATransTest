using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Load(int id)
    {
        if (id != SceneManager.GetActiveScene().buildIndex)
            SceneManager.LoadScene(id);
    }

    public void Exit()
    {
        Application.Quit();
    }
}