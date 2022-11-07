using UnityEngine;
using TMPro;

namespace Game
{
    public class TurnResult : MonoBehaviour
    {
        [SerializeField] private bool _isLastResult;
        [SerializeField] private TextMeshProUGUI[] textTurns;

        public void SetNumberTurn(uint textPlace, string s)
        {
            if (textTurns[textPlace] != null)
            {
                textTurns[textPlace].text = s;
            }
        }
    }
}
