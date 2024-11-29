using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tajmer : MonoBehaviour
{
    float timerValue;
    [SerializeField] float vremeZaOdgovor = 16f;
    [SerializeField] float vremeZaReview = 8f;

    public bool isAnsweringQuestion;


    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion == true)
        {
            if(timerValue <= 0)
            {
                timerValue = vremeZaReview;
                isAnsweringQuestion = false;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                timerValue = vremeZaOdgovor;
                isAnsweringQuestion = true;
            }
        }

        if(timerValue<=0)
        {
            timerValue = vremeZaOdgovor;
        }
        Debug.Log(timerValue);
    }


}
