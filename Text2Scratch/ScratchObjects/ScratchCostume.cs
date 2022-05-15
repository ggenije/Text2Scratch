using Newtonsoft.Json;

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchCostume : ScratchAsset
    {
     
        int bitmapResolution;
        float rotationCenterX;
        float rotationCenterY;

        public ScratchCostume(string filePath,string scratchName,float rotationCenterX,float rotationCenterY):base(filePath,scratchName)
        {
            bitmapResolution = 1;
            this.rotationCenterX = rotationCenterX;
            this.rotationCenterY = rotationCenterY;
        }

        public ScratchCostume(byte[] assetData,string dataFormat, string scratchName, float rotationCenterX, float rotationCenterY) : base(assetData,dataFormat, scratchName)
        {
            bitmapResolution = 1;
            this.rotationCenterX = rotationCenterX;
            this.rotationCenterY = rotationCenterY;
        }

        public override void WriteJSON(JsonTextWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("assetId");
            writer.WriteValue(AssetID);
            writer.WritePropertyName("name");
            writer.WriteValue(ScratchName);
            writer.WritePropertyName("bitmapResolution");
            writer.WriteValue(bitmapResolution);
            writer.WritePropertyName("md5ext");
            writer.WriteValue(md5ext);
            writer.WritePropertyName("dataFormat");
            writer.WriteValue(dataFormat);
            writer.WritePropertyName("rotationCenterX");
            writer.WriteValue(rotationCenterX);
            writer.WritePropertyName("rotationCenterY");
            writer.WriteValue(rotationCenterY);
            writer.WriteEndObject();
        }
    }
}
