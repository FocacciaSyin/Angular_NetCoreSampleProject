using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    public class MarvelCard
    {
        [Key]
        public int ID { get; set; }
        public string HeroName { get; set; }
        public string Name { get; set; }
        public string Titile { get; set; }
        public string ImageName { get; set; }
        public string BackgroundColor { get; set; }

    }
}
