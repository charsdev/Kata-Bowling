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

        public void UnFreezePins()
        {
            foreach (var item in Pins)
            {
                item.UnFreeze();
            }
        }

        public void HideFalledPins()
        {
            foreach (var item in Pins)
            {
                if (!item.IsStanding)
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
                if (item.gameObject.activeSelf && !item.IsStanding)
                {
                    sum++;
                }
                else
                {
                    item.Freeze();
                }
            }
           
            return sum;
        }
    }
}