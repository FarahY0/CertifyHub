﻿using CertifyHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Service
{
    public interface IMessagesService
    {
        void SendMessage(Message message);
        void DeleteMessageById(int messageId);
        void UpdateMessageText(Message message);
        Task<List<Message>> DisplayMessagesBetweenUsers(int senderId, int receiverId);
    }
}
