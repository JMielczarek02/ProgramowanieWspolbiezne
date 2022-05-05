using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ViewModel;
using System.Numerics;
using System.Windows.Input;
using Logic;


namespace ViewModel
{
    public class Controls : VM
    {
        Ball _ballVM;

        private ObservableCollection<Ball> _items;
        private static System.Timers.Timer? _newTargetTimer;
        private static System.Timers.Timer? _newPositionTimer;
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;
        private int _frameRate = 50;

        public Controls()
        {

            CreateBallsButtonClick = new Commands(() => getBallVMCollection());
            AddBallButtonClick = new Commands(() => AddBallClickHandler());
            RemoveBallButtonClick = new Commands(() => RemoveBallButtonClickHandler());
            _ballVM = new Ball();
        }

        public ICommand CreateBallsButtonClick { get; set; }
        public ICommand AddBallButtonClick { get; set; }
        public ICommand RemoveBallButtonClick { get; set; }


        private void getBallVMCollection()
        {
            if (_newPositionTimer != null)
            {
                _newPositionTimer.Stop();
            }
            if (_newTargetTimer != null)
            {
                _newTargetTimer.Stop();
            }
            Items = new ObservableCollection<Ball>();
            BallViewModelCollection ballVMColl = new BallViewModelCollection();
            Items = ballVMColl.CreateBallVMCollection(_ballQuantity);
            InitBallTargetPosition();
            InitSmoothMovement();
        }

        public ObservableCollection<Ball> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                RaisePropertChanged("Items");
            }
        }
        private void AddBallClickHandler()
        {
            if (String.IsNullOrEmpty(BallQuantityText))
            {
                _ballQuantity = 1;
            }
            else
            {
                _ballQuantity++;
            }

            BallQuantityText = _ballQuantity.ToString();
        }

        private void RemoveBallButtonClickHandler()
        {
            if (_ballQuantity > 1)
                _ballQuantity--;

            BallQuantityText = _ballQuantity.ToString();
        }

        public string BallQuantityText
        {
            get
            {
                return _ballQuantityText;
            }
            set
            {
                _ballQuantityText = value;
                _ballQuantity = int.Parse(_ballQuantityText);
                RaisePropertChanged("BallQuantityText");
            }
        }

        private void InitBallTargetPosition() // initiates and updates target position to which every Ball moves towards
        {
            // sets initial target position
            foreach (var item in Items)
            {
                Vector2 targetPos = _ballVM.getBallPosition();
                item.nextPosition = targetPos;
            }
            // updates target position periodically
            _newTargetTimer = new System.Timers.Timer(1000);
            _newTargetTimer.Elapsed += UpdateBallTargetPositionEvent;
            _newTargetTimer.Start();
        }

        private void InitSmoothMovement()
        {
            // updates current ball position every frame
            _newPositionTimer = new System.Timers.Timer(800 / _frameRate);
            _newPositionTimer.Elapsed += BallSmoothMovementEvent;
            _newPositionTimer.Start();
        }

        private void BallSmoothMovementEvent(object? sender, EventArgs e) // updates ball position each frame
        {
            foreach (var item in Items)
            {
                if (item is Ball)
                {
                    Vector2 currentPos = new Vector2((float)item.xPosition, (float)item.yPosition);
                    Vector2 a = ((item.nextPosition - currentPos) / _frameRate) + currentPos;
                    item.xPosition = a.X;
                    item.yPosition = a.Y;
                }
            }
        }

        private void UpdateBallTargetPositionEvent(object? sender, EventArgs e) // sets target position
        {
            foreach (var item in Items)
            {
                Vector2 targetPos = _ballVM.getBallPosition();
                item.nextPosition = targetPos;
            }
        }
    }
}

