namespace Data.Models
{
    public class ValidationProblem
    {
        public ValidationProblem(string name, string description)
        {
            Name=name;
            Description=description;
        }

        public ValidationProblem(string name)
        {
            Name=name;
            Description=name;
        }

        public string Name {get;set;}
        public string Description {get;set;}
    }
}