using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
    public class TurnResult : MonoBehaviour
    {
        [SerializeField] bool isLastResult;
        [SerializeField] TextMeshProUGUI[] textTurns;


        public void NumberTurnText(int textPlace, string s)
        {
            textTurns[textPlace].text = s;            
        }
    }


}
