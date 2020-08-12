using System.Collections.Generic;

namespace StudentAndScore.Utility.Readers
{
    //Used Interface because if we wanted to use URL reading instead of file and etc, we should not use different methods,
    //we only need to use the same method with another object that implements this interface. 
    public interface IReader
    {
        public List<T> GetList<T>(string address);
    }
}