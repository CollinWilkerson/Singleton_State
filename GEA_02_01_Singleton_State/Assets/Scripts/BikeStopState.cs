using UnityEngine;

namespace Chapter.State
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;

        //gets a bikecontroller if it doesn't have one, sets speed to 0
        public void Handle(BikeController bikeController)  
        {
            if (!_bikeController)
            {
                _bikeController = bikeController;
            }

            _bikeController.CurrentSpeed = 0;
        }
    }
}
