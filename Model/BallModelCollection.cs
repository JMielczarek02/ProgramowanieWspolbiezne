using Logic;
namespace Model
{
    public class BallModelCollection
    {
        List<BallModel> ballCollection;
        private LogicApi logic;
        private BallsCollectionApi logicCollection;
        public void CreateBallModelCollection(int quantity)
        {
            logic = LogicApi.CreateObjLogic();
            logicCollection = BallsCollectionApi.CreateObjCollectionLogic();
            logicCollection.CreateBallCollection(quantity);
            List<LogicApi> ballCollection = logicCollection.GetBallCollection();
            this.ballCollection = new List<BallModel>();
            foreach (LogicApi x in ballCollection)
            {
                BallModel ballModel = new BallModel();
                this.ballCollection.Add(ballModel);
                ballModel.ModelXPosition = logic.getBallPosition().X;
                ballModel.ModelYPosition = logic.getBallPosition().Y;
            }
        }

        public List<BallModel> GetBallModelCollection()
        {
            return ballCollection;
        }

    }
}
