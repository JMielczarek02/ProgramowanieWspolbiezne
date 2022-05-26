﻿using Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;


namespace Logic
{
    public abstract class LogicAbstractApi
    {

        public abstract int getAmount { get; }
        public abstract IList createBalls(int count);
        public abstract void start();
        public abstract void stop();
        public abstract int width { get; set; }
        public abstract int height { get; set; }
        public abstract IBall getBall(int index);
        public abstract void wallCollision(IBall ball);
        public abstract void ballBounce(IBall ball);
        public abstract void ballPositionChanged(object sender, PropertyChangedEventArgs args);



        public static LogicAbstractApi createApi(int width, int height)
        {
            return new LogicApi(width, height);
        }

    }
    internal class LogicApi : LogicAbstractApi
    {
        private readonly DataAbstractApi dataLayer;
        private readonly Mutex mutex = new Mutex();


        public LogicApi(int width, int height)
        {
            dataLayer = DataAbstractApi.createApi(width, height);
            this.width = width;
            this.height = height;

        }

        public override int width { get; set; }
        public override int height { get; set; }

        public override void start()
        {
            for (int i = 0; i < dataLayer.getAmount; i++)
            {
                dataLayer.getBall(i).ballCreateMovementTask(30);

            }
        }

        public override void stop()
        {
            for (int i = 0; i < dataLayer.getAmount; i++)
            {
                dataLayer.getBall(i).ballStop();

            }
        }


        public override void wallCollision(IBall ball)
        {

            double diameter = ball.ballSize;

            double right = width - diameter;

            double down = height - diameter;


            if (ball.ballX <= 0)
            {
                ball.ballX = -ball.ballX;
                ball.ballNewX = -ball.ballNewX;
            }

            else if (ball.ballX >= right)
            {
                ball.ballX = right - (ball.ballX - right);
                ball.ballNewX = -ball.ballNewX;
            }
            if (ball.ballY <= 0)
            {
                ball.ballY = -ball.ballY;
                ball.ballNewY = -ball.ballNewY;
            }

            else if (ball.ballY >= down)
            {
                ball.ballY = down - (ball.ballY - down);
                ball.ballNewY = -ball.ballNewY;
            }
        }

        public override void ballBounce(IBall ball)
        {
            for (int i = 0; i < dataLayer.getAmount; i++)
            {
                IBall secondBall = dataLayer.getBall(i);
                if (ball.ballId == secondBall.ballId)
                {
                    continue;
                }

                if (Collision(ball, secondBall))
                {

                    double m1 = ball.ballWeight;
                    double m2 = secondBall.ballWeight;
                    double v1x = ball.ballNewX;
                    double v1y = ball.ballNewY;
                    double v2x = secondBall.ballNewX;
                    double v2y = secondBall.ballNewY;



                    double u1x = (m1 - m2) * v1x / (m1 + m2) + (2 * m2) * v2x / (m1 + m2);
                    double u1y = (m1 - m2) * v1y / (m1 + m2) + (2 * m2) * v2y / (m1 + m2);

                    double u2x = 2 * m1 * v1x / (m1 + m2) + (m2 - m1) * v2x / (m1 + m2);
                    double u2y = 2 * m1 * v1y / (m1 + m2) + (m2 - m1) * v2y / (m1 + m2);

                    ball.ballNewX = u1x;
                    ball.ballNewY = u1y;
                    secondBall.ballNewX = u2x;
                    secondBall.ballNewY = u2y;
                    return;

                }



            }

        }




        internal bool Collision(IBall a, IBall b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            return Distance(a, b) <= (a.ballSize / 2 + b.ballSize / 2);
        }

        internal double Distance(IBall a, IBall b)
        {
            double x1 = a.ballX + a.ballSize / 2 + a.ballNewX;
            double y1 = a.ballY + a.ballSize / 2 + a.ballNewY;
            double x2 = b.ballX + b.ballSize / 2 + b.ballNewY;
            double y2 = b.ballY + b.ballSize / 2 + b.ballNewY;

            return Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }


        public override IList createBalls(int count)
        {
            int previousCount = dataLayer.getAmount;
            IList temp = dataLayer.createBallsList(count);
            for (int i = 0; i < dataLayer.getAmount - previousCount; i++)
            {
                dataLayer.getBall(previousCount + i).PropertyChanged += ballPositionChanged;
            }
            return temp;
        }
        public override IBall getBall(int index)
        {
            return dataLayer.getBall(index);
        }


        public override int getAmount { get => dataLayer.getAmount; }

        public override void ballPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            mutex.WaitOne();
            wallCollision(ball);
            ballBounce(ball);
            mutex.ReleaseMutex();
        }


    }
}