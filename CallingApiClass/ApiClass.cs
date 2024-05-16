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

        public static async Task<Returner<T>> CallApi<T>(Options option, Dictionary<string, string> postParams)
        {
            Returner<T> returner = new Returner<T>();
            returner.Success = true;
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
                returner.Result = (T)JsonSerializer.Deserialize(content,typeof(T));
                if (returner.Result is null)
                    throw new Exception("Dane nie poprawne");
            }
            catch(Exception e)
            {
                returner.Success = false;
                returner.Result = (T)Activator.CreateInstance(typeof(T));
                Console.WriteLine(e.Message);
            }
            return returner;
        }

        public static async Task<Returner<T>> CallApi<T>(string link, Type typ, Dictionary<string, string> postParams)
        {
            Returner<T> returner = new Returner<T>();
            returner.Success = true;
            try
            {
                HttpClient client = new HttpClient();
                var encodedParams = new FormUrlEncodedContent(postParams);
                var receivedData = await client.PostAsync(link, encodedParams);
                var content = await receivedData.Content.ReadAsStringAsync();
                if (content is null)
                    throw new Exception("Nie udalo sie odebrac danych");
                returner.Result = (T)JsonSerializer.Deserialize(content, typeof(T));
                if (returner.Result is null)
                    throw new Exception("Dane nie poprawne");
            }
            catch (Exception e)
            {
                returner.Success = false;
                returner.Result = (T)Activator.CreateInstance(typeof(T));
                Console.WriteLine(e.Message);
            }
            return returner;
        }
    }
}
