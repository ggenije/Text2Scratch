using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Text2Scratch.ScratchObjects
{
    internal abstract class ScratchAsset:IScratchSerializable,IScratchNamable
    {
        public string AssetID { get; }
        public string ScratchName { get; }
        protected string md5ext;
        protected string dataFormat;
        private object pathOrData;

        public ScratchAsset(string filePath, string scratchName)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            this.ScratchName = scratchName;
            this.dataFormat = Path.GetExtension(filePath).ToLower().Substring(1);
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    AssetID = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
            md5ext = string.Concat(AssetID, ".", dataFormat);
            pathOrData = filePath;
        }

        public ScratchAsset(byte[] assetData, string dataFormat,string scratchName)
        {
            this.ScratchName = scratchName;

            this.dataFormat = dataFormat;
            using (var md5 = MD5.Create())
            {
                md5.TransformFinalBlock(assetData, 0, assetData.Length);
                byte[] hash = md5.Hash;
                AssetID = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
            md5ext = string.Concat(AssetID, ".", dataFormat);
            pathOrData = assetData;
        }

        public void WriteToFile(string path)
        {
            if (File.Exists(md5ext))
                return;
            if(pathOrData is string)
            {
                File.Copy((string)pathOrData, Path.Combine(path, md5ext));
            }
            else if(pathOrData is byte[])
            {
                File.WriteAllBytes(Path.Combine(path, md5ext), (byte[])pathOrData);
            }

        }

        public abstract void WriteJSON(JsonTextWriter writer);
       
    }
}
