using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using System.Numerics;

namespace Model
{
    public class BallModel

    {
        private LogicApi logic;
        private double X;
        private double Y;

        public BallModel()
        {
            logic = LogicApi.CreateLogic();
            X = logic.GetBallPosition().X;
            Y = logic.GetBallPosition().Y;
        }
        public double xPosition
        {
            get
            {
                return logic.GetBallPosition().X;
            }
            set
            {
                logic.SetBallXPosition(value);
            }
        }
        public double yPosition
        {
            get
            {
                return logic.GetBallPosition().Y;
            }
            set
            {
                logic.SetBallYPosition(value);
            }
        }
        public Vector2 getModelPosition()
        {
            return new Vector2((float)xPosition, (float)xPosition); //Tu moze byc blad
        }

        public Vector2 getBallPosition()
        {
            return logic.PutBallOnBoard();
        }

    }
}
