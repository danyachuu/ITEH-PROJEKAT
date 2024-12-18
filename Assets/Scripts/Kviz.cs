using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class Kviz : MonoBehaviour
{
    [Header("Pitanja")]
    [SerializeField] PitanjeSO trenutnoPitanje;
    [SerializeField] PitanjeSO dodatoPitanje;
    [SerializeField] TextMeshProUGUI pitanjeTekst;
    [SerializeField] List<PitanjeSO> questions = new List<PitanjeSO>();
    private List<PitanjeSO> questionsIzabrana = new List<PitanjeSO>();

    [Header("Odgovori")]
    [SerializeField] GameObject[] ponudjeniOdgovori;
    int tacanOdgovorIndeks;
    bool odgovorioRanije = true;

    [Header("Dugmici")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Tajmer")]
    [SerializeField] Image timerImage;
    Tajmer timer;

    [Header("Skor")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score scoreKeeper;

    [Header("Slajder")]
    [SerializeField] Slider slajder;

    public bool isComplete;

    void Awake()
    {
        GetTenQuestions();
        timer = FindObjectOfType<Tajmer>();
        scoreKeeper = FindObjectOfType<Score>();
        slajder.maxValue = 10;
        slajder.value = 0;

    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            if (slajder.value == slajder.maxValue)
            {
                isComplete = true;
                return;
            }

            odgovorioRanije = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!odgovorioRanije && !timer.isAnsweringQuestion)
        {
            if(questionsIzabrana.Count < 10)
            {
                scoreText.text = "Skor: " + scoreKeeper.IzracunajSkor() + "%";
                
            }
            
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int indeks)
    {
        DisplayAnswer(indeks);
        odgovorioRanije=true;

        SetButtonState(false);
        timer.CancelTimer();

        scoreText.text = "Skor: " + scoreKeeper.IzracunajSkor() + "%";

       

    }

    void DisplayAnswer(int indeks)
    {
        if (indeks == trenutnoPitanje.GetTacanOdgovorIndeks())
        {
            AudioManager.Instance.PlaySFX("CorrectAnswer");
            pitanjeTekst.text = "Tacan odgovor!";
            Image buttonImage = ponudjeniOdgovori[indeks].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.PovecajCorrectAnswers();
            
        }
        else
        {
            if(timer.timerValue>=2.999f)
            {
                AudioManager.Instance.PlaySFX("IncorrectAnswer");
            }
            
            pitanjeTekst.text = $"Netacan odgovor... Tacan odgovor je {trenutnoPitanje.GetTacanOdgovorIndeks() + 1})";
            Image buttonImage = ponudjeniOdgovori[trenutnoPitanje.GetTacanOdgovorIndeks()].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }
    }

    private void GetNextQuestion()
    {
        Debug.Log(questionsIzabrana.Count);
        if(questionsIzabrana.Count>0) 
        { 
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();

            

            scoreKeeper.PovecajVidjenaPitanja();
            slajder.value++;
        }

    }

    private void GetTenQuestions()
    {
        
        for (int i = 0; i < 10; i++)
        {
            int indeks = Random.Range(0, questions.Count);
            dodatoPitanje = questions[indeks];
            if (questions.Contains(dodatoPitanje))
            {
                questionsIzabrana.Add(dodatoPitanje);
                questions.Remove(dodatoPitanje);
            }
        }
    }

    private void GetRandomQuestion()
    {
        int indeks = Random.Range(0, questionsIzabrana.Count);
        trenutnoPitanje = questionsIzabrana[indeks];
        if (questionsIzabrana.Contains(trenutnoPitanje))
        {
            questionsIzabrana.Remove(trenutnoPitanje);
        }
        
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
        pitanjeTekst.text = trenutnoPitanje.GetQuestion();

        for (int i = 0; i < ponudjeniOdgovori.Length; i++)
        {
            TextMeshProUGUI dugmeTekst = ponudjeniOdgovori[i].GetComponentInChildren<TextMeshProUGUI>();
            dugmeTekst.text = trenutnoPitanje.GetOdgovor(i);
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
