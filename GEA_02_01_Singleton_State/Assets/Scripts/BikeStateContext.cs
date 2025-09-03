
namespace Chapter.State
{
    /// <summary>
    /// This points to the bike at any moment and provides a front end for us
    /// to change the bike's state
    /// </summary>
    public class BikeStateContext
    {
        public IBikeState CurrentState
        {
            get; set;
        }

        private readonly BikeController _bikeController;
        public BikeStateContext (BikeController bikeController)
        {
            _bikeController = bikeController;
        }

        public void Transition()
        {
            CurrentState.Handle(_bikeController);
        }

        public void Transition(IBikeState state)
        {
            CurrentState = state;
            CurrentState.Handle(_bikeController);
        }
    }
}
