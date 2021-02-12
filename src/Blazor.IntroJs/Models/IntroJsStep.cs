namespace Blazor.IntroJs
{
    /// <summary>
    /// Intro Js Step Object to be passed in IntroJsOptions Object
    /// </summary>
    public class IntroJsStep
    {
        /// <summary>
        /// Title to be displayed on the tooltip
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Element that will be focused with the tooltip
        /// </summary>
        public string Element { get; set; }
        /// <summary>
        /// Text to be displayed in the tooltip
        /// </summary>
        public string Intro { get; set; }
    }
}