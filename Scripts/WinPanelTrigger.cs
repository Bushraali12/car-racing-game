using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelTrigger: MonoBehaviour
{
    public GameObject winPanelObject; 
    public GameObject lossPanelObject;
    public AudioSource audioSource;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player car entered");
            audioSource.Play();
            StartCoroutine(showwinpanel());
        }
        else if (other.tag == "Oponent")
        {
            Debug.Log("Oponent car entered");
            audioSource.Play();
            StartCoroutine(losspanel());
        }
    }
     IEnumerator showwinpanel()
    {
        yield return new WaitForSeconds(1);
        winPanelObject.SetActive(true);
    }
    IEnumerator losspanel()
    {
        yield return new WaitForSeconds(1);
        lossPanelObject.SetActive(true);
    }
}


