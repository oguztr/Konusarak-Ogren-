﻿using KonusarakOgren.Core.Entities;
using System;
using System.Collections.Generic;

namespace KonusarakOgren.Application.Models
{
    public class ExamIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
