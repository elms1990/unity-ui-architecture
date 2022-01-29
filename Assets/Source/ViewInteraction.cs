﻿public abstract class ViewInteraction
{
    public class Opened : ViewInteraction{};
    public class ButtonClicked : ViewInteraction{}

    public class TextChanged : ViewInteraction
    {
        public string Value;

        public TextChanged(string value)
        {
            Value = value;
        }
    }
}