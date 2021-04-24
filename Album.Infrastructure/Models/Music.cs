using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    [System.Serializable]

    public class Music
    {
        public string Title;
        public decimal Length;
        public bool IsFavorite;

        public Music(string title, decimal length, bool isFavorite)
        {
            Title = title;
            Length = length;
            IsFavorite = isFavorite;
        }
    }
}
