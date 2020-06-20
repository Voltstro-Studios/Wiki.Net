using Newtonsoft.Json;

namespace WikiDotNet
{
	/// <summary>
	/// A class that represents a Wikipedia API warning. Often returned when invalid parameters/arguments are passed to the
	/// Wikipedia API
	/// </summary>
	// ReSharper disable once ClassCannotBeInstantiated
	public sealed class Warning
	{
		/// <summary>
		/// What warning code does this warning correspond to
		/// </summary>
		[JsonProperty("code")] public readonly string Code;

		/// <summary>
		/// What Wikipedia module gave this warning
		/// </summary>
		[JsonProperty("module")] public readonly string Module;

		/// <summary>
		/// Information about this warning
		/// </summary>
		[JsonProperty("*")] public readonly string Text;

		private Warning()
		{
		}
	}
}