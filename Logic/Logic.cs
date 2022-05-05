using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Data;

namespace Logic
{
    internal class Logic : LogicApi

    {
        private Vector2 board = new Vector2(750, 750);
        private DataApi data;

        public Logic()
        {
            Vector2 positions = PutBallOnBoard();
            data = DataApi.CreateBall(positions.X, positions.Y);
        }

        public override LogicApi CreateBall()
        {
            Vector2 positions = PutBallOnBoard();
            data = DataApi.CreateBall(positions.X, positions.Y);
            return LogicApi.CreateLogic(data);
        }

        public override Vector2 GetBallPosition()
        {
            return new Vector2((float)data.getXPosition(), (float)data.getYPosition());
        }

        public override DataApi getDataApi()
        {
            return data;
        }

        public override Vector2 MoveBall(Vector2 position, Vector2 newPosition, int steps)
        {
            Vector2 movement = newPosition - position;
            return position + (movement / steps);
        }

        public override Vector2 PutBallOnBoard()
        {
            Random random = new Random();
            double x = random.NextDouble() * board.X; 
            random = new Random();
            double y = random.NextDouble() * board.Y;
            // W razie czego dodac tu 
            y = y + 30;
            return new Vector2((float)x, (float)y);
        }

        public override void SetBallXPosition(double x)
        {
            data.setXPosition(x);
        }

        public override void SetBallYPosition(double y)
        {
            data.setYPosition(y);
        }
    }
}
