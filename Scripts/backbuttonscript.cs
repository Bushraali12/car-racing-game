using UnityEngine;
using UnityEngine.SceneManagement;

public class backbuttonscript : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("mainmenu"); // Load the Main Menu scene
    }
}