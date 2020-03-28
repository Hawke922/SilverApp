using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Ability> Abilities { get; set; }
    }
}