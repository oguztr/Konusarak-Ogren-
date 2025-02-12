﻿using KonusarakOgren.Infrastructure.Data.DataContext;
using KonusarakOgren.Core.Repositories.Interfaces;
using KonusarakOgren.Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KonusarakOgren.Core.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private DatabaseContext _database;

        public QuestionRepository(DatabaseContext database)
        {
            _database = database;
        }

        public QuestionAnswerResponse CheckQuestionAnswer(QuestionAnswerRequest request)
        {
            var question = _database.Questions.Include(x => x.Options).FirstOrDefault(x => x.Id == request.QuestionId);

            var response = new QuestionAnswerResponse()
            {
                CorrectOptionId = question.Options.FirstOrDefault(x=> x.IsCorrectOption == true).Id,
                IsCorrect = question.Options.Any(x => x.IsCorrectOption == true && x.Id == request.CorrectOptionId),
                QuestionId = question.Id
            };

            return response;
        }
    }
}
