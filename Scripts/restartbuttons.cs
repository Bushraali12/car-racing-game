using UnityEngine;
using UnityEngine.SceneManagement;

public class restartbuttons : MonoBehaviour
{
    public int sceneToLoad = 1; 
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

