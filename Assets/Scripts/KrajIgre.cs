using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KrajIgre : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI konacanSkorText;
    Score scoreKeeper;



    void Start()
    {
        scoreKeeper = FindObjectOfType<Score>();
        ShowFinalScore();
    }

    public void ShowFinalScore()
    {
        konacanSkorText.text = "Cestitamo!\nProcenat tacnih odgovora je " + scoreKeeper.IzracunajSkor() + "%"; 
    }

    
}
