using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Unity.FPS.Gameplay
{

    public abstract class State
    {
        public abstract State HandleInput(Player obj, Input input);
        public abstract State Update(Player player);
        public abstract State Exit();
    }
}