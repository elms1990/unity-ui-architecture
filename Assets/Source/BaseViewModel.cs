using System;
using System.Collections.Generic;

public abstract class BaseViewModel<TInteraction, TState>
{
    private readonly Dictionary<Type, Action<TState>> _stateHandlers =
        new Dictionary<Type, Action<TState>>();
    
    private readonly Dictionary<Type, Action<TInteraction>> _interactionHandlers =
        new Dictionary<Type, Action<TInteraction>>();

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

    public void Interact<T>(T interaction) where T : TInteraction
    {
        var typeOfT = typeof(T);
        _interactionHandlers[typeOfT](interaction);
    }

    protected void OnInteraction<T>(Action<TInteraction> interactionHandler) where T : TInteraction
    {
        var typeOfT = typeof(T);
        _interactionHandlers[typeOfT] = interactionHandler;
    }
}