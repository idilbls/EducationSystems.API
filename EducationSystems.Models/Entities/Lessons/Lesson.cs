﻿using EducationSystems.Models.Entities.Core;
using EducationSystems.Models.Entities.IdentityAuth;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationSystems.Models.Entities.Lessons
{
    [Table("Lesson")]
    public class Lesson : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int? ProfessorId { get; set; }

    }
}
