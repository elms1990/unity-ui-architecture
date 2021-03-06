public abstract class ViewState
{
    public class Initial : ViewState{}

    public class ButtonEnabled : ViewState
    {
        public readonly bool Enabled;

        public ButtonEnabled(bool enabled)
        {
            Enabled = enabled;
        }
    }
    
    public class Finished : ViewState{}
}