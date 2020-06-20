using System;
using System.Collections.Generic;

namespace WikiDotNet
{
	/// <summary>
	/// A class containing settings for use when searching with <see cref="WikiSearcher.Search" />.
	/// <see cref="WikiSearcher" />
	/// </summary>
	public sealed class WikiSearchSettings
	{
		/// <summary>
		/// What namespaces to search in. Default is {0} (default)
		/// </summary>
		// ReSharper disable once FieldCanBeMadeReadOnly.Global
		public List<int> Namespaces = null;

		/// <summary>
		/// [Backing Field] How many results to return
		/// </summary>
		private int resultLimit = 10;

		/// <summary>
		/// How many results to return
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Occurs when the given value is too high or low</exception>
		public int ResultLimit
		{
			get => resultLimit;
			set
			{
				const int min = 1;
				const int max = 50;
				if (value < min || value > max)
					throw new ArgumentOutOfRangeException(nameof(value),
						$"Value {value} is out of range. Valid range is {min}-{max}");
				resultLimit = value;
			}
		}

		/// <summary>
		/// An amount to offset the search results by. Useful when scrolling through large groups of pages
		/// </summary>
		public int ResultOffset { get; set; }

		/// <summary>
		/// A string that will be returned with the request results. Useful to distinguish multiple requests
		/// </summary>
		public string RequestId { get; set; }

		/// <summary>
		/// The language of the wiki to search in. Default is 'en' (default)
		/// </summary>
		public string Language { get; set; }

		// ReSharper disable once CommentTypo
		/// <summary>
		/// Should we only find results that exactly match our search
		/// Example:
		/// 'Microsoft' results in 'Microsoft'
		/// 'Microsof' results in 'no results'
		/// </summary>
		// ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
		public bool ExactMatch { get; set; } = false;
	}
}