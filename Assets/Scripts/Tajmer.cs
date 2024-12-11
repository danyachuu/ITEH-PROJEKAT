using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tajmer : MonoBehaviour
{
    float timerValue;
    [SerializeField] float vremeZaOdgovor = 16f;
    [SerializeField] float vremeZaReview = 8f;

    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;
    public float fillFraction;


    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }



    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion == true)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / vremeZaOdgovor;
            }
            else
            {
                timerValue = vremeZaReview;
                isAnsweringQuestion = false;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / vremeZaReview;
            }
            else
            {
                timerValue = vremeZaOdgovor;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }

        if(timerValue<=0)
        {
            timerValue = vremeZaOdgovor;
        }
        Debug.Log(timerValue);
    }


}
