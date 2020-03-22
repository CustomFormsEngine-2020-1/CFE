using AutoMapper;
using CFE.BLL.DTO;
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
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();

            CreateMap<FormDTO, FormViewModel>();
            CreateMap<FormViewModel, FormDTO>();

            CreateMap<QuestionDTO, QuestionViewModel>();
            CreateMap<QuestionViewModel, QuestionDTO>();

            CreateMap<AnswerDTO, AnswerViewModel>();
            CreateMap<AnswerViewModel, AnswerDTO>();

            CreateMap<ElementDTO, ElementViewModel>();
            CreateMap<ElementViewModel, ElementDTO>();

            CreateMap<AttributeDTO, AttributeViewModel>();
            CreateMap<AttributeViewModel, AttributeDTO>();

            CreateMap<FormResultDTO, FormResultViewModel>();
            CreateMap<FormResultViewModel, FormResultDTO>();

            CreateMap<QuestionResultDTO, QuestionResultViewModel>();
            CreateMap<QuestionResultViewModel, QuestionResultDTO>();

            CreateMap<AnswerResultDTO, AnswerResultViewModel>();
            CreateMap<AnswerResultViewModel, AnswerResultDTO>();

            CreateMap<AttributeResultDTO, AttributeResultViewModel>();
            CreateMap<AttributeResultViewModel, AttributeResultDTO>();
        }

    }
}
