using Repository.Pattern.EfCore;

namespace WebApi.DataAccess
{
    public class Employee : Entity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}