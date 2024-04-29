using CertifyHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Service
{
    public interface ICvService
    {
        void UploadCV(Cv cv);
        void UpdateCV(Cv cv);
        void DeleteCV(int id);
        Task<List<Cv>> GetCVsByUser(int userId);
        Task<Cv> GetCVDetails(int id);
        Task<List<Cv>> GetCVByQrCode(string qrUrl);
        Task<List<Cv>> GetAllCVs();
        Task<string> GetQRCodeUrlByCVId(int cvId);
        void UpdateQrCode(int userId, string qrCode);


    }
}
