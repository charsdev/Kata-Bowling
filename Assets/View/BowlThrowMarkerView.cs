using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlThrowMarkerView : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _firstThrowIndicator;
    [SerializeField] TextMeshProUGUI _secondThrowIndicator;
    [SerializeField] TextMeshProUGUI _totalIndicator;

    //PONER A MODEL
    Queue<TextMeshProUGUI> textMarkers = new Queue<TextMeshProUGUI>();



    private BowlThrowMarkerPresenter _presenter;


    void Start()
    {
        _presenter = new BowlThrowMarkerPresenter(this);
        textMarkers.Enqueue(_firstThrowIndicator);
        textMarkers.Enqueue(_secondThrowIndicator);
    }


    public void MakeMark(string point)
    {
        TextMeshProUGUI txtActual = textMarkers.Dequeue();

        if (point == "10")
        {
            txtActual.text = "X";
            return;
        }

        txtActual.text = point;

        if (textMarkers.Count == 0)
        {
            SetTotal(CheckX(_firstThrowIndicator.text) + CheckX(_secondThrowIndicator.text));
        }
    }

    void SetTotal(int amount)
    {
        _totalIndicator.text = amount.ToString() ;
    }

    public bool MarkerFully()
    {
        if (textMarkers.Count == 0) return true;

        return false;
    }


    int CheckX(string txt)
    {
        if (txt == "X")
        {
            return 10;
        }
        if (txt == "")
        {
            return 0;
        }

        return int.Parse(txt);
    }

}
