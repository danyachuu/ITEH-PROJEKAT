using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int tacniOdgovori = 0;
    int vidjenaPitanja = 0;

    public int GetCorrectAnswers()
    {
        return tacniOdgovori;
    }
    public void PovecajCorrectAnswers()
    {
        tacniOdgovori++;
    }
    public int GetVidjenaPitanja()
    {
        return vidjenaPitanja;
    }
    public void PovecajVidjenaPitanja()
    {
        vidjenaPitanja++;
    }
    public int IzracunajSkor()
    {
        return Mathf.RoundToInt(tacniOdgovori / (float)vidjenaPitanja * 100);
    }

}
