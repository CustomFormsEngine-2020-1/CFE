using AutoMapper;
using CFE.BLL.DTO;
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

            CreateMap<List<Question>, List<QuestionViewModel>>();
            CreateMap<List<QuestionViewModel>, List<Question>> ();

            CreateMap<List<Answer>, List<AnswerViewModel>>();
            CreateMap<List<AnswerViewModel>, List<Answer>>();

            CreateMap<List<Element>, List<ElementViewModel>>();
            CreateMap<List<ElementViewModel>, List<Element>>();

            CreateMap<List<CFE.Entities.Models.Attribute>, List<AttributeViewModel>>();
            CreateMap<List<AttributeViewModel>, List<CFE.Entities.Models.Attribute>>();

            CreateMap<List<QuestionResult>, List<QuestionResultViewModel>>();
            CreateMap<List<QuestionResultViewModel>, List<QuestionResult>>();

            CreateMap<List<AnswerResult>, List<AnswerResultViewModel>>();
            CreateMap<List<AnswerResultViewModel>, List<AnswerResult>>();

            CreateMap<List<AttributeResult>, List<AttributeResultViewModel>>();
            CreateMap<List<AttributeResultViewModel>, List<AttributeResult>>();
        }

    }
}
