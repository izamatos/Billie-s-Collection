using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeçaoDeAlbunsBillie
{
    [System.Serializable]
    class Music : Collection
    {
        public string title;
        public float time;
        public string favorite;

        public Music(string title, float time, string favorite)
        {
            this.title = title;
            this.time = time;
            this.favorite = favorite;
        }

        public void Show()
        {
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Time: {time}");
            Console.WriteLine($"Favorite song: {favorite}");
        }

    }
}
