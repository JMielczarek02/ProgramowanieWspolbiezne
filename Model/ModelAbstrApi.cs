using Logic;
using System.Collections;



namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int width { get; }
        public abstract int height { get; }
        public abstract void startMoving();
        public abstract IList start(int ballVal);
        public abstract void stop();


        public static ModelAbstractApi createApi(int Weight, int Height)
        {
            return new ModelApi(Weight, Height);
        }
    }
    internal class ModelApi : ModelAbstractApi
    {
        public override int width { get; }
        public override int height { get; }
        private readonly LogicAbstractApi logicLayer;

        public ModelApi(int Width, int Height)
        {
            width = Width;
            height = Height;
            logicLayer = LogicAbstractApi.createApi(width, height);
        }

        public override void startMoving()
        {
            logicLayer.start();
        }

        public override void stop()
        {
            logicLayer.stop();
        }

        public override IList start(int ballVal) => logicLayer.createBalls(ballVal);

    }

}
