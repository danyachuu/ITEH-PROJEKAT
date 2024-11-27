using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Kviz Pitanje", fileName = "Novo Pitanje")]
public class PitanjeSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField]string pitanje = "Unesi novo pitanje";
    [SerializeField]string[] odgovori = new string[4];
    [SerializeField]int tacanOdgovorIndeks;


    public string GetQuestion()
    {
        return pitanje;
    }
    public int GetTacanOdgovorIndeks()
    {
        return tacanOdgovorIndeks;
    }
    public string GetTacanOdgovor(int tacanOdgovorIndeks)
    {
        return odgovori[tacanOdgovorIndeks];
    }

}
