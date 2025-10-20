namespace keyhanPostWeb.Models.Entities.PersonEntities
{
    public class Person
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LastName { get; set; }
        public string? FatherName { get; set; }
        public string? NotionalityCode { get; set; }
        public string? Mobile { get; set; }
        public byte Gender { get; set; }
        public string? IdentityCode { get; set; }
        public string? PersonType { get; set; }

        public bool IsEmployee { get; set; }
        public bool IsMoaref { get; set; }


    }
}
