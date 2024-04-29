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
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async void CreateProgram(Program program)
        {
             _programRepository.CreateProgram(program);
        }

        public async void DeleteProgram(int id)
        {
            _programRepository.DeleteProgram(id);
        }

        public async Task<List<Program>> GetAllPrograms()
        {
            return await _programRepository.GetAllPrograms();
        }

        public async Task<Program> GetProgramByID(int id)
        {
            return await _programRepository.GetProgramByID(id);
        }

        public async void UpdateProgram(Program program)
        {
           _programRepository.UpdateProgram(program);
        }
        public async Task<List<Program>> GetStudentPrograms(int id)
        {
            return await _programRepository.GetStudentPrograms(id);
        }


    }
}
