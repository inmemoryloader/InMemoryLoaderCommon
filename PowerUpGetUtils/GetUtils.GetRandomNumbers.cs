using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;
using System.Security.Cryptography;

namespace PowerUpGetUtils
{
	public partial class GetUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Erzeugt echte Zufallszahlen
		/// </summary>
		/// <param name="count">Anzahl der zu erzeugenden Zufallszahlen</param>
		/// <param name="min">Die kleinste zu erzeugende Zahl</param>
		/// <param name="max">Die größte zu erzeugende Zahl</param>
		/// <returns>Gibt ein Array mit den erzeugten Zufallszahlen zurück</returns>
		public byte[] GetRandomNumbers(int count, byte min, byte max)
		{
			// Zufallszahlen erzeugen
			RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
			byte[] numbers = new Byte[count];
			csp.GetBytes(numbers);
			// umrechnen
			double divisor = 256F / (max - min + 1);
			if (min > 0 || max < 255)
			{
				for (int i = 0; i < count; i++)
				{
					numbers[i] = (byte)((numbers[i] / divisor) + min);
				}
			}
			return numbers;
		}
	}
}

