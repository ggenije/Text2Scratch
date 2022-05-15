using Newtonsoft.Json;
using System.Text;
using System.IO.Compression;
using System.IO;
namespace Text2Scratch.ScratchObjects
{
    internal static class ScratchProjectBuilder
    {
        static private void PrepareDataForWritting(ScratchObjectManager scratchObjectManager)
        {
            scratchObjectManager.Stage.PrepareForWriting();
            foreach (ScratchSprite ss in scratchObjectManager.sprites)
            {
                ss.PrepareForWriting();
            }
        }

        static private StringBuilder GenerateJSON(ScratchObjectManager scratchObjectManager)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonTextWriter writer;

            using (writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("targets");
                writer.WriteStartArray();

                scratchObjectManager.Stage.WriteJSON(writer);
                foreach (ScratchSprite ss in scratchObjectManager.sprites)
                {
                    ss.WriteJSON(writer);
                }
                writer.WriteEndArray();

                writer.WritePropertyName("monitors");
                writer.WriteStartArray();
                foreach (ScratchMonitor m in scratchObjectManager.monitors)
                {
                    m.WriteJSON(writer);
                }
                writer.WriteEndArray();

                writer.WritePropertyName("extensions");
                writer.WriteStartArray(); writer.WriteEndArray();//To do
                writer.WritePropertyName("meta");
                writer.WriteStartObject();
                writer.WritePropertyName("semver"); writer.WriteValue("3.0.0");
                writer.WritePropertyName("vm"); writer.WriteValue("0.2.0-prerelease.20220412111205");//To do
                writer.WritePropertyName("agent"); writer.WriteValue("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36");

                writer.WriteEndObject();
            }
            return sb;
        }

        static private void GenerateJsonFile(ScratchObjectManager scratchObjectManager,string fileName)
        {
            PrepareDataForWritting(scratchObjectManager);
            File.WriteAllText(fileName, GenerateJSON(scratchObjectManager).ToString());
        }
        static public void GenerateProject(ScratchObjectManager scratchObjectManager, string projectName)
        {
            try
            {

                if (Directory.Exists(projectName))
                {
                    Directory.Delete(projectName, true);
                }
                Directory.CreateDirectory(projectName);
                GenerateJsonFile(scratchObjectManager, Path.Combine(projectName, "project.json"));
                scratchObjectManager.WriteAllAssets(projectName);
                if (File.Exists(projectName + ".sb3"))
                    File.Delete(projectName + ".sb3");

                ZipFile.CreateFromDirectory(projectName, projectName + ".sb3");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot create project: "+ex.Message);
            }
        }
    }
}
