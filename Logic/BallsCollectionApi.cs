using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public abstract class BallsCollectionApi
    {
        public abstract void CreateCollection(int size);
        public abstract List<LogicApi> getCollection();
        public static BallsCollectionApi CreateCollectionLogic(DataApi data = default(DataApi))
        {
            return new BallsCollection();
        }
    }
}
