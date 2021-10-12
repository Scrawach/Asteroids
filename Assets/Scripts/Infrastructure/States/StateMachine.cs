using System;
using System.Collections.Generic;
using Infrastructure.States.Abstract;

namespace Infrastructure.States
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _current = new NullState();

        public StateMachine(Dictionary<Type, IState> states) => 
            _states = states;

        public void Enter<TState>() where TState : IDefaultState => 
            ChangeStateTo<TState>().Enter(this);

        public void Enter<TState, TPayload>(TPayload payload) where TState : IPayloadState<TPayload> => 
            ChangeStateTo<TState>().Enter(this, payload);

        private TState ChangeStateTo<TState>() where TState : IState
        {
            _current.Exit();
            var nextState = Next<TState>();
            _current = nextState;
            return nextState;
        }

        private TState Next<TState>() where TState : IState =>
            (TState) _states[typeof(TState)];

        private class NullState : IState
        {
            public void Exit() { }
        }
    }
}