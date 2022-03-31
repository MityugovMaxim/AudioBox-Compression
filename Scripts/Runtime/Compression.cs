using System.IO;
using System.IO.Compression;
using UnityEngine;

namespace AudioBox.Compression
{
	public static class Compression
	{
		public static byte[] Compress(byte[] _Data)
		{
			byte[] data;
			using (MemoryStream output = new MemoryStream())
			using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress, true))
			{
				gzip.Write(_Data, 0, _Data.Length);
				gzip.Flush();
				gzip.Close();
				output.Seek(0, SeekOrigin.Begin);
				data = output.ToArray();
			}
			return data;
		}

		public static byte[] Decompress(byte[] _Data)
		{
			using (MemoryStream output = new MemoryStream())
			{
				using (MemoryStream input = new MemoryStream(_Data))
				using (GZipStream gzip = new GZipStream(input, CompressionMode.Decompress, true))
				{
					const int size   = 4096;
					byte[]    buffer = new byte[size];
					{
						int count = 0;
						do
						{
							count = gzip.Read(buffer, 0, size);
							if (count > 0)
								output.Write(buffer, 0, count);
						}
						while (count > 0);
					}
				}
				output.Seek(0, SeekOrigin.Begin);
				return output.ToArray();
			}
		}
	}
}
