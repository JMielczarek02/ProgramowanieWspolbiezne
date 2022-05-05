using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Numerics;

namespace ViewModel
{
    public class Ball : VM
    {
        private double X;
        private double Y;
        private BallModel ballModel;
        private double r = 10;

        public Ball()
        {
            ballModel = new BallModel();
        }

        public Ball(BallModel model)
        {
            X = model.xPosition;
            Y = model.yPosition;
            ballModel = new BallModel();
        }

        public Vector2 nextPosition { get; set; }
        public Vector2 nextStep { get; set; }

        public double d
        {
            get
            {
                return r * 2;
            }
        }

        public double xPosition
        {
            get
            {
                return ballModel.xPosition;
            }
            set
            {
                ballModel.xPosition = value;
                RaisePropertChanged("xPositionChanged");
            }
        }
        public double yPosition
        {
            get
            {
                return ballModel.yPosition;
            }
            set
            {
                ballModel.yPosition = value;
                RaisePropertChanged("yPositionChanged");
            }
        }

        public Vector2 getViewModelPosition()
        {
            return new Vector2((float)xPosition, (float)yPosition);
        }

        public Vector2 getBallPosition()
        {
            return ballModel.getBallPosition();
        }
        public double R
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
