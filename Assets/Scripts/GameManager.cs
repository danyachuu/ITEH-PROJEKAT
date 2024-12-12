using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Kviz kviz;
    KrajIgre krajIgre;

    void Start()
    {
        kviz = FindObjectOfType<Kviz>();
        krajIgre = FindObjectOfType<KrajIgre>();

        kviz.gameObject.SetActive(true);
        krajIgre.gameObject.SetActive(false);


    }

    
    void Update()
    {
        if(kviz.isComplete) 
        {
            kviz.gameObject.SetActive(false);
            krajIgre.gameObject.SetActive(true);
        }

    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }






}
