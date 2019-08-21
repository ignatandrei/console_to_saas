using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ContractExtractor
{
    public class Settings
    {
        //[JsonProperty("documentsLocation")]
        //public string DocumentsLocation { get; set; }

        [JsonProperty("fileSystem")]
        public FileSystemSettings FileSystemProvider { get; set; }
        private Settings()
        {
        }

        public static Settings From(string configurationFilePath)
        {
            try
            {
                var settingsJson = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(configurationFilePath),settingsJson);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Invalid configuration file format. See {configurationFilePath}", ex);
            }
        }
    }
}
