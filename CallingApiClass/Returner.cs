namespace CallingApiClass
{
    public class Returner
    {
        public bool Success { get; set; }
        public Type WhatType {  get; set; }
        public object result;

        public object Result
        {
            get {
                if (Success)
                    return result;
                return Activator.CreateInstance(WhatType);
            }
            set 
            {
                result = value;
            }
        }
    }
}
