using System;
using PowerUpBase;
using log4net;
using System.Text.RegularExpressions;

namespace PowerUpStringUtils
{
	public partial class StringUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Cut the specified value, size and direction.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="size">Size.</param>
		/// <param name="direction">Direction.</param>
		public string Cut(string value, int size, Direction direction)
		{
			string str;
			int length = value.Length;
			int cut;

			if (length > size && direction == Direction.Left)
			{
				cut = length - size;
				str = value.Remove(size, cut);
			}
			else if (length > size && direction == Direction.Right)
			{
				cut = size;
				str = value.Remove(0, cut);
			}
			else
			{
				str = value;
			}
			return str;
		}
	}
}

