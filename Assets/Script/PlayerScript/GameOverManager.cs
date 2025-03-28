using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()//si le player meurt on rend visible l'UI
    {
        gameOverUI.SetActive(true);
    }

    public void QuitButton()//permet de quitter le jeu au click
    {
        Application.Quit();
    }
}

