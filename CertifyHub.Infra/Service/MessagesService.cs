using CertifyHub.Core.Data;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Service
{
    public class MessagesService : IMessagesService
    {
        private readonly IMessagesRepository _messagesRepository;

        public MessagesService(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public void DeleteMessageById(int messageId)
        {
            _messagesRepository.DeleteMessageById(messageId);
        }

        public Task<List<Message>> DisplayMessagesBetweenUsers(int senderId, int receiverId)
        {
           return _messagesRepository.DisplayMessagesBetweenUsers(senderId, receiverId);
        }

        public void SendMessage(Message message)
        {
           _messagesRepository.SendMessage(message);
        }

        public void UpdateMessageText(Message message)
        {
            _messagesRepository.UpdateMessageText(message);
        }
    }
}
