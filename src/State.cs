namespace GameUtils
{
	public class State
	{
		private StateMachine _stateMachine;

		/// <summary>
		/// Gets the state machine containing this state.
		/// </summary>
		public StateMachine StateMachine
		{
			get { return _stateMachine; }
		}

		internal void Initialize(StateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		#region Lifecycle Methods

		/// <summary>
		/// Lifecycle method. Called once when the state is added to a state machine.
		/// </summary>
		public virtual void Load() { }

		/// <summary>
		/// Lifecycle method. Called once when the state transitions to active.
		/// </summary>
		public virtual void Start() { }

		/// <summary>
		/// Lifecycle method. Called each update cycle while the state is active.
		/// </summary>
		public virtual void Update() { }

		/// <summary>
		/// Lifecycle method. Called once when the state transitions to inactive.
		/// </summary>
		public virtual void Stop() { }

		/// <summary>
		/// Lifecycle method. Called once when the state is removed from a state machine.
		/// </summary>
		public virtual void Unload() { }

		#endregion
	}
}
