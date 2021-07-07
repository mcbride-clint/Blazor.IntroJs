namespace Blazor.IntroJs
{
    /// <summary>
    /// Intro Js Hint Object to be passed in IntroJsOptions Object
    /// </summary>
    public class IntroJsHint
    {
        /// <summary>
        /// Text to be displayed in the Hint
        /// </summary>
        public string Hint { get; set; }
        /// <summary>
        /// Element that the hint will be associated with
        /// </summary>
        public string Element { get; set; }
        /// <summary>
        /// Position of hint on the associated object.  Use the IntroJsHintPositionStrings static constants
        /// </summary>
        public string HintPosition { get; set; } = IntroJsHintPositionStrings.TopMiddle;
        /// <summary>
        /// Enable or Disable the ahow animation
        /// </summary>
        public bool HintAnimation { get; set; } = true;
    }
}