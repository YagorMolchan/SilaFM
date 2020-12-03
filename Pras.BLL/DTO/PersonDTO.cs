namespace Pras.BLL.DTO
{
    public class PersonDTO : EntityDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string ImageSmall { get; set; }
        public string Socials { get; set; }
        public string Summary { get; set; }
        public int Order { get; set; }
    }
}
