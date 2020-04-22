using AutoMapper;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System.Collections.Generic;
using System.Linq;
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

        public MainQuestionBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            formBL = new FormBL(mapper, unitOfWork);
            questionBL = new QuestionBL(mapper, unitOfWork);
            elementBL = new ElementBL(mapper, unitOfWork);
            answerBL = new AnswerBL(mapper, unitOfWork);
            attributeBL = new AttributeBL(mapper, unitOfWork);
            attributeResultBL = new AttributeResultBL(mapper, unitOfWork);
        }
        public void CreateQuestionGeneric(FormViewModel _formViewModel, List<QuestionCreateViewModel> _listQuestionCreateViewModel)
        {
            FormViewModel formViewModel = _formViewModel;
            List<QuestionCreateViewModel>  listQuestionCreateViewModel = _listQuestionCreateViewModel;
            
            if(listQuestionCreateViewModel == null)
            {
                return;
            }

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
                int questionId = questionBL.GetId(questionViewModel);

                foreach (var answerViewModel in questionCreateViewModel.AnswerViewModel)
                {
                    AnswerViewModel answerVM = new AnswerViewModel
                    {
                        Name = answerViewModel.Name,
                        QuestionId = questionId
                    };
                    answerBL.Create(answerVM);
                }

                foreach (var attributeViewModel in questionCreateViewModel.AttributeViewModel)
                {
                    attributeVM = new AttributeViewModel
                    {
                        Name = attributeViewModel.Name,
                        DisplayName = attributeViewModel.DisplayName,
                        QuestionId = questionId
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
        public List<QuestionCreateViewModel> GetQuestionGeneric(int formId)
        {
            List<QuestionCreateViewModel> listQuestionCreateViewModel = new List<QuestionCreateViewModel>();
            var questionViewModels = questionBL.ReadAll().Where(i => i.FormId == formId).ToList();
            foreach (var questionViewModel in questionViewModels)
            {
                QuestionCreateViewModel questionCreateViewModel = new QuestionCreateViewModel();
                int questionId = questionBL.GetId(questionViewModel);
                questionCreateViewModel.QuestionViewModel = questionViewModel;
                questionCreateViewModel.ElementViewModel = elementBL.Read(questionViewModel.ElementId);
                questionCreateViewModel.AnswerViewModel = answerBL.ReadAll().Where(i => i.QuestionId == questionId).ToList();
                questionCreateViewModel.AttributeViewModel = attributeBL.ReadAll().Where(i => i.QuestionId == questionId).ToList();
                foreach (var attribute in questionCreateViewModel.AttributeViewModel)
                {
                    questionCreateViewModel.AttributeResultViewModel.Add(attributeResultBL.ReadAll()
                        .FirstOrDefault(i => i.AttributeId == attributeBL.GetId(attribute)));
                }
            }
            return listQuestionCreateViewModel;
        }
        public void UpdateQuestionGeneric(FormViewModel _formViewModel, List<QuestionCreateViewModel> _listQuestionCreateViewModel)
        {
            FormViewModel formViewModel = _formViewModel;
            List<QuestionCreateViewModel> listQuestionCreateViewModel = _listQuestionCreateViewModel;
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
                questionBL.Update(questionViewModel);
                int questionId = questionBL.GetId(questionViewModel);

                foreach (var answerViewModel in questionCreateViewModel.AnswerViewModel)
                {
                    AnswerViewModel answerVM = new AnswerViewModel
                    {
                        Name = answerViewModel.Name,
                        QuestionId = questionId
                    };
                    answerBL.Update(answerVM);
                }

                foreach (var attributeViewModel in questionCreateViewModel.AttributeViewModel)
                {
                    attributeVM = new AttributeViewModel
                    {
                        Name = attributeViewModel.Name,
                        DisplayName = attributeViewModel.DisplayName,
                        QuestionId = questionId
                    };
                    attributeBL.Update(attributeVM);
                }

                foreach (var attributeResultViewModel in questionCreateViewModel.AttributeResultViewModel)
                {
                    AttributeResultViewModel attributeResult = new AttributeResultViewModel
                    {
                        Value = attributeResultViewModel.Value,
                        AttributeId = attributeBL.GetId(attributeVM)
                    };
                    attributeResultBL.Update(attributeResult);
                }
            }
        }
    }
}
