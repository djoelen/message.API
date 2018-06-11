using Message.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.API
{
    public class MessagesDataStore
    {
        public static MessagesDataStore Current { get; } = new MessagesDataStore();
        public List<MessageDto> Messages { get; set; }

        public MessagesDataStore()
        {
            Messages = new List<MessageDto>()
            {
            new MessageDto()
            {
                Id = 1,
                Message = "Hej hur mår du?"
            },
            new MessageDto()
            {
                Id = 2,
                Message = "Jag mår bra!"
            }
            };
        }

    }
}
