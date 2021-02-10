namespace Blazor.IntroJs
{
    internal static class IntroJsHintPositionStrings
    {
        internal const string TopMiddle = "top-middle";
        internal const string TopLeft = "top-left";
        internal const string TopRight = "top-right";
        internal const string BottomLeft = "bottom-left";
        internal const string BottomRight = "bottom-right";
        internal const string BottomMiddle = "bottom-middle";
        internal const string MiddleLeft = "middle-left";
        internal const string MidleRight = "middle-right";
        internal const string MiddleMiddle = "middle-middle";

        internal static string ConvertToString(this IntroJsHintPosition selection)
        {
            switch (selection)
            {
                case IntroJsHintPosition.TopMiddle:
                    return TopMiddle;
                case IntroJsHintPosition.TopLeft:
                    return TopLeft;
                case IntroJsHintPosition.TopRight:
                    return TopRight;
                case IntroJsHintPosition.BottomLeft:
                    return BottomLeft;
                case IntroJsHintPosition.BottomRight:
                    return BottomRight;
                case IntroJsHintPosition.BottomMiddle:
                    return BottomMiddle;
                case IntroJsHintPosition.MiddleLeft:
                    return MiddleLeft;
                case IntroJsHintPosition.MidleRight:
                    return MidleRight;
                case IntroJsHintPosition.MiddleMiddle:
                    return MiddleMiddle;
                default:
                    return TopMiddle;
            }
        }
    }

    public enum IntroJsHintPosition
    {
        TopMiddle,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        BottomMiddle,
        MiddleLeft,
        MidleRight,
        MiddleMiddle
    }
}
