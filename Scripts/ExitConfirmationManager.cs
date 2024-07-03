using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitConfirmationManager : MonoBehaviour
{
    public GameObject exitPanel;
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel; // Add a reference to the level selection panel

    public void ShowExitPanel()
    {
        exitPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("QUITTING APPLICATION");
        Application.Quit();
    }

    public void CancelExit()
    {
        exitPanel.SetActive(false);
        mainMenuPanel.SetActive(true); // Show the main menu panel
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false); // Hide the main menu panel
        // levelSelectionPanel.SetActive(true); // Show the level selection panel
        SceneManager.LoadScene(1);
    }
    public void BackToMainMenu()
    {
        levelSelectionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}

