using UnityEngine;

namespace Chapter.State
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;

        public void Handle(BikeController bikeController)
        {
            if (!_bikeController)
            {
                _bikeController = bikeController;
            }

            _bikeController.CurrentSpeed = _bikeController.maxSpeed;
        }

        private void Update()
        {
            //the book does this weird
            if (_bikeController && _bikeController.CurrentSpeed > 0)
            {
                _bikeController.transform.Translate(Vector3.forward *
                    _bikeController.CurrentSpeed * Time.deltaTime);
            }
        }
    }
}
