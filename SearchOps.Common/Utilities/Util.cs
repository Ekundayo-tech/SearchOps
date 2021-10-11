using SearchOps.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchOps.Common.Utilities
{ 
    public class Util
    {
        public static MessageResponse<T> GetResponse<T>(bool response, string message, T result) where T : class
        {
            var responseMessage = new MessageResponse<T>();
            responseMessage.IsSuccessResponse = response;
            var responseCode = response ? ResponseDetails.Successful : ResponseDetails.Failed;
            responseMessage.ResponseCode = (int)responseCode;
            responseMessage.Message = message;
            responseMessage.Result = result;
            return responseMessage;
        }
    }
}
