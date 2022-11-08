using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface ITurn
    {
        public string Throw(out bool canAnother);
    }
}
