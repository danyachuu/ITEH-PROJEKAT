using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Kviz kviz;
    KrajIgre krajIgre;

    private void Awake()
    {
        kviz = FindObjectOfType<Kviz>();
        krajIgre = FindObjectOfType<KrajIgre>();
    }

    void Start()
    {
        kviz.gameObject.SetActive(true);
        krajIgre.gameObject.SetActive(false);

    }

    
    void Update()
    {
        if(kviz.isComplete) 
        {
            kviz.gameObject.SetActive(false);
            krajIgre.gameObject.SetActive(true);
            krajIgre.ShowFinalScore();
        }

    }

    public void OnReplayLevel()
    {
        AudioManager.Instance.PlaySFX("DefaultClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }






}
