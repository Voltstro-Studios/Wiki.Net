using Newtonsoft.Json;

namespace WikiDotNet
{
    /// <summary>
    /// A class that represents a Wikipedia API error
    /// </summary>
    // ReSharper disable once ClassCannotBeInstantiated
    public sealed class Error
    {
        /// <summary>
        /// What error code does this this error correspond to
        /// </summary>
        [JsonProperty("code")] public readonly string Code = null!;

        /// <summary>
        /// Any extra information the assist with debugging
        /// </summary>
        [JsonProperty("data")] public readonly string Data = null!;

        /// <summary>
        /// What Wikipedia module gave this error
        /// </summary>
        [JsonProperty("module")] public readonly string Module = null!;

        /// <summary>
        /// Information about this error
        /// </summary>
        [JsonProperty("*")] public readonly string Text = null!;

        private Error()
        {
        }
    }
}