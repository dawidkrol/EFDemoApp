namespace EFDataAccessLibrary.Models
{
    public interface IAddress
    {
        string City { get; set; }
        int Id { get; set; }
        string State { get; set; }
        string StreetAddress { get; set; }
        string ZipCode { get; set; }
    }
}