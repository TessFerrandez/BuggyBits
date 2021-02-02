using System.Text;
using System.Threading;

namespace BuggyBits.Models
{
    public class Link
    {
        public StringBuilder URL { get; set; } = new StringBuilder(10000);
        public string Title { get; set; }

        public Link(string title, string url)
        {
            this.Title = title;
            this.URL.Append(url);
        }

        ~Link()
        {
            // Some long running operation when cleaning up the data
            Thread.Sleep(5000);
        }
    }
}
