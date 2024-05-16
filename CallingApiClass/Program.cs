namespace CallingApiClass
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var postParam = new Dictionary<string, string> { { "Imie","Jan" }, { "Haslo", "MojeHaslo" } };
            Returner<Uzytkownik> mojDom = await ApiClass.CallApi<Uzytkownik>(ApiClass.Options.Login, postParam);
            Console.WriteLine(mojDom.Success);
            Console.WriteLine(mojDom.Result.Imie);
        }
    }
}