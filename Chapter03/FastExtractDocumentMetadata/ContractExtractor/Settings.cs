using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContractExtractor
{
    public class Settings
    {
        [JsonProperty("documentsLocation")]
        public string DocumentsLocation { get; set; }

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

                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(configurationFilePath), settingsJson);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Invalid configuration file format. See {configurationFilePath}", ex);
            }
        }
    }
}
