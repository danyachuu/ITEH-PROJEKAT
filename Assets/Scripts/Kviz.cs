using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Kviz : MonoBehaviour
{
    [SerializeField] PitanjeSO pitanje;
    [SerializeField] TextMeshProUGUI pitanjeTekst;

    [SerializeField] GameObject[] ponudjeniOdgovori;

    int tacanOdgovorIndeks;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;



    void Start()
    {
       //DisplayQuestion();
        GetNextQuestion();


    }

    public void OnAnswerSelected(int indeks)
    {
        if (indeks == pitanje.GetTacanOdgovorIndeks())
        {
            pitanjeTekst.text = "Tacan odgovor!";
            Image buttonImage = ponudjeniOdgovori[indeks].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            pitanjeTekst.text = $"Netacan odgovor... Tacan odgovor je {pitanje.GetTacanOdgovorIndeks()+1})";
            Image buttonImage = ponudjeniOdgovori[pitanje.GetTacanOdgovorIndeks()].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }
        SetButtonState(false);
    }

    private void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();

    }

    private void SetDefaultButtonSprites()
    {
        for(int i = 0; i < ponudjeniOdgovori.Length; i++)
        {
            Image buttonImage = ponudjeniOdgovori[i].GetComponentInChildren<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    private void DisplayQuestion()
    {
        pitanjeTekst.text = pitanje.GetQuestion();

        for (int i = 0; i < ponudjeniOdgovori.Length; i++)
        {
            TextMeshProUGUI dugmeTekst = ponudjeniOdgovori[i].GetComponentInChildren<TextMeshProUGUI>();
            dugmeTekst.text = pitanje.GetOdgovor(i);
        }
    }

    private void SetButtonState(bool state)
    {
        for(int i=0;i<ponudjeniOdgovori.Length;++i)
        {
            Button dugme = ponudjeniOdgovori[i].GetComponentInChildren<Button>();
            dugme.interactable = state;
        }
    }

}
