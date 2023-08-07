# Example of a finite state machine
```C#
public class TestStateMachine : StateMachineBehavior
    {
        private class FooState : BaseState
        {
            // Called at the time of state registration in the state machine
            public override void OnRegistered(StateMachineBehavior stateMachine)
            {
                base.OnRegistered(stateMachine);
                Debug.Log($"Foo registered in {stateMachine}");
            }

            // Called when the state machine enters this state
            public override void OnEnter()
            {
                base.OnEnter();
                Debug.Log("Foo entered");
            }

            // Called when the state machine exits this state
            public override void OnExit()
            {
                base.OnExit();
                Debug.Log("Foo exited");
            }

            // Called every frame when the state machine updates the state
            public override void OnUpdate()
            {
                base.OnUpdate();
                Debug.Log("Foo ticked");

                if (Input.GetKeyDown(KeyCode.Q)) TransitTo<BarState>();
            }

            // Called when the state machine is paused with this state or before exiting the state
            public override void OnPause()
            {
                base.OnPause();
                Debug.Log("Foo paused");
            }

            // Called when the state machine is paused with this state or after entering the state
            public override void OnResume()
            {
                base.OnPause();
                Debug.Log("Foo resumed");
            }
        }

        private class BarState : BaseState
        {
            public override void OnRegistered(StateMachineBehavior stateMachine)
            {
                base.OnRegistered(stateMachine);
                Debug.Log($"Bar registered in {stateMachine}");
            }

            public override void OnEnter()
            {
                base.OnEnter();
                Debug.Log("Bar entered");
            }

            public override void OnExit()
            {
                base.OnExit();
                Debug.Log("Bar exited");
            }

            public override void OnUpdate()
            {
                base.OnUpdate();
                Debug.Log("Bar ticked");

                if (Input.GetKeyDown(KeyCode.W)) TransitTo<FooState>();
            }

            public override void OnPause()
            {
                base.OnPause();
                Debug.Log("Bar paused");
            }

            public override void OnResume()
            {
                base.OnPause();
                Debug.Log("Bar resumed");
            }
        }

        // The state that the state machine enters at the beginning
        protected override Type InitialState => typeof(FooState);

        // State registration in a finite state machine
        protected override void RegisterStates()
        {
            RegisterState(new FooState());
            RegisterState(new BarState());
        }
    }
```