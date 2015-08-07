using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using React_Chat_Gap.ServiceModel.Types;
using ServiceStack;

namespace React_Chat_Gap.ServiceModel
{
    [Route("/chathistory")]
    public class GetChatHistory : IReturn<GetChatHistoryResponse>
    {
        public string[] Channels { get; set; }
        public long? AfterId { get; set; }
        public int? Take { get; set; }
    }

    public class GetChatHistoryResponse
    {
        public List<ChatMessage> Results { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
