using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakernoid
{
    public class Ball : GameObject
    {
        public float speed = 400;
        public Vector2 direction = new Vector2(0.707f, -0.707f);

        public Ball(Game myGame) :
          base(myGame)
        {
            textureName = "ball";
        }

        public override void Update(float deltaTime)
        {
            position += direction * speed * deltaTime;
            base.Update(deltaTime);
        }

    }
}
