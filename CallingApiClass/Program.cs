namespace CallingApiClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Returner mojDom = ApiClass.CallApi(ApiClass.Options.Login, typeof(Uzytkownik));
            Console.WriteLine(mojDom.Success);
            Console.WriteLine(((Uzytkownik)mojDom.Result).Imie);
        }
    }
}