using AutoMapper;
// using CFE.BLL.DTO;
using CFE.Entities.Models;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Bootstrap.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Form, FormViewModel>();
            CreateMap<FormViewModel, Form>();

            CreateMap<Question, QuestionViewModel>();
            CreateMap<QuestionViewModel, Question>();

            CreateMap<Answer, AnswerViewModel>();
            CreateMap<AnswerViewModel, Answer>();

            CreateMap<Element, ElementViewModel>();
            CreateMap<ElementViewModel, Element>();

            CreateMap<CFE.Entities.Models.Attribute, AttributeViewModel>();
            CreateMap<AttributeViewModel, CFE.Entities.Models.Attribute>();

            CreateMap<FormResult, FormResultViewModel>();
            CreateMap<FormResultViewModel, FormResult>();

            CreateMap<QuestionResult, QuestionResultViewModel>();
            CreateMap<QuestionResultViewModel, QuestionResult>();

            CreateMap<AnswerResult, AnswerResultViewModel>();
            CreateMap<AnswerResultViewModel, AnswerResult>();

            CreateMap<AttributeResult, AttributeResultViewModel>();
            CreateMap<AttributeResultViewModel, AttributeResult>();
        }

    }
}
