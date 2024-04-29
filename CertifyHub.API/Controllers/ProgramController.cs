using CertifyHub.Core.Data;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;
        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }


        [HttpGet]
        public async Task<List<CertifyHub.Core.Data.Program>> GetAllPrograms()
        {
            return await _programService.GetAllPrograms();
        }

        [HttpGet]
        [Route("GetProgram")]
        public async Task<CertifyHub.Core.Data.Program> GetProgramByID(int id)
        {
            return await _programService.GetProgramByID(id);

        }

        [HttpPost]
        public async void CreateProgram(CertifyHub.Core.Data.Program program)
        {
            _programService.CreateProgram(program);
        }

        [HttpPut]
        public async void UpdateProgram(CertifyHub.Core.Data.Program program)
        {
            _programService.UpdateProgram(program);
        }

        [HttpDelete("{id}")]
        public async void DeleteProgram(int id)
        {
            _programService.DeleteProgram(id);

        }

        [HttpPost]
        [Route("uploadImagePath")]
        public Core.Data.Program UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString() + "_" + file.FileName}";
            var fullPath = Path.Combine("C:\\Users\\DELL\\Documents\\CertifyHub\\CertifyHub\\src\\assets\\Image", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Core.Data.Program program = new Core.Data.Program();
            program.Imagepath = fileName;


            return program;
        }


        [HttpGet]
        [Route("GetStudentPrograms/{id}")]
        public async Task<List<CertifyHub.Core.Data.Program>> GetStudentPrograms(int id)
        {
            return await _programService.GetStudentPrograms(id);


        }

    
    //[HttpGet]
    //[Route("GetStudentPrograms/{id}")]
    //public async Task<List<CertifyHub.Core.Data.Program>> GetStudentPrograms(int id)
    //{
    //    return await _programService.GetStudentPrograms(id);


    //}
}
}
