using UnityEngine;

namespace Chapter.State
{
    public class BikeTurnState : MonoBehaviour, IBikeState
    {
        private Vector3 _turnDirection;
        private BikeController _bikeController;

        public void Handle(BikeController bikeController)
        {
            if (!_bikeController)
            {
                _bikeController = bikeController;
            }

            //creates a turn direction
            _turnDirection.x = (float) _bikeController.CurrentTurnDirection;

            //if the bike is moving, turns 90 degrees in the direction specified
            if (_bikeController.CurrentSpeed > 0)
            {
                transform.Translate(_turnDirection * _bikeController.turnDistance);
            }
        }
    }
}