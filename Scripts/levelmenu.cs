using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmenu : MonoBehaviour
{
    // public int sceneToLoad = 1; 
    public void level1()
    {
        // Debug.Log("Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(1);
    }
}
