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

		public static char[] applyGamma (char[] data, IEnumerable<byte> gamma)
			{
			Encoding Encoding = Encoding.Unicode;
			var incoming = Encoding.GetBytes(data);
			char[] buffer = new char[data.Length];
			byte[] temp = new byte[2];
			var iter = gamma.GetEnumerator();
			for ( int i = 0; i < data.Length; i++ )
				{
				iter.MoveNext();
				temp[0] = (byte)( incoming[2 * i] + iter.Current );
				iter.MoveNext();
				temp[1] = (byte)( incoming[2 * i + 1] + iter.Current );
				buffer[i] = Encoding.GetChars(temp)[0];
				}

			return buffer;
			}

		public static byte[] applyGamma (byte[] data, IEnumerable<byte> gamma)
			{
			byte[] buffer = new byte[data.Length];
			var iter = gamma.GetEnumerator();
			for ( int i = 0; i < data.Length; i++ )
				{
				iter.MoveNext();
				buffer[i] = (byte)( data[i] + iter.Current );
				}
			return buffer;
			}

		public static IEnumerable<byte> getGammaGenerator (byte[] key, bool revert = false)
			{
			int seed = sumPassword(key.Select(b => (char)b).ToArray());
			var Randomizer = new Random(seed);
			while ( true )
				yield return revert ? (byte)( 256 - Randomizer.Next(256) ) : (byte)Randomizer.Next(256);
			}

		public static char[] HashData (char[] data)
			{
			var gamma = getGammaGenerator(data.Select(c => (byte)c).ToArray());
			return applyGamma(data, gamma);
			}
		}
	}
