namespace Blazor.IntroJs
{

    /// <summary>
    /// String to Aid in selecting the hint selection position relative to the target element
    /// </summary>
    public static class IntroJsHintPositionStrings
    {
        /// <summary>
        /// Display at the top middle of the target element
        /// </summary>
        public const string TopMiddle = "top-middle";
        /// <summary>
        /// Display at the top left of the target element
        /// </summary>
        public const string TopLeft = "top-left";
        /// <summary>
        /// Display at the top right of the target element
        /// </summary>
        public const string TopRight = "top-right";
        /// <summary>
        /// Display at the bottom left of the target element
        /// </summary>
        public const string BottomLeft = "bottom-left";
        /// <summary>
        /// Display at the bottom right of the target element
        /// </summary>
        public const string BottomRight = "bottom-right";
        /// <summary>
        /// Display at the middle left of the target element
        /// </summary>
        public const string BottomMiddle = "bottom-middle";
        /// <summary>
        /// Display at the middle left of the target element
        /// </summary>
        public const string MiddleLeft = "middle-left";
        /// <summary>
        /// Display at the bottom right of the target element
        /// </summary>
        public const string MidleRight = "middle-right";
        /// <summary>
        /// Display at the center of the target element
        /// </summary>
        public const string MiddleMiddle = "middle-middle";

        /// <summary>
        /// Converts the Hint Position Enumeration to the correct IntroJs javascript string syntax
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
        public static string ConvertToString(this IntroJsHintPosition selection)
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

    /// <summary>
    /// Enumeration to Aid in selecting the hint selection position relative to the target element
    /// </summary>
    public enum IntroJsHintPosition
    {
        /// <summary>
        /// Display at the top middle of the target element
        /// </summary>
        TopMiddle,
        /// <summary>
        /// Display at the top left of the target element
        /// </summary>
        TopLeft,
        /// <summary>
        /// Display at the top right of the target element
        /// </summary>
        TopRight,
        /// <summary>
        /// Display at the bottom left of the target element
        /// </summary>
        BottomLeft,
        /// <summary>
        /// Display at the bottom right of the target element
        /// </summary>
        BottomRight,
        /// <summary>
        /// Display at the bottom middle of the target element
        /// </summary>
        BottomMiddle,
        /// <summary>
        /// Display at the middle left of the target element
        /// </summary>
        MiddleLeft,
        /// <summary>
        /// Display at the bottom right of the target element
        /// </summary>
        MidleRight,
        /// <summary>
        /// Display at the center of the target element
        /// </summary>
        MiddleMiddle
    }
}
