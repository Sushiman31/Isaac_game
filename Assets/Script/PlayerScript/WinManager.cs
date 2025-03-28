using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject winUI;
    public static WinManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de WinManager dans la scène");
            return;
        }

        instance = this;
    }

    public void OnBossDeath()
    {
        Debug.Log("fin");
        winUI.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}