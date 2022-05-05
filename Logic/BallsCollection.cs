using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallsCollection : BallsCollectionApi
    {
        List<LogicApi> collection;
        public override void CreateCollection(int size)
        {
            collection = new List<LogicApi>();
            for(int i = 0; i < size; i++)
            {
                Logic ball = new Logic();
                collection.Add(ball.CreateBall());
            }
        }

        public override List<LogicApi> getCollection()
        {
            return collection;
        }
    }
}
