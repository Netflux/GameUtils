using System.Collections.Generic;

namespace GameUtils
{
	public class StateMachine
	{
		private Stack<State> _states;
		private State _activeState;

		/// <summary>
		/// Gets the active state.
		/// </summary>
		public State State
		{
			get { return _states.Count > 0 ? _states.Peek() : null; }
		}

		/// <summary>
		/// Gets the number of states in the state machine.
		/// </summary>
		public int Count
		{
			get { return _states.Count; }
		}

		public StateMachine()
		{
			_states = new Stack<State>();
		}

		/// <summary>
		/// Adds a new state.
		/// </summary>
		/// <param name="state">The new state.</param>
		public void PushState(State state)
		{
			state.Initialize(this);
			state.Load();
			_states.Push(state);
		}

		/// <summary>
		/// Replaces the active state with a new state.
		/// </summary>
		/// <param name="state">The new state.</param>
		/// <returns>The replaced state.</returns>
		public State ReplaceState(State state)
		{
			State oldState = PopState();
			PushState(state);

			return oldState;
		}

		/// <summary>
		/// Removes the active state.
		/// </summary>
		/// <returns>The removed state.</returns>
		public State PopState()
		{
			State oldState = null;

			if (_states.Count > 0)
			{
				oldState = _states.Pop();

				if (oldState != null)
				{
					oldState.Stop();
					oldState.Unload();
					_activeState = State;
				}
			}

			return oldState;
		}

		/// <summary>
		/// Clears all states in the state manager.
		/// </summary>
		public void ClearStates()
		{
			while (_states.Count > 0)
			{
				PopState();
			}
		}

		/// <summary>
		/// Lifecycle method. Call it on each update cycle.
		/// </summary>
		public void Update()
		{
			if (_activeState != null)
			{
				_activeState.Update();
			}

			if (_activeState != State)
			{
				if (_activeState != null)
				{
					_activeState.Stop();
				}

				_activeState = State;

				if (_activeState != null)
				{
					_activeState.Start();
				}
			}
		}

		/// <summary>
		/// Stop and unload each state in the state machine.
		/// </summary>
		public void Unload()
		{
			ClearStates();
		}
	}
}
