using Data;
using Logic;
using Model;
using System.Numerics;

namespace ViewModel
{
    public class Ball : VM
    {


        private double r = 15;
        private BallModel ball;
        private double X;
        private double Y;

        public Ball()
        {
            ball = new BallModel();
        }
        public Ball(BallModel ballModel)
        {
            X = ballModel.ModelXPosition;
            Y = ballModel.ModelYPosition;
            ball = new BallModel();
        }

        public Vector2 NextPosition { get; set; }
        public Vector2 NextStepVector { get; set; }


        public double BallDiameter
        {
            get
            {
                return r * 2;
            }
        }
        public double XPos
        {
            get
            {
                return ball.ModelXPosition;
            }
            set
            {
                ball.ModelXPosition = value;
                RaisePropertyChanged("XPos");
            }
        }
        public double YPos
        {
            get
            {
                return ball.ModelYPosition;
            }
            set
            {
                ball.ModelYPosition = value;
                RaisePropertyChanged("YPos");
            }
        }

        public Vector2 getPosBallVM()
        {
            return new Vector2((float)XPos, (float)YPos);
        }

        public Vector2 GetBallVMPosition()
        {
            return ball.GetBallPosition();
        }

        public double Radius
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }
    }
}
