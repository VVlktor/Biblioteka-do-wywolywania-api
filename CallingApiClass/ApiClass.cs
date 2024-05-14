namespace CallingApiClass
{
    public static class ApiClass
    {
        public enum Options
        {
            Login,
            Register,
            Post,
            Invitation
        }

        public static Returner CallApi(Options option, Type typ)
        {
            Returner returner = new Returner();
            returner.Success = true;
            returner.WhatType = typ;
            string link = "";
            switch (option)
            {
                case Options.Login:
                    link = "link0";
                    break;
                case Options.Register:
                    link = "link1";
                    break;
                case Options.Post:
                    link = "link2";
                    break;
                case Options.Invitation:
                    link = "link3";
                    break;
                default:
                    returner.Success = false;
                    return returner;
            }


            try
            {
                returner.Result = new Uzytkownik() { Imie = "Jan", Haslo="MojeHaslo", Wiek=29, Miasto="Krakow", Opis="Tak sobie zyje" };
                throw new Exception("Nie ma");
            }
            catch(Exception e)
            {
                returner.Success=false;
                returner.Result = Activator.CreateInstance(typ);
                Console.WriteLine(e.Message);
            }
            return returner;
        }
    }
}
