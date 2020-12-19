namespace Entity.Values
{
    public class UpdateValuesRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class UpdateValuesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}