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
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();
            // CreateMap<UserViewModel, UserDTO>();

            CreateMap<Form, FormDTO>();
            CreateMap<FormDTO, FormViewModel>();
            // CreateMap<FormViewModel, FormDTO>();

            CreateMap<Question, QuestionDTO>();
            CreateMap<QuestionDTO, QuestionViewModel>();
            // CreateMap<QuestionViewModel, QuestionDTO>();

            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerDTO, AnswerViewModel>();
            // CreateMap<AnswerViewModel, AnswerDTO>();

            CreateMap<Element, ElementDTO>();
            CreateMap<ElementDTO, ElementViewModel>();
            // CreateMap<ElementViewModel, ElementDTO>();

            CreateMap<CFE.Entities.Models.Attribute, AttributeDTO>();
            CreateMap<AttributeDTO, AttributeViewModel>();
            // CreateMap<AttributeViewModel, AttributeDTO>();

            CreateMap<FormResult, FormResultDTO>();
            CreateMap<FormResultDTO, FormResultViewModel>();
            // CreateMap<FormResultViewModel, FormResultDTO>();

            CreateMap<QuestionResult, QuestionResultDTO>();
            CreateMap<QuestionResultDTO, QuestionResultViewModel>();
            // CreateMap<QuestionResultViewModel, QuestionResultDTO>();

            CreateMap<AnswerResult, AnswerResultDTO>();
            CreateMap<AnswerResultDTO, AnswerResultViewModel>();
            // CreateMap<AnswerResultViewModel, AnswerResultDTO>();

            CreateMap<AttributeResult, AttributeResultDTO>();
            CreateMap<AttributeResultDTO, AttributeResultViewModel>();
            // CreateMap<AttributeResultViewModel, AttributeResultDTO>();

            CreateMap<List<Question>, List<QuestionDTO>>();
            CreateMap<List<QuestionDTO>, List<QuestionViewModel>> ();
            // CreateMap<List<QuestionViewModel>, List<QuestionDTO>>();

            CreateMap<List<Answer>, List<AnswerDTO>>();
            CreateMap<List<AnswerDTO>, List<AnswerViewModel>>();
            // CreateMap<List<AnswerViewModel>, List<AnswerDTO>>();

            CreateMap<List<Element>, List<ElementDTO>>();
            CreateMap<List<ElementDTO>, List<ElementViewModel>>();
            // CreateMap<List<ElementViewModel>, List<ElementDTO>>();

            CreateMap<List<CFE.Entities.Models.Attribute>, List<AttributeDTO>>();
            CreateMap<List<AttributeDTO>, List<AttributeViewModel>>();
            // CreateMap<List<AttributeViewModel>, List<AttributeDTO>>();

            CreateMap<List<QuestionResult>, List<QuestionResultDTO>>();
            CreateMap<List<QuestionResultDTO>, List<QuestionResultViewModel>>();
            // CreateMap<List<QuestionResultViewModel>, List<QuestionResultDTO>>();

            CreateMap<List<AnswerResult>, List<AnswerResultDTO>>();
            CreateMap<List<AnswerResultDTO>, List<AnswerResultViewModel>>();
            // CreateMap<List<AnswerResultViewModel>, List<AnswerResultDTO>>();

            CreateMap<List<AttributeResult>, List<AttributeResultDTO>>();
            CreateMap<List<AttributeResultDTO>, List<AttributeResultViewModel>>();
            // CreateMap<List<AttributeResultViewModel>, List<AttributeResultDTO>>();
        }

    }
}
