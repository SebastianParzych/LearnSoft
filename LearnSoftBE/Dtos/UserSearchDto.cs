using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Dtos
{
    public class UserSearchDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public IEnumerable <UserUnitsDto> UserUnits{ get; set; }

    }
    public class UserUnitsDto
    {
        public int UserUnitId { get; set; }
        public string DepartmentName { get; set; }
        public string Role { get; set; }
    }
    public class UserInfoDto : UserSearchDto
    {
        public byte[] Image { get; set; }
    }
}
