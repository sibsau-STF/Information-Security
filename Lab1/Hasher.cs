using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Lab1
	{
	public static class Hasher
		{

		static int sumPassword (char[] password) => password
								.Aggregate<char, int>(0, (acc, c) => ( acc + c ) % 256);

		public static char[] applyGamma (char[] password, char[] gamma)
			{
			if ( password.Length != gamma.Length )
				return null;

			char[] buffer = new char[gamma.Length];
			for ( int i = 0; i < password.Length; i++ )
				buffer[i] = (char)( ( password[i] + gamma[i] ) % 256 );
			return buffer;
			}

		public static byte applyGamma (byte data, byte gamma)
			{
			return (byte)( data + gamma );
			}

		public static char[] HashData (char[] data)
			{
			int seed = sumPassword(data);
			var Randomizer = new Random(seed);
			var gamma = data.Select(c => (char)Randomizer.Next(256)).ToArray();
			return applyGamma(data, gamma);
			}

		public static byte HashByte (byte data)
			{
			var Randomizer = new Random(data);
			byte gamma = (byte)Randomizer.Next(256);
			return applyGamma(data, gamma);
			}
		}
	}
