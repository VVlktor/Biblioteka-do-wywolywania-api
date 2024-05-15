namespace CallingApiClass
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var postParam = new Dictionary<string, string> { { "Imie","Jan" }, { "Haslo", "MojeHaslo" } };
            Returner mojDom = await ApiClass.CallApi(ApiClass.Options.Login, typeof(Uzytkownik), postParam);
            Console.WriteLine(mojDom.Success);
            Console.WriteLine(((Uzytkownik)mojDom.Result).Imie);
        }
    }
}