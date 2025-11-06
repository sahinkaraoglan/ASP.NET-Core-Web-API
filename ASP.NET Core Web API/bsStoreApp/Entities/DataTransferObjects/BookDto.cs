namespace Entities.DataTransferObjects
{
    //[Serializable] //aşağıdakilerin serileştirilebileceği anlamına gelir.
    public record BookDto
    {
        public int Id { get; init; }
        public String Title { get; init; }
        public decimal Price { get; init; }
    }
}
