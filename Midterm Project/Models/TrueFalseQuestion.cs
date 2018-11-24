using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm.Models
{
    public class TrueFalseQuestion : TestQuestion
    {
        public TrueFalseQuestion(TestQuestion question)
        {
            ID = question.ID;
            Question = question.Question;
            Type = question.Type;
            Choices = question.Choices;
        }

        [Required]
        [RegularExpression("^([Tt][Rr][Uu][Ee]|[Ff][Aa][Ll][Ss][Ee])$")]
        public override string Answer
        {
            get => base.Answer;
            set => base.Answer = value;
        }
    }
}
