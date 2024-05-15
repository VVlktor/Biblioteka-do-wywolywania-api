using System.Text.Json;

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

        public static async Task<Returner> CallApi(Options option, Type typ, Dictionary<string, string> postParams)
        {
            Returner returner = new Returner();
            returner.Success = true;
            returner.WhatType = typ;
            string link;
            switch (option)
            {
                case Options.Login:
                    link = "http://localhost/CallingApiClass/login.php";
                    break;
                case Options.Register:
                    link = "http://localhost/CallingApiClass/register.php";
                    break;
                case Options.Post:
                    link = "http://localhost/CallingApiClass/post.php";
                    break;
                case Options.Invitation:
                    link = "http://localhost/CallingApiClass/invitation.php";
                    break;
                default:
                    returner.Success = false;
                    return returner;
            }

            try
            {
                HttpClient client = new HttpClient();
                var encodedParams = new FormUrlEncodedContent(postParams);
                var receivedData = await client.PostAsync(link,encodedParams);
                var content = await receivedData.Content.ReadAsStringAsync();
                if (content is null)
                    throw new Exception("Nie udalo sie odebrac danych");
                returner.Result = JsonSerializer.Deserialize(content,typ);
                if (returner.Result is null)
                    throw new Exception("Dane nie poprawne");
            }
            catch(Exception e)
            {
                returner.Success = false;
                returner.Result = Activator.CreateInstance(typ);
                Console.WriteLine(e.Message);
            }
            return returner;
        }

        public static async Task<Returner> CallApi(string link, Type typ, Dictionary<string, string> postParams)
        {
            Returner returner = new Returner();
            returner.Success = true;
            returner.WhatType = typ;
            try
            {
                HttpClient client = new HttpClient();
                var encodedParams = new FormUrlEncodedContent(postParams);
                var receivedData = await client.PostAsync(link, encodedParams);
                var content = await receivedData.Content.ReadAsStringAsync();
                if (content is null)
                    throw new Exception("Nie udalo sie odebrac danych");
                returner.Result = JsonSerializer.Deserialize(content, typ);
                if (returner.Result is null)
                    throw new Exception("Dane nie poprawne");
            }
            catch (Exception e)
            {
                returner.Success = false;
                returner.Result = Activator.CreateInstance(typ);
                Console.WriteLine(e.Message);
            }
            return returner;
        }
    }
}
