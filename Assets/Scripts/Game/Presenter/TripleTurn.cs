using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TripleTurn : Turn, ITurn
    {

        bool _thirdThrowEnabled = true;
        public string Throw(out bool canAnother)
        {
            _actualThrow++;
           // SetCanStrikeAndSpare();

            int throwedPines = GetRandomPines();
            _leftPines -= throwedPines;

            if (IsStrike(_leftPines))
            {
                canAnother = true;
                if (_actualThrow == 1)
                {
                    if (_thirdThrowEnabled)
                    {
                        _actualThrow = 0;
                    }
                    _thirdThrowEnabled = false;
                    _leftPines = _maxPines;
                }
                else if (_actualThrow == 3)
                {
                    canAnother = false;
                }
                return "X";
            }

            if (IsSpare(_leftPines))
            {
                _actualThrow++;
                canAnother = true;
                return "/";
            }

            if (_actualThrow <= 1  )
            {
                canAnother = true;
            }
            else
            {
                canAnother = false;
            }
            
            return throwedPines.ToString();
        }


        public override bool IsStrike(int left) => left == 0 && (_actualThrow == 1 || _actualThrow == 3);
        public override bool IsSpare(int left) => left == 0 && (_actualThrow == 2);
    }
}
