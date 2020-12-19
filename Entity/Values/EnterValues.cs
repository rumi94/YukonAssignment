namespace Entity.Values
{
    public class EnterValuesRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class EnterValuesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}