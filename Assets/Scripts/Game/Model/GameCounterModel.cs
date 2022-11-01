using System.Collections;
using System.Collections.Generic;
using System;
using Game.View;


namespace Game.Model
{
    public class GameCounterModel
    {
        int _actualMarker;
        List<BowlThrowMarkerView> bowlsThrows;

        public GameCounterModel(List<BowlThrowMarkerView> markers)
        {
            _actualMarker = 0;
            bowlsThrows = markers;
        }
        public void ThrowPines(int pinesFalled)
        {
            if (_actualMarker == 10)
            {

            }
            else
            {
                if (pinesFalled == 10)
                {
                    bowlsThrows[_actualMarker].MakeMark("X");
                    MovePointer();
                    return;
                }

                bowlsThrows[_actualMarker].MakeMark(pinesFalled.ToString());
                if (bowlsThrows[_actualMarker].MarkerFully())
                {
                    MovePointer();
                }
            }

        }

        void MovePointer()
        {
            _actualMarker++;
        }



    }

}