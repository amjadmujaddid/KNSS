using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSService.Contract
{
    public class ResponseBase
    {
        private List<string> _messages;

        public List<string> Messages
        {
            get { return _messages ?? (_messages = new List<string>()); }
        }
    }
}
