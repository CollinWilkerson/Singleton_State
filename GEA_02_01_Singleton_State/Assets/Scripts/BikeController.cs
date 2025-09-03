using UnityEngine;

namespace Chapter.State
{
    public enum Direction
    {
        Left = -1,
        Right = 1
    }
    public class BikeController : MonoBehaviour
    {
        //general variables
        public float maxSpeed = 2.0f;
        public float turnDistance = 2.0f;

        //whats the point of the getter and setter if we don't do anything with them
        public float CurrentSpeed { get; set; }

        //direction can be seen by anyone, but can only be changed through the state machine
        //reduces coupling?
        public Direction CurrentTurnDirection
        {
            get; private set;
        }
        
        //creates the framework for state transitions
        private IBikeState _startState, _stopState, _turnState;

        private BikeStateContext _bikeStateContext;

        private void Start()
        {
            //individual state components encapsulate behavior
            _bikeStateContext = new BikeStateContext(this);
            _startState = gameObject.AddComponent<BikeStartState>();
            _stopState = gameObject.AddComponent<BikeStopState>();
            _turnState = gameObject.AddComponent<BikeTurnState>();

            //start in the stop state
            _bikeStateContext.Transition(_stopState);
        }

        public void StartBike()
        {
            _bikeStateContext.Transition(_startState);
        }

        public void StopBike()
        {
            _bikeStateContext.Transition(_stopState);
        }

        public void Turn(Direction direction)
        {
            CurrentTurnDirection = direction;
            _bikeStateContext.Transition(_turnState);
        }
    }
}
