namespace PMS.Client.Entities
{
    public class FileEntities
    {
        public int fileId {  get; set; }
        public string fileName { get; set; }
        public string fileMd5 { get; set; }
        public string filePath { get; set; }
        public string uploadTime { get; set; }
        public int state { get; set; }
        public int length { get; set; }
    }
}
