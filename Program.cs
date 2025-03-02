using System.Text;
using System.Text.Json;

namespace ArcSonglistMigrator
{
    /// <summary>
    /// The core of this application.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Title = "ArcSonglistMigrator";
                Console.WriteLine("Welcome to ArcSonglistMigrator, a tool designed to migrate and allocate songlist from apk to ipa.\nPlease type the path of songlist(\\assets\\songs\\songlist): ");
                string jsonFilePath = (args.Length > 0) ? args[0] : Console.ReadLine() ?? "";
                string jsonContent = File.ReadAllText(jsonFilePath);
                RootObject? root = JsonSerializer.Deserialize<RootObject>(jsonContent);
                 // Store song information by id key.
                Dictionary<string, Song> songDictionary = [];
                if (root is not null) foreach (var song in root.songs)
                {
                    /* song.SetDefaultValues();*/
                    if (song.id == "random" || song.id == "tutorial")
                    {
                        continue;
                    }
                    foreach (var s in song.difficulties)
                    {
                        if (s.rating == 0 || s.rating == -1)
                        {
                            s.rating = 0;
                        }
                    }
                    songDictionary[song.id] = song;
                }
                // Output song information.
                foreach (KeyValuePair<string, Song> entry in songDictionary)
                {
                    Console.WriteLine($"Song ID: {entry.Key}, Title: {entry.Value.title_localized["en"]}");
                }
                Console.WriteLine("Well Done! All information has been successfully stored!\nPlease wait for a moment...");
                Thread.Sleep(2000);
                string outputFolder = Path.GetDirectoryName(jsonFilePath) ?? "";
                // Read each song and output it as a songlist file
                JsonSerializerOptions options = new()
                {
                    // Set not to escape non-ASCII characters.
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
              
                };
                List<Song> songList = [.. songDictionary.Values];
                RootObject outputRoot = new()
                {
                    songs = songList
                };
                File.WriteAllText(jsonFilePath, JsonSerializer.Serialize(outputRoot, options), Encoding.UTF8);
                foreach (var entry in songDictionary)
                {
                    Song song = entry.Value;
                    foreach(var s in song.difficulties)
                    {
                        if(s.rating == 0 || s.rating == -1)
                        {
                            s.rating = -1;
                        }
                    }
                    RootObject singleSongRoot = new()
                    {
                        songs = [song]
                    };
                    string outputJson = JsonSerializer.Serialize(singleSongRoot, options);
                    string outputFilePath = Path.Combine(outputFolder, song.id, "songlist");
                    File.WriteAllText(outputFilePath, outputJson);
                    Console.WriteLine($"Song : \"{song.id}\" has been written to {outputFilePath}.");
                }
                Console.Write("Everything goes well...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}