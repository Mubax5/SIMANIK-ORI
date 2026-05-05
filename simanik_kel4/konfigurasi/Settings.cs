using System;
using System.IO;

namespace simanik_kel4.konfigurasi
{
    internal class Settings
    {
        public static void simpanSettings(string path)
        {
            File.WriteAllLines(ambilPathSettings(path), new string[] { "localhost", "3306", "simanik", "root", "" });
        }

        public static string[] ambilSettings(string path)
        {
            string filePath = ambilPathSettings(path);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File konfigurasi database tidak ditemukan.", filePath);
            }

            string[] sumber = File.ReadAllLines(filePath);

            if (sumber.Length < 5)
            {
                throw new InvalidDataException("Format konfig.txt harus 5 baris: server, port, database, uid, password.");
            }

            return sumber;
        }

        public static string ambilPathSettings(string path)
        {
            if (Path.IsPathRooted(path))
            {
                return path;
            }

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
    }
}
