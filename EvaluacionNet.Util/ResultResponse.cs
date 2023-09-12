using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionNet.Util
{
    public class ResultResponse<T>
    {
        public bool Error { get; set; } = false;
        public string? ErrorMessage { get; set; } = null;
        public int ResponseCode { get; set; } = (int)HttpStatusCode.OK;
        public string ResponseMessage { get; set; } = HttpStatusCode.OK.ToString();
        public List<T>? ResultData { get; set; }
    }
}
