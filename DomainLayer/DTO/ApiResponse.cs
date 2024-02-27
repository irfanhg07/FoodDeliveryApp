//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DomainLayer.DTO
//{
//    public class ApiResponse<T>
//    {
//        public IEnumerable<T> Data { get; set; }

//        public ApiResponse(IEnumerable<T> data)
//        {
//            Data = data;
//        }
//    }

//}
using System.Collections.Generic;

namespace DomainLayer.DTO
{
    public class ApiResponse<T>
    {
        public IEnumerable<T> Data { get; set; }

        public ApiResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        // Additional constructor for single items
        public ApiResponse(T item)
        {
            Data = new List<T> { item };
        }
    }
}
