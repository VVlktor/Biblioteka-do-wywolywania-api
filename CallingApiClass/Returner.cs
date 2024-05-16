namespace CallingApiClass
{
    public class Returner<T>
    {
        public bool Success { get; set; }
        public T result;

        public T Result
        {
            get {
                if (Success)
                    return result;
                return (T)Activator.CreateInstance(typeof(T));
            }
            set 
            {
                result = value;
            }
        }
    }
}
