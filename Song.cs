namespace ArcSonglistMigrator
{
    public class Song
    {
        public string id { get; set; }
        public Dictionary<string, string> title_localized { get; set; }
        public string artist { get; set; }
        public string bpm { get; set; }
        public int bpm_base { get; set; }
        public string set { get; set; }
        public string purchase { get; set; }
        public int audioPreview { get; set; }
        public int audioPreviewEnd { get; set; }
        public int side { get; set; }
        public string bg { get; set; }
        public bool world_unlock { get; set; }
        public long date { get; set; }
        public string version { get; set; }
        public List<Difficulty> difficulties { get; set; }
        //public void SetDefaultValues()
        //{
        //    if (string.IsNullOrEmpty(artist))
        //    {
        //        artist = "";
        //    }
        //    if (string.IsNullOrEmpty(bpm))
        //    {
        //        bpm = "0";
        //    }
        //    if (string.IsNullOrEmpty(set))
        //    {
        //        set = "";
        //    }
        //    if (string.IsNullOrEmpty(purchase))
        //    {
        //        purchase = "";
        //    }
        //    if (string.IsNullOrEmpty(bg))
        //    {
        //        bg = "";
        //    }
        //    if (string.IsNullOrEmpty(version))
        //    {
        //        version = "";
        //    }
        //    if (title_localized == null || !title_localized.ContainsKey("en"))
        //    {
        //        title_localized = new Dictionary<string, string> { { "en", "" } };
        //    }
        //    if (difficulties != null)
        //    {
        //        foreach (var difficulty in difficulties)
        //        {
        //            difficulty.SetDefaultValues();
        //        }
        //    }
        //}
    }
}