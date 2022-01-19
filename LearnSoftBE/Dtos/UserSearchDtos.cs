using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Dtos
{
    public class UserSearchDtos
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public IEnumerable <UserUnitsDtos> UserUnits{ get; set; }

    }
    public class UserUnitsDtos
    {
        public int UserUnitId { get; set; }
        public string DepartmentName { get; set; }
        public string Role { get; set; }
    }
}
