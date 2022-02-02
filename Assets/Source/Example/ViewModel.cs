using System.Threading.Tasks;
using UIArchitecture;

public class ViewModel : BaseViewModel<ViewInteraction, ViewState>
{
    public ViewModel()
    {
        OnInteraction<ViewInteraction.Opened>(HandleOpened);
        OnInteraction<ViewInteraction.ButtonClicked>(HandleButtonClicked);
        OnInteraction<ViewInteraction.TextChanged>(HandleTextChanged);
    }

    private async Task HandleOpened(ViewInteraction interaction)
    {
        Emit(new ViewState.Initial());
    }

    private async Task HandleButtonClicked(ViewInteraction interaction)
    {
        await Task.Delay(2000);
        Emit(new ViewState.Finished());
    }

    private async Task HandleTextChanged(ViewInteraction interaction)
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