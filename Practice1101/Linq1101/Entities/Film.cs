using Linq1101.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linq1101.Entities
{
    public class Film : ArtObject
    {

        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

}
