using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject car;                 // Reference to your car GameObject
    public GameObject[] level1Endpoints;   // Array of endpoints for Level 1
    public GameObject[] level2Endpoints;   // Array of endpoints for Level 2
    // public GameObject[] level3Endpoints;   // Array of endpoints for Level 3
    public GameObject[] winPanels;         // Array of win panels for each level
    public GameObject[] lossPanels;        // Array of loss panels for each level
    public GameObject[] opponentCars;      // Array of opponent cars

    private int currentLevel = 0;          // Set the initial level to 0
    private Vector3 carStartPosition;      // To store the car's starting position in the current level
    private Vector3[] opponentCarStartPositionsLevel1; // To store the opponent car's starting positions in level 1
    private Vector3[] opponentCarStartPositionsLevel2; // To store the opponent car's starting positions in level 2
    private Vector3[] opponentCarStartPositionsLevel3; // To store the opponent car's starting positions in level 3

    private void Start()
    {
        // car's starting position 
        carStartPosition = car.transform.position;

        // opponent car's starting positions
        opponentCarStartPositionsLevel1 = new Vector3[opponentCars.Length];
        opponentCarStartPositionsLevel2 = new Vector3[opponentCars.Length];
        opponentCarStartPositionsLevel3 = new Vector3[opponentCars.Length];

        for (int i = 0; i < opponentCars.Length; i++)
        {
            opponentCarStartPositionsLevel1[i] = opponentCars[i].transform.position;
            opponentCarStartPositionsLevel2[i] = opponentCars[i].transform.position;
            opponentCarStartPositionsLevel3[i] = opponentCars[i].transform.position;
        }

        SetEndpointsActive(level1Endpoints, currentLevel == 0);
        SetEndpointsActive(level2Endpoints, currentLevel == 1);
        // SetEndpointsActive(level3Endpoints, currentLevel == 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player car entered");
            StartCoroutine(ShowWinPanel());
        }
        else if (other.tag == "Opponent")
        {
            Debug.Log("Opponent car entered");
            StartCoroutine(ShowLossPanel());
        }
    }

    IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(1);

        // Disable the current level's endpoints
        SetEndpointsActive(level1Endpoints, false);
        SetEndpointsActive(level2Endpoints, false);
        // SetEndpointsActive(level3Endpoints, false);

        // Enable the win panel for the current level
        winPanels[currentLevel].SetActive(true);
    }

    IEnumerator ShowLossPanel()
    {
        yield return new WaitForSeconds(1);

        // Disable the current level's endpoints
        SetEndpointsActive(level1Endpoints, false);
        SetEndpointsActive(level2Endpoints, false);
        // SetEndpointsActive(level3Endpoints, false);

        // Enable the loss panel for the current level
        lossPanels[currentLevel].SetActive(true);
    }

    // Function to progress to the next level (e.g., called when a button is clicked)
    public void GoToNextLevel()
    {
        // Disable the current level's win panel
        winPanels[currentLevel].SetActive(false);

        // Move to the next level
        currentLevel++;

        // Ensure we don't exceed the array bounds
        if (currentLevel >= winPanels.Length)
        {
            currentLevel = 0; // Loop back to the first level
        }

        // Enable the car for the next level
        car.SetActive(true);

        // Reset the car's position to the current level's starting position
        car.transform.position = carStartPosition;

        // Set the opponent car's position to the starting position for the current level
        for (int i = 0; i < opponentCars.Length; i++)
        {
            switch (currentLevel)
            {
                case 0:
                    opponentCars[i].transform.position = opponentCarStartPositionsLevel1[i];
                    break;
                case 1:
                    opponentCars[i].transform.position = opponentCarStartPositionsLevel2[i];
                    break;
                case 2:
                    opponentCars[i].transform.position = opponentCarStartPositionsLevel3[i];
                    break;
            }
        }

        // Enable the endpoints for the next level using the switch statement
        switch (currentLevel)
        {
            case 0:
                SetEndpointsActive(level1Endpoints, true);
                SetEndpointsActive(level2Endpoints, false);
                // SetEndpointsActive(level3Endpoints, false);
                break;
            case 1:
                SetEndpointsActive(level1Endpoints, false);
                SetEndpointsActive(level2Endpoints, true);
                // SetEndpointsActive(level3Endpoints, false);
                break;
            case 2:
                SetEndpointsActive(level1Endpoints, false);
                SetEndpointsActive(level2Endpoints, false);
                // SetEndpointsActive(level3Endpoints, true);
                break;
        }
    }

    // Helper method to set the active state of an array of GameObjects
    private void SetEndpointsActive(GameObject[] endpoints, bool isActive)
    {
        foreach (var endpoint in endpoints)
        {
            endpoint.SetActive(isActive);
        }
    }
}

