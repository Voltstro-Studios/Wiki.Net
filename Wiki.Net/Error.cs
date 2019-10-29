using Newtonsoft.Json;

namespace CreepysinStudios.WikiDotNet
{
	public sealed class Error : Warning
	{
		[JsonProperty("data")] public readonly string Data;

		private Error()
		{
		}
	}

	public class Warning
	{
		[JsonProperty("code")] public readonly string Code;
		[JsonProperty("module")] public readonly string Module;
		[JsonProperty("*")] public readonly string Text;

		private protected Warning()
		{
		}
	}
}