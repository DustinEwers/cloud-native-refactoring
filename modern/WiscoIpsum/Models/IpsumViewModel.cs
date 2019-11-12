namespace WiscoIpsum.Models
{
    public class IpsumViewModel
    {
        public int Paragraphs { get; set; }

        public string IpsumText { get; set; }

        public bool DisplayIpsumText
        {
            get
            {
                return !string.IsNullOrEmpty(IpsumText);
            }
        }
    }
}
