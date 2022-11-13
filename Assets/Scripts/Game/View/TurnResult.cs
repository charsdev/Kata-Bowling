using UnityEngine;
using TMPro;

namespace Game
{

    public class TurnResult : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] textTurns;

        public void SetNumberTurn(int index, string s)
        {
            if (textTurns[index] != null)
            {
                textTurns[index].text = s;
            }
        }

        //[SerializeField] private TextMeshProUGUI firstResult;
        //[SerializeField] private TextMeshProUGUI SecondResult;
        //[SerializeField] private TextMeshProUGUI ThirdResult;
        //[SerializeField] private TextMeshProUGUI TotalResult;

        //public void SetFirstResult(string s)
        //{
        //    if (firstResult != null)
        //    {
        //        firstResult.text = s;
        //    }
        //}

        //public void SetSecondResult(string s)
        //{
        //    if (SecondResult != null)
        //    {
        //        SecondResult.text = s;
        //    }
        //}

        //public void SetTotalResult(string s)
        //{
        //    if (TotalResult != null)
        //    {
        //        TotalResult.text = s;
        //    }
        //}

        //public void SetThirdResult(string s)
        //{
        //    if (ThirdResult != null)
        //    {
        //        ThirdResult.text = s;
        //    }
        //}
    }
}
