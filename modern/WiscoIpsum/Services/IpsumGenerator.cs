using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Text;
using WiscoIpsum.Data;

namespace WiscoIpsum.Services
{
    public interface IIpsumGenerator {
        string GenerateIpsum(int numberOfParagraphs);
    }

    public class IpsumGenerator : IIpsumGenerator
    {
        private string[] _phrases;
        private readonly WiscoIpsumContext _context;

        public IpsumGenerator(IConfiguration config, WiscoIpsumContext context) {
            _context = context;
            _phrases = context.Phrases.Select(x => x.Text).ToArray();
        }

        public string GenerateIpsum(int numberOfParagraphs) {
            if (numberOfParagraphs < 1) { numberOfParagraphs = 1; }

            var sb = new StringBuilder();

            for (int i = 0; i < numberOfParagraphs; i++) {
                sb.AppendLine(GenerateParagraph());
                if (i + 1 < numberOfParagraphs) {
                    sb.AppendLine(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        private string GenerateParagraph()
        {
            var random = new Random();
            var numberOfphrases = random.Next(10, 30);

            var sb = new StringBuilder();

            for (int i = 0; i < numberOfphrases; i++) {
                var index = random.Next(0, _phrases.Length - 1);
                sb.Append(_phrases[index]);
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}
