using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameModel
    {
        int _totalScore;

        const int _totalTurns = 10;
        const int _maxPines = 10;
        const int _maxThrows = 2;

        int _throwIndex = 1;
        int _leftPines = _maxPines;
        int _roundIndex = 1;


       

        public string Throw()
        {
            int fall = 0;
            if (_throwIndex == 1)
            {
                fall = Random.Range(0, _maxPines + 1);
               
                if (!ThereStandPines())
                {                  
                    return "X";
                }

                return fall.ToString();
            }

            fall = Random.Range(0, _leftPines + 1);

            if (!ThereStandPines())
            {
                return "/";
            }
            
            return fall.ToString();
        }

        public bool ThereStandPines() => _leftPines != 0;
        
        public void CleanPines(int amount) => _leftPines -= amount;
        

        public void NewRound()
        {
            if (EndGame()) return;
            
            _roundIndex++;       
            _throwIndex = 1;
            _leftPines = _maxPines;
        }

        public bool EndGame()
        {
            return _roundIndex > _totalTurns;
        }


        public void StartNextThrow() { _throwIndex++; }
        public int GetCurrentTurn() => _roundIndex;
        public int GetThrowIndex() => _throwIndex;

    }
}
