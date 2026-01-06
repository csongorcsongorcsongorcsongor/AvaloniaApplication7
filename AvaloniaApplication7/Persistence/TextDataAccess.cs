using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using AvaloniaApplication7.Models;

namespace AvaloniaApplication7.Persistence
{
    public class TextDataAccess : IDataAccess
    {
        public async Task Save(string path, Parcel parcel)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            await writer.WriteLineAsync(parcel.ToString());
        }

        public async Task<Parcel?> Load(string path)
        {
            if (!File.Exists(path))
                return null;

            using StreamReader reader = new StreamReader(path);
            string? line = await reader.ReadLineAsync();

            if (string.IsNullOrWhiteSpace(line))
                return null;

            string[] data = line.Split(';');
            return new Parcel(
                data[0],
                data[1],
                DateOnly.Parse(data[2]),
                data[3],
                data[4],
                data[5],
                int.Parse(data[6]),
                int.Parse(data[7])
            );
        }
    }

}
