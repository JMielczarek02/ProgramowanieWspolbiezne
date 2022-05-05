using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    internal class BallViewModelCollection
    {
        public ObservableCollection<Ball> CreateBallVMCollection(int size)
        {
            BallModelCollection ballModelCollection = new BallModelCollection();
            ballModelCollection.CreateModelCollection(size);
            List<BallModel> ballCollection = ballModelCollection.GetBallModelCollection();
            ObservableCollection<Ball> ballVMCollection = new ObservableCollection<Ball>();
            foreach (BallModel x in ballCollection)
            {
                Ball ballVM = new Ball(x);
                ballVM.xPosition = x.xPosition;
                ballVM.yPosition = x.yPosition;
                ballVMCollection.Add(ballVM);
            }

            return ballVMCollection;
        }
    }
}
