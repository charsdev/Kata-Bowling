using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

namespace Game
{
    public class TurnResult : MonoBehaviour
    {
        [SerializeField] private bool _isLastResult;
        [SerializeField] private TextMeshProUGUI[] textTurns;
        [SerializeField] private int total;

        public void SetNumberTurn(int textPlace, string s)
        {
            if (textTurns[textPlace] != null)
            {
                textTurns[textPlace].text = s;
            }
        }

        //internal void SetTotal(int v)
        //{
        //    if (_isLastResult)
        //    {
        //        textTurns[3].text = v.ToString();
        //        return;
        //    }

        //    textTurns[2].text = v.ToString();
        //}
    }
}
