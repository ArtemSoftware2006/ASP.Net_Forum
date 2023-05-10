using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using ASP.Net_Forum;
using ASP_Net_Forum_Service;
using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.DAL.Repositories;
using ASP.Net_Forum.Domain.Entity;

namespace ASP.Net_Forum.Service.Implementations
{
    public class RecomendationService : IRecomendationService
    {
        private const int VALUE_NOTES = 30;
        private const float MIN_SCORE = 1.4F;
        private readonly INoteRepository noteRepository;

        public RecomendationService(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task<BaseResponse<IEnumerable<Note>>> Get(int userId)
        {
            try
            {
                var IdNotes = new List<int>();
                var Notes = new List<Note>();

                for (int i = 1; i < VALUE_NOTES; i++)
                {
                    var sampleData = new MLModel1.ModelInput() { Id = userId, NoteId = i };

                    var result = MLModel1.Predict(sampleData);

                    if (result.Score >= MIN_SCORE)
                    {
                        IdNotes.Add(Convert.ToInt32(result.NoteId));
                    }
                }

                for (int i = 0; i < VALUE_NOTES; i++)
                {
                    Notes.Add(await noteRepository.Get(i));
                }

                return new BaseResponse<IEnumerable<Note>>
                {
                    Data = Notes,
                    Description = "Ok",
                    StatusCode = Domain.Enum.StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Note>>()
                {
                    StatusCode = Domain.Enum.StatusCode.InternalServerError,
                    Description = ex.Message,
                };

            }
        }
    }
}
