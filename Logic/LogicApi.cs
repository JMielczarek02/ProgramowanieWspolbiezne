using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Data;

namespace Logic
{
   public abstract class LogicApi
    {
        public abstract DataApi getDataApi();
        public abstract LogicApi CreateBall();
        public abstract Vector2 PutBallOnBoard();
        public abstract Vector2 GetBallPosition();
        public abstract void SetBallXPosition(double x);
        public abstract void SetBallYPosition(double y);
        public abstract Vector2 MoveBall(Vector2 position, Vector2 newPosition, int steps);

        public static LogicApi CreateLogic(DataApi data = default(DataApi))
        {
            return new Logic();
        }
    }
}
