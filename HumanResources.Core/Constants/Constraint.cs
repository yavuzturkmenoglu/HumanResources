using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Core.Constants
{
    public static class Constraint
    {
        public static class Database
        {
            public static class User
            {
                public const int NameMinLenght = 2;
                public const int NameMaxLenght = 50;

                public const int LastNameMinLenght = 2;
                public const int LastNameMaxLenght = 100;
            }

            public static class Education
            {
                public const int NameMinLenght = 2;
                public const int NameMaxLenght = 200;
            }
        }
    }
}
