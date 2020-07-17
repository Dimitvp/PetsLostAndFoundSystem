namespace PetsLostAndFoundSystem.Data
{
    public class DataConstants
    {
        public class Common
        {
            public const int UserNameMinLength = 2;
            public const int UserNameMaxLength = 100;

            public const int PicUrlMinLength = 10;
            public const int PicUrlMaxLength = 2000;

            public const int PublicationTitleMinLength = 3;
            public const int PublicationTitleMaxLength = 50;

            public const int CityMinLength = 3;
            public const int CityMaxLength = 90;

            public const int BusinessAddressMinLength = 5;
            public const int BusinessAddressMaxLength = 250;

            public const int EmailMinLength = 3;
            public const int EmailMaxLength = 90;

            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }
    }
}
