using System;
using System.IO;
using System.Text.Json;


namespace CSLab.DataIntegrityAndState.Serialization
{
    public class Main
    {
        public static void Run()
        {
            var purchase1 = new Purchase()
            {
                ProductName = "Liquid Soap",
                DateTime  = DateTime.UtcNow,
                ProductPrice = 2.49m
            };

            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };

            
            string jsonString = JsonSerializer.Serialize<Purchase>(purchase1, serializerOptions);
            byte[] jsonByte = JsonSerializer.SerializeToUtf8Bytes(purchase1);

            string projectRoot = AppContext.BaseDirectory;
            string filePath = Path.Combine(projectRoot, "..", "..", "..", "DataIntegrityAndState", "Serialization", "purchase.json");

            File.WriteAllText(filePath, jsonString);
        }
    }
}
