#region

using System;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	/// <summary>
	///     A struct containing settings for use when searching with <see cref="WikiSearcher" />.
	///     <see cref="WikiSearcher.Search" />
	/// </summary>
	public sealed class WikiSearchSettings
	{
		/// <summary>
		///     [Backing Field] How many results to return
		/// </summary>
		private int resultLimit = 10;

		/// <summary>
		///     How many results to return
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Occurs when the given value is too high or low</exception>
		public int ResultLimit
		{
			get => resultLimit;
			set
			{
				const int min = 1;
				const int max = 500;
				if ((value > min) || (value > max))
					throw new ArgumentOutOfRangeException(nameof(value),
						$"Value {value} is out of range. Valid range is {min}-{max}");
				resultLimit = value;
			}
		}

		/// <summary>
		///     An amount to offset the search results by. Useful when scrolling through large groups of pages
		/// </summary>
		public int ResultOffset { get; set; } = 0;
		
		
	}
}