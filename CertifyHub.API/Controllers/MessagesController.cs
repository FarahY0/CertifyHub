using CertifyHub.Core.Data;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessagesService _messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }
        [HttpDelete("{messageId}")]
        public void DeleteMessageById(int messageId)
        {
            _messagesService.DeleteMessageById(messageId);
        }
     
        [HttpGet]
        [Route("DisplayMessagesBetweenUsers/{senderId}/{receiverId}")]
        public Task<List<Message>> DisplayMessagesBetweenUsers(int senderId, int receiverId)
        {
            return _messagesService.DisplayMessagesBetweenUsers(senderId, receiverId);
        }
        [HttpPost]
        public void SendMessage(Message message)
        {
            _messagesService.SendMessage(message);
        }
        [HttpPut]
        public void UpdateMessageText(Message message)
        {
            _messagesService.UpdateMessageText(message);
        }
    }
}
