namespace ArcSonglistMigrator
{
    public class Difficulty
    {
        public int ratingClass { get; set; }
        public string chartDesigner { get; set; }
        public string jacketDesigner { get; set; }
        public int rating { get; set; }
        public bool? ratingPlus { get; set; }
        //public void SetDefaultValues()
        //{
        //    if (string.IsNullOrEmpty(chartDesigner))
        //    {
        //        chartDesigner = "";
        //    }
        //    if (string.IsNullOrEmpty(jacketDesigner))
        //    {
        //        jacketDesigner = "";
        //    }
        //    if (ratingPlus == null)
        //    {
        //        ratingPlus = false;
        //    }
        //}
    }
}