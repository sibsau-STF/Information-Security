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

			Encoding Encoding = Encoding.Unicode;
			var incoming = Encoding.GetBytes(password);
			char[] buffer = new char[password.Length];

			for ( int i = 0; i < password.Length; i++ )
				buffer[i] = Encoding.GetChars(BitConverter.GetBytes(incoming[i] + gamma[i]))[0];

			return buffer;
			}

		public static char[] applyGamma (char[] data, IEnumerator<byte> gamma)
			{
			Encoding Encoding = Encoding.Unicode;
			var incoming = Encoding.GetBytes(data);
			char[] buffer = new char[data.Length];
			byte[] temp = new byte[2];
			for ( int i = 0; i < data.Length; i++ )
				{
				temp[0] = (byte)(incoming[2*i] + gamma.Current);
				gamma.MoveNext();
				temp[1] = (byte)( incoming[2*i+1] + gamma.Current );
				gamma.MoveNext();
				buffer[i] = Encoding.GetChars(temp)[0];
				}
			
			return buffer;
			}

		public static IEnumerable<char> getGamma (char[] key, int length, bool revert = false)
			{
			int seed = sumPassword(key);
			var Randomizer = new Random(seed);
			for ( int i = 0; i < length; i++ )
				yield return revert ? (char)( 256 - Randomizer.Next(256) ) : (char)Randomizer.Next(256);
			}

		public static IEnumerable<byte> getGamma (byte[] key, int length, bool revert = false)
			{
			int seed = sumPassword(key.Select(b => (char)b).ToArray());
			var Randomizer = new Random(seed);
			for ( int i = 0; i < length; i++ )
				yield return revert ? (byte)( 256 - Randomizer.Next(256) ) : (byte)Randomizer.Next(256);
			}

		public static IEnumerator<byte> getGammaGenerator (byte[] key, bool revert = false)
			{
			int seed = sumPassword(key.Select(b => (char)b).ToArray());
			var Randomizer = new Random(seed);
			while ( true )
				yield return revert ? (byte)( 256 - Randomizer.Next(256) ) : (byte)Randomizer.Next(256);
			}

		public static char[] HashData (char[] data)
			{
			var gamma = getGamma(data, data.Length);
			return applyGamma(data, gamma.ToArray());
			}
		}
	}
