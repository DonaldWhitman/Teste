using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraAPI.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public string Diretor { get; set; }
        public string Sinopse { get; set; }
        public DateTime Data_Lancamento { get; set; }
    }
}
