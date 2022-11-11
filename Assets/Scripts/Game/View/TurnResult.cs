using UnityEngine;
using TMPro;

namespace Game
{
    public class TurnResult : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] textTurns;

        public void SetNumberTurn(int textPlace, string s)
        {
            if (textTurns[textPlace] != null)
            {
                textTurns[textPlace].text = s;
            }
        }
    }
}
