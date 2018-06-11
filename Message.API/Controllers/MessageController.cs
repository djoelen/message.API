using Message.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.API.Controllers
{
    [Route("api/messages")]
    public class MessageController : Controller
    {


        [HttpGet()]
        public IActionResult GetMessages()
        {
            return Ok(MessagesDataStore.Current.Messages);
        }

        [HttpGet("{id}", Name = "GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var messageToReturn = MessagesDataStore.Current.Messages.FirstOrDefault(m => m.Id == id);
            if (messageToReturn == null)
            {

                return NotFound();
            }

            return Ok(messageToReturn);
        }

        [HttpPost()]
        public IActionResult CreateMessage([FromBody] MessageForCreationDto message)
        {
            if(message == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maxMessageId = MessagesDataStore.Current.Messages.Max(c => c.Id);

            var lastMessage = new MessageDto()
            {
                Id = ++maxMessageId,
                Message = message.Message
            };

            MessagesDataStore.Current.Messages.Add(lastMessage);

            return CreatedAtRoute("GetMessage", new { id = lastMessage.Id}, lastMessage);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMessage(int id, [FromBody] MessageForUpdateDto message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var messageFromStore = MessagesDataStore.Current.Messages.FirstOrDefault(m => m.Id == id);
            if (messageFromStore == null)
            {
                return NotFound();
            }

            messageFromStore.Message = message.Message;

            return NoContent();

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var messageFromStore = MessagesDataStore.Current.Messages.FirstOrDefault(m => m.Id == id);
            if (messageFromStore == null)
            {
                return NotFound();
            }

            MessagesDataStore.Current.Messages.Remove(messageFromStore);

            return NoContent();

        }

    }
}
