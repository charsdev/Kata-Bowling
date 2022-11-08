using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SimpleTurn : Turn, ITurn
    {
        public string Throw(out bool canAnother)
        {
            _actualThrow++;
            SetCanStrikeAndSpare();

            int throwedPines = GetRandomPines();
            _leftPines -= throwedPines;

            if (IsStrike(_leftPines))
            {
                canAnother = false;
                return "X";
            }

            if (IsSpare(_leftPines))
            {
                canAnother = false;
                return "/";
            }
            if (_actualThrow == _cantThrows)
            {
                canAnother = false;
            }
            else
            {
                canAnother = true;
            }            
            return throwedPines.ToString();
        }

    }
}
