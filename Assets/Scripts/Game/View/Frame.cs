using UnityEngine;
using System.Linq;

namespace Game
{
    public class Frame : MonoBehaviour
    {
        public Pin[] Pins;

        public void Reset()
        {
            foreach (var item in Pins)
            {
                item.Reset();
            }
        }

        public void HideFalledPins()
        {
            foreach (var item in Pins)
            {
                if (item.IsFall)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }

        public int GetPinsFalled()
        {
            int sum = 0;

            foreach (var item in Pins)
            {
                if (item.IsFall && item.gameObject.activeSelf)
                {
                    sum++;
                }
            }
           
            return sum;
        }
    }
}