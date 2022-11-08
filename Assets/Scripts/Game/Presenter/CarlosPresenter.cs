using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CarlosPresenter
    {
        CarlosView _view;
        List<ITurn> turns = new List<ITurn>();
        int actualTurn = 0;

        public CarlosPresenter(CarlosView view)
        {
            _view = view;
            InitTurns();
        }

        void InitTurns()
        {
            //turns.Add(new SimpleTurn());
            //turns.Add(new SimpleTurn());
            //turns.Add(new SimpleTurn());
            //turns.Add(new SimpleTurn());
            //turns.Add(new SimpleTurn());
            //turns.Add(new SimpleTurn());
            //turns.Add(new SimpleTurn());
            //turns.Add(new SimpleTurn());
            //turns.Add(new SimpleTurn());
            turns.Add(new TripleTurn());
            turns.Add(new TripleTurn());
            turns.Add(new TripleTurn());
            turns.Add(new TripleTurn());
            turns.Add(new TripleTurn());
            turns.Add(new TripleTurn());
            turns.Add(new TripleTurn());
            turns.Add(new TripleTurn());
        }
        public void Throw()
        {
            bool canAgain = false;
            string resultado = turns[actualTurn].Throw(out canAgain);

            _view.UpdateView(resultado, actualTurn);


            if (!canAgain)
            {
                actualTurn++;
                if (actualTurn == turns.Count)
                {
                    _view.SetButtonOff();
                }
            }

        }
    }
}
