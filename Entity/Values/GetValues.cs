namespace Entity.Values
{
    public class GetValuesRequest
    {
        public int Id { get; set; }
    }

    public class GetValuesResponse
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}