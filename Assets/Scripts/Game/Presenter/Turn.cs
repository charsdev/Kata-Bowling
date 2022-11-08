using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    
    public abstract class Turn
    {
        public int _maxPines = 10;
        public int _cantThrows = 2;
        public int _actualThrow = 0;
        public int _leftPines = 10;
        public int _leftThrows;
        public bool _canStrike = true;
        public bool _canSpare = false;


        public void SetCanStrikeAndSpare()
        {
            if (_actualThrow == 1)
            {
                _canStrike = true;
                _canSpare = false;
            }
            else if (_actualThrow == 2)
            {
                _canSpare = true;
                _canStrike = false;
            }
        }

        public int GetRandomPines()
        {
            return Random.Range(0, _leftPines + 1);
        }

        public virtual bool IsStrike(int left) => left == 0 && _canStrike;
        public virtual bool IsSpare(int left) => left == 0 && _canSpare;




    }
}
