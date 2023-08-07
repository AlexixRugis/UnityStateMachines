namespace AlexixRugis.Unity.StateMachines
{
    public abstract class BaseState
    {
        protected StateMachineBehavior StateMachine { get; private set; }
        protected bool Paused { get; private set; }

        public void TransitTo<T>() where T : BaseState
        {
            StateMachine.TransitTo<T>();
        }

        /// <summary>
        /// Called at the time of state registration in the state machine
        /// </summary>
        public virtual void OnRegistered(StateMachineBehavior stateMachine)
        {
            StateMachine = stateMachine;
        }

        /// <summary>
        /// Called when the state machine enters this state
        /// </summary>
        public virtual void OnEnter() { }

        /// <summary>
        /// Called when the state machine exits this state
        /// </summary>
        public virtual void OnExit() { }

        /// <summary>
        /// Called every frame when the state machine updates the state
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// Called when the state machine is paused with this state or before exiting the state
        /// </summary>
        public virtual void OnPause() {
            Paused = true;
        }

        /// <summary>
        /// Called when the state machine is paused with this state or after entering the state
        /// </summary>
        public virtual void OnResume() {
            Paused = false;
        }
    }
}
