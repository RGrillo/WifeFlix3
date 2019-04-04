using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifeFlixUI.Models
{
    public class Serie
    {
        public string SerieId { get; set; }

        public string SerieName { get; set; }

        public int SerieSeasson { get; set; }

        public int SerieEpisode { get; set; }


        public override string ToString()
        {
            return $"{SerieName} - {SerieSeasson} - {SerieEpisode} - {SerieId}";
        }

    }
}
