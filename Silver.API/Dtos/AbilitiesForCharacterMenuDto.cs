namespace Silver.API.Dtos
{
    public class AbilitiesForCharacterMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int BaseDamage { get; set; }
        public int TypeId { get; set; }
        public bool IsOffensive { get; set; }
    }
}