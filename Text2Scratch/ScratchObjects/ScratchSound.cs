using Newtonsoft.Json;
using NAudio.Wave;

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchSound:ScratchAsset
    {

        int rate;
        long sampleCount;

        //mp3 support to do
        public ScratchSound(string filePath, string scratchName) : base(filePath, scratchName)
        {
            using (WaveFileReader rdr = new WaveFileReader(filePath))
            {
                sampleCount = rdr.SampleCount;
                rate = rdr.WaveFormat.AverageBytesPerSecond * 8;
            }
        }
        public ScratchSound(byte[] assetData, string dataFormat, string scratchName) : base(assetData,dataFormat, scratchName)
        {
            Stream stream = new MemoryStream(assetData);
            using (WaveFileReader rdr = new WaveFileReader(stream))
            {
                sampleCount = rdr.SampleCount;
                rate = rdr.WaveFormat.AverageBytesPerSecond * 8;
            }    
        }




        public override void WriteJSON(JsonTextWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("assetId");
            writer.WriteValue(AssetID);
            writer.WritePropertyName("name");
            writer.WriteValue(ScratchName);
            writer.WritePropertyName("dataFormat");
            writer.WriteValue(dataFormat);
            writer.WritePropertyName("rate");
            writer.WriteValue(rate);
            writer.WritePropertyName("sampleCount");
            writer.WriteValue(sampleCount);
            writer.WritePropertyName("md5ext");
            writer.WriteValue(md5ext);
            writer.WriteEndObject();
        }
    }
}
