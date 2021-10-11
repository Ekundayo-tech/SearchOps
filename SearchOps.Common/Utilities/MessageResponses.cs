using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SearchOps.Common.Utilities
{
    public class BaseMessageResponse
    {
        [JsonIgnore]
        public bool IsSuccessResponse { get; set; }
        public int ResponseCode { get; set; }
        public string Message { get; set; }
    }
    public class MessageResponse<T> : BaseMessageResponse
    {
        public T Result { get; set; }
    }
    public class Response<T>
    {
        public T Result { get; set; }
    }
}
