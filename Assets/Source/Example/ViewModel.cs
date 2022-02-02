using UIArchitecture;

public class ViewModel : BaseViewModel<ViewInteraction, ViewState>
{
    public ViewModel()
    {
        OnInteraction<ViewInteraction.Opened>(HandleOpened);
        OnInteraction<ViewInteraction.ButtonClicked>(HandleButtonClicked);
        OnInteraction<ViewInteraction.TextChanged>(HandleTextChanged);
    }

    private void HandleOpened(ViewInteraction interaction)
    {
        Emit(new ViewState.Initial());
    }

    private void HandleButtonClicked(ViewInteraction interaction)
    {
        Emit(new ViewState.Finished());
    }

    private void HandleTextChanged(ViewInteraction interaction)
    {
        var castInteraction = (ViewInteraction.TextChanged) interaction;
        if (castInteraction.Value.Length > 3)
        {
            Emit(new ViewState.ButtonEnabled(true));
        }
        else
        {
            Emit(new ViewState.ButtonEnabled(false));
        }
    }
}