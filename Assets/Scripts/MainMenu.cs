using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject optionsMenuCanvas;

    public void Start()
    {
       mainMenuCanvas.SetActive(true);
       optionsMenuCanvas.SetActive(false);
    }

    public void PlayGame()
    {
        AudioManager.Instance.PlaySFX("DefaultClick");
        SceneManager.LoadSceneAsync(1);
    }

    public void ShowOptions()
    {
        AudioManager.Instance.PlaySFX("DefaultClick");
        optionsMenuCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void ShowMainMenu()
    {
        AudioManager.Instance.PlaySFX("DefaultClick");
        optionsMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX("DefaultClick");
        Debug.Log("Quit Game!");
        Application.Quit();
    }

}
