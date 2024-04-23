using HouseRentingSystem.Data.Models;

namespace HouseRentingSystem.Data
{
    public class DataConstraints
    {
        public class Category
        {
            public const int CategoryNameMaxLength = 50;
        }

        public class House
        {
            public const int HouseTitleMinLength = 10;
            public const int HouseTitleMaxLength = 50;

            public const int HouseAddressMinLength = 30;
            public const int HouseAddressMaxLength = 150;

            public const int HouseDescriptionMinLength = 50;
            public const int HouseDescriptionMaxLength = 500;

            public const double HousePricePerMonthMinValue = 0;
            public const double HousePricePerMonthMaxValue = 2000;
        }

        public class Agent
        {
            public const int AgentPhoneNumerMinLength = 7;
            public const int AgentPhoneNumberMaxLength = 15;
        }

    }
}
