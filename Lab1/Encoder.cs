using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;

namespace Lab1
	{
	public static class Encoder
		{
		// не понятно, надо хешировать файл или же пароль админа для того
		// чтобы создать гамму для шифровки файла
		static HashAlgorithm hashing = SHA1.Create();

		/// <summary>
		/// Применяет шифрование к файлу
		/// </summary>
		/// <param name="fileName">название файла</param>
		/// <param name="password">пароль администратора</param>
		/// <param name="encode">Шифровать или обратить шифрование</param>
		/// <param name="fileHash">Использовать хеш файла</param>
		public static void ApplyEncoding (string fileName, string password, bool encode = true, bool fileHash = false)
			{
			byte[] hash;
			// get gamma from hash
			if ( fileHash )
				hash = getFileHash(fileName);
			else
				hash = getStringHash(password);

			var gamma = Hasher.getGammaGenerator(hash, !encode);

			var input = encode ? fileName : fileName + ".hash";
			var output = encode ? fileName + ".hash" : fileName;
			applyGamma(input, output, gamma);
			File.Delete(input);
			}

		public static char[] ApplyEncoding (char[] data, byte[] key, bool encode)
			{
			var gamma = Hasher.getGammaGenerator(key, !encode);
			char[] result = Hasher.applyGamma(data, gamma);
			return result;
			}

		public static byte[] getStringHash (string data)
			{
			return hashing.ComputeHash(data.Select(chr => (byte)chr).ToArray());
			}

		public static byte[] getFileHash (string fileName)
			{
			var stream = File.OpenRead(fileName);
			var hash = hashing.ComputeHash(stream);
			stream.Close();
			return hash;
			}


		static void applyGamma (string inputFile, string outputFile, IEnumerable<byte> gamma)
			{
			byte[] input = File.ReadAllBytes(inputFile);
			byte[] encoded = Hasher.applyGamma(input.ToArray(), gamma);
			File.WriteAllBytes(outputFile, encoded);
			}
		}
	}
