using AutoMapper;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class QuestionCreateBL
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        private QuestionCreateViewModel questionCreateViewModel; 

        public QuestionCreateBL(IMapper _mapper, IUnitOfWork _unitOfWork, QuestionCreateViewModel _questionCreateViewModel)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            questionCreateViewModel = _questionCreateViewModel;
        }




    }
}
