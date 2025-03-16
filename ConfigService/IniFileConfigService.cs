using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigService
{
    public class IniFileConfigService : IConfigService
    {
        public string? FilePath { get; set; }

        public string GetValue(string name)
        {
            var kv=File.ReadAllLines(FilePath)
            .Select(line => line.Split('='))
            .Where(parts => parts.Length == 2)
            .Select(parts => new { Key = parts[0], Value = parts[1] })
            .FirstOrDefault(entry => entry.Key == name);   
            if (kv == null)
            {
                throw new InvalidOperationException($"Key {name} not found");
            } else {
                return kv.Value;
            } 
        }
    }
}