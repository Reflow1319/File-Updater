namespace Indexer
{
    public class SoftwareFile
    {
        public int Revision;
        public string Value;

        public SoftwareFile(string value, int revision) {
            this.Value = value;
            this.Revision = revision;
        }
    }
}
