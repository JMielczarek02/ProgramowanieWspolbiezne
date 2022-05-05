using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Model
{
    public class BallModelCollection
    {

        List<BallModel> ballCollection;
        private LogicApi logic;
        private BallsCollectionApi ballsCollection;
        public List<BallModel> GetBallModelCollection()
        {
            return ballCollection;
        }
        public void CreateModelCollection(int size)
        {
            logic = LogicApi.CreateLogic();
            ballsCollection = BallsCollectionApi.CreateCollectionLogic();
            ballsCollection.CreateCollection(size);
            List<LogicApi> ballList = ballsCollection.getCollection();
            ballCollection = new List<BallModel>();
            foreach(LogicApi x in ballList)
            {
                BallModel ballModel = new BallModel();
                ballCollection.Add(ballModel);
                ballModel.xPosition = logic.GetBallPosition().X;
                ballModel.yPosition = logic.GetBallPosition().Y;
            }
        }
    }
}
