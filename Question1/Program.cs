using Question1.Utilities;


namespace Question1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Transcode.Init();

            string testString = "This is a test string";            

            if (Convert.ToBoolean(String.Compare(testString, Transcode.Decode(Transcode.Encode(testString)))))
            {
                Console.WriteLine("Test succeeded");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }
    }
}