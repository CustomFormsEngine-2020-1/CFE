using AutoMapper;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class MainQuestionBL
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        private FormViewModel formViewModel;
        private List<QuestionCreateViewModel> listQuestionCreateViewModel;
        private AttributeViewModel attributeVM;
        private FormBL formBL;
        private ElementBL elementBL;
        private QuestionBL questionBL;
        private AnswerBL answerBL;
        private AttributeBL attributeBL;
        private AttributeResultBL attributeResultBL;

        public MainQuestionBL(IMapper _mapper, IUnitOfWork _unitOfWork, 
                                FormViewModel _formViewModel, List<QuestionCreateViewModel> _listQuestionCreateViewModel)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            formViewModel = _formViewModel;
            listQuestionCreateViewModel = _listQuestionCreateViewModel;
            questionBL = new QuestionBL(mapper, unitOfWork);
            elementBL = new ElementBL(mapper, unitOfWork);
            answerBL = new AnswerBL(mapper, unitOfWork);
            attributeBL = new AttributeBL(mapper, unitOfWork);
            attributeResultBL = new AttributeResultBL(mapper, unitOfWork);
        }

        public void Create()
        {
            foreach (var questionCreateViewModel in listQuestionCreateViewModel)
            {
                ElementViewModel elementViewModel = new ElementViewModel
                {
                    Name = questionCreateViewModel.ElementViewModel.Name,
                    Description = questionCreateViewModel.ElementViewModel.Description
                };
                // elementBL.Create(elementViewModel); // ??? 

                QuestionViewModel questionViewModel = new QuestionViewModel
                {
                    Name = questionCreateViewModel.QuestionViewModel.Name,
                    FormId = formBL.GetId(formViewModel),
                    ElementId = elementBL.GetId(elementViewModel)
                };
                questionBL.Create(questionViewModel);

                foreach (var answerViewModel in questionCreateViewModel.AnswerViewModel)
                {
                    AnswerViewModel answerVM = new AnswerViewModel
                    {
                        Name = answerViewModel.Name,
                        QuestionId = questionBL.GetId(questionViewModel)
                    };
                    answerBL.Create(answerVM);
                }

                foreach (var attributeViewModel in questionCreateViewModel.AttributeViewModel)
                {
                    attributeVM = new AttributeViewModel
                    {
                        Name = attributeViewModel.Name,
                        DisplayName = attributeViewModel.DisplayName,
                        ElementId = elementBL.GetId(elementViewModel)
                    };
                    attributeBL.Create(attributeVM);
                }

                foreach (var attributeResultViewModel in questionCreateViewModel.AttributeResultViewModel)
                {
                    AttributeResultViewModel attributeResult = new AttributeResultViewModel
                    {
                        Value = attributeResultViewModel.Value,
                        AttributeId = attributeBL.GetId(attributeVM)
                    };
                    attributeResultBL.Create(attributeResult);
                }
            }
        }




    }
}
