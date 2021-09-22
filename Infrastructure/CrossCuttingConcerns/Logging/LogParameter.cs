namespace Infrastructure.CrossCuttingConcerns.Logging
{
    // todo 36->Log Parameter Class'ı oluşturulur.
    public class LogParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
    }
}