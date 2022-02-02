using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UIArchitecture
{
    public abstract class BaseViewModel<TInteraction, TState>
    {
        private readonly Dictionary<Type, Action<TState>> _stateHandlers =
            new Dictionary<Type, Action<TState>>();

        private readonly Dictionary<Type, AsyncAction<TInteraction>> _interactionHandlers =
            new Dictionary<Type, AsyncAction<TInteraction>>();

        public void OnState<T>(Action<TState> handler) where T : TState
        {
            var typeOfT = typeof(T);
            _stateHandlers[typeOfT] = handler;
        }

        public void Emit<T>(T newState) where T : TState
        {
            var typeOfT = typeof(T);
            _stateHandlers[typeOfT](newState);
        }

        public async void Interact<T>(T interaction) where T : TInteraction
        {
            var typeOfT = typeof(T);
            await _interactionHandlers[typeOfT](interaction);
        }

        protected void OnInteraction<T>(AsyncAction<TInteraction> interactionHandler) where T : TInteraction
        {
            var typeOfT = typeof(T);
            _interactionHandlers[typeOfT] = interactionHandler;
        }
    }
}