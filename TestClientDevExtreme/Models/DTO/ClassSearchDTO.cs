namespace TestClientDevExtreme.Models.DTO
{
    public class ClassSearchDTO
    {
        public string ClassStudent { get; set; }
        public string Year { get; set; }

        public ClassSearchDTO(string classStudent, string year)
        {
            ClassStudent = classStudent;
            Year = year;
        }
    }
}
