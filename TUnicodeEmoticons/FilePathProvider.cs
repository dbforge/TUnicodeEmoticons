using System;
using System.IO;

namespace TUnicodeEmoticons
{
    public static class FilePathProvider
    {
        public static string AppDataPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TUnicodeEmoticons"); 
        public static string TileDataFile => Path.Combine(AppDataPath, "tiledata.json");
        public static string SettingsDataFile => Path.Combine(AppDataPath, "settings.json");
    }
}