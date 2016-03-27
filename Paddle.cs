using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Breakernoid
{
    public class Paddle : GameObject
    {
        public Paddle(Game myGame) :
          base(myGame)
        {
            textureName = "paddle";
        }
    }
}
