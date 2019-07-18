using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace FastExtractDocumentMetadata
{
    public class Settings
    {
        [JsonProperty("documentsLocation")]
        public string DocumentSLocation { get; set; }

        private Settings()
        {
        }

        public static Settings From(string configurationFilePath)
        {
            try
            {
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(configurationFilePath));
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Invalid configuration file format. See {configurationFilePath}", ex);
            }
        }
    }
}
