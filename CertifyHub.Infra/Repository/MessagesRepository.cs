using CertifyHub.Core.Common;
using CertifyHub.Core.Data;
using CertifyHub.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Repository
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly IDbContext _dbContext;

        public MessagesRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void DeleteMessageById(int messageId)
        {
            var p = new DynamicParameters();
            p.Add("p_MessageId", messageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("MessagePackage.DeleteMessageById", p, commandType: CommandType.StoredProcedure);

        }

    

        public async Task<List<Message>> DisplayMessagesBetweenUsers(int senderId, int receiverId)
        {
            var p = new DynamicParameters();
            p.Add("p_SenderId", senderId, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("p_ReceiverId", receiverId, dbType: DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Message>("MessagePackage.DisplayMessagesBetweenUsers", p, commandType: CommandType.StoredProcedure);

            return result.ToList(); 
        }

    

        public async void SendMessage(Message message)
        {
            var p = new DynamicParameters();
            p.Add("p_SenderId", message.Senderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_ReceiverId", message.Receiverid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_MessageText", message.Messagetext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_FileName", message.Filename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_SendDate", message.Senddate, dbType: DbType.Date, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("MessagePackage.SendMessage", p, commandType: CommandType.StoredProcedure);

        }

        public async void UpdateMessageText(Message message)
        {
            var p = new DynamicParameters();
            p.Add("p_MessageId", message.Messageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_NewMessageText", message.Messagetext, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("MessagePackage.UpdateMessageText", p, commandType: CommandType.StoredProcedure);

        }
    }
}
