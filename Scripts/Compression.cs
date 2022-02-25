using System.IO;
using System.IO.Compression;
using UnityEngine;

namespace AudioBox.Compression
{
	public static class Compression
	{
		public static byte[] Compress(string _Path)
		{
			byte[] data;
			using (MemoryStream output = new MemoryStream())
			using (FileStream input = new FileStream(_Path, FileMode.Open, FileAccess.Read))
			using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress, true))
			{
				input.CopyTo(gzip);
				gzip.Flush();
				gzip.Close();
				output.Seek(0, SeekOrigin.Begin);
				data = output.ToArray();
			}
			return data;
		}

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

		public static bool CompressToFile(string _Path, string _DestinationPath, bool _RemoveOriginal = false)
		{
			if (string.IsNullOrEmpty(_Path))
			{
				Debug.LogError("[Compression] Compress to file failed. File path is null or empty.");
				return false;
			}
			
			if (string.IsNullOrEmpty(_DestinationPath))
			{
				Debug.LogError("[Compression] Compress to file failed. Destination file path is null or empty");
				return false;
			}
			
			if (!File.Exists(_Path))
			{
				Debug.LogErrorFormat("[Compression] Compress to file failed. File doesn't exists at path '{0}'.", _Path);
				return false;
			}
			
			using (FileStream output = new FileStream(_DestinationPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
			using (FileStream input = new FileStream(_Path, FileMode.Open, FileAccess.Read))
			using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress, true))
			{
				input.CopyTo(gzip);
			}
			
			if (_RemoveOriginal)
				File.Delete(_Path);
			
			return true;
		}

		public static byte[] Decompress(string _Path)
		{
			byte[] data;
			using (MemoryStream output = new MemoryStream())
			using (FileStream input = new FileStream(_Path, FileMode.Open, FileAccess.Read))
			using (GZipStream gzip = new GZipStream(output, CompressionMode.Decompress, true))
			{
				input.CopyTo(gzip);
				gzip.Flush();
				gzip.Close();
				output.Seek(0, SeekOrigin.Begin);
				data = output.ToArray();
			}
			return data;
		}

		public static byte[] Decompress(byte[] _Data)
		{
			byte[] data;
			using (MemoryStream output = new MemoryStream())
			using (GZipStream gzip = new GZipStream(output, CompressionMode.Decompress, true))
			{
				gzip.Write(_Data, 0, _Data.Length);
				gzip.Flush();
				gzip.Close();
				output.Seek(0, SeekOrigin.Begin);
				data = output.ToArray();
			}
			return data;
		}

		public static bool DecompressToFile(string _Path, string _DestinationPath, bool _RemoveOriginal = false)
		{
			if (string.IsNullOrEmpty(_Path))
			{
				Debug.LogError("[Compression] Decompress to file failed. File path is null or empty.");
				return false;
			}
			
			if (string.IsNullOrEmpty(_DestinationPath))
			{
				Debug.LogError("[Compression] Decompress to file failed. Destination file path is null or empty");
				return false;
			}
			
			if (!File.Exists(_Path))
			{
				Debug.LogErrorFormat("[Compression] Decompress to file failed. File doesn't exists at path '{0}'.", _Path);
				return false;
			}
			
			using (FileStream output = new FileStream(_DestinationPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
			using (FileStream input = new FileStream(_Path, FileMode.Open, FileAccess.Read))
			using (GZipStream gzip = new GZipStream(output, CompressionMode.Decompress, true))
			{
				input.CopyTo(gzip);
			}
			
			if (_RemoveOriginal)
				File.Delete(_Path);
			
			return true;
		}
	}
}