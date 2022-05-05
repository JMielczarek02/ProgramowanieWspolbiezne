using System.Collections.ObjectModel;
using Model;

namespace ViewModel
{
    internal class BallViewModelCollection
    {

        public ObservableCollection<Ball> CreateBallVMCollection(int quantity)
        {
            BallModelCollection ballModelCollection = new BallModelCollection();
            ballModelCollection.CreateBallModelCollection(quantity);
            List<BallModel> ballCollection = ballModelCollection.GetBallModelCollection();
            ObservableCollection<Ball> ballVMCollection = new ObservableCollection<Ball>();
            foreach (BallModel ballM in ballCollection)
            {
                Ball ballVM = new Ball(ballM);
                ballVM.XPos = ballM.ModelXPosition;
                ballVM.YPos = ballM.ModelYPosition;
                ballVMCollection.Add(ballVM);
            }

            return ballVMCollection;
        }
    }
}
