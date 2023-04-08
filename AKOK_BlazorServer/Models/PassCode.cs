namespace AKOK_BlazorServer.Models
{
    public static class PassCode
    {
        private static List<string> MyValue = new List<string>();

        public static void SetValue(string value)
        {
            MyValue.Add(value);
        }

        public static void RemoveValue(string value)
        {
            MyValue.Remove(value);
        }

        public static List<string> GetMyValue()
        {
            return MyValue;
        }
    }
}
