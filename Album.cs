using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeçaoDeAlbunsBillie
{
    [System.Serializable]
    class Album : Collection
    {
        public string title;
        public int year;
        public string group;

        public Album(string title, int year, string group)
        {
            this.title = title;
            this.year = year;
            this.group = group;            
        }

        public void Show()
        {
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Release year: {year}");
            Console.WriteLine($"Group: {group}");
        }
    }
}
