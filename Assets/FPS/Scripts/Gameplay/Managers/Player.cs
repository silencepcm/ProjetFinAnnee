using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class Player : MonoBehaviour
    {
        private State state;

        public void HandleInput(Input input)
        {
            State s = state.HandleInput(this, input);
            if (s != null)
            {
                state = s;
            }
        }

        public void Update()
        {
            state.Update(this);
        }
    }
}
