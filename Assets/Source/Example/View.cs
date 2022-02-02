using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _buttonText;
    [SerializeField] private InputField _textField;
    [SerializeField] private Text _currentState;

    private readonly ViewModel _viewModel = new ViewModel();

    private void Awake()
    {
        _viewModel.OnState<ViewState.Initial>(HandleInitialState);
        _viewModel.OnState<ViewState.ButtonEnabled>(HandleButtonEnabled);
        _viewModel.OnState<ViewState.Finished>(HandleStateFinished);

        _textField.onValueChanged.AddListener((value) =>
        {
            _viewModel.Interact(new ViewInteraction.TextChanged(value));
        });
        _button.onClick.AddListener(() =>
        {
            _viewModel.Interact(new ViewInteraction.ButtonClicked());
        });
        
        _viewModel.Interact(new ViewInteraction.Opened());
    }

    private void HandleInitialState(ViewState state)
    {
        UpdateButton(false);
        UpdateCurrentState(state);
    }

    private void HandleButtonEnabled(ViewState state)
    {
        UpdateButton(((ViewState.ButtonEnabled) state).Enabled);
        UpdateCurrentState(state);
    }

    private void HandleStateFinished(ViewState state)
    {
        UpdateCurrentState(state);
    }

    private void UpdateButton(bool isEnabled)
    {
        _button.enabled = isEnabled;
        _buttonText.text = $"Click Me (Enabled: {isEnabled})";
    }

    private void UpdateCurrentState(ViewState state)
    {
        _currentState.text = $"State: {state}";
    }
}