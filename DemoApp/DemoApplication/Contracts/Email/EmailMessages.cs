namespace DemoApplication.Contracts.Email
{
    public static class EmailMessages
    {
        public static class Subject
        {
            public const string ACTIVATION_MESSAGE = $"Hesabin aktivlesdirilmesi";
        }

        public static class Body
        {
            public const string ACTIVATION_MESSAGE = $"Sizin activation urliniz : {EmailMessageKeywords.ACTIVATION_URL}";
        }
    }
}
