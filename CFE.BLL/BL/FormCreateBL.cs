using AutoMapper;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CFE.BLL.BL
{
    public class FormCreateBL
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private FormCreateViewModel formCreateViewModel;
        private QuestionCreateViewModel questionCreateViewModel;
        private FormViewModel formViewModel;
        private FormBL formBL;
        private QuestionBL questionBL;
        private AnswerBL answerBL;
        private ElementBL elementBL;
        private AttributeBL attributeBL;

        public FormCreateBL(IMapper _mapper, IUnitOfWork _unitOfWork, JsonElement value)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            formBL = new FormBL(mapper, unitOfWork);
            questionBL = new QuestionBL(mapper, unitOfWork);
            answerBL = new AnswerBL(mapper, unitOfWork);
            elementBL = new ElementBL(mapper, unitOfWork);
            attributeBL = new AttributeBL(mapper, unitOfWork);
            JsonDeserialize(value);
            CreateForm();
        }

        public void JsonDeserialize(JsonElement value)
        {
            var json = value.GetRawText();
            formCreateViewModel = JsonSerializer.Deserialize<FormCreateViewModel>(json);
        }
        public void CreateForm()
        {
            formViewModel = new FormViewModel
            {
                Name = formCreateViewModel.Name,
                Description = formCreateViewModel.Description,
                DTCreate = ConvertingStringDateTimeToSqlDateTime(formCreateViewModel.DTCreate),
                DTStart = ConvertingStringDateTimeToSqlDateTime(formCreateViewModel.DTStart),
                DTFinish = ConvertingStringDateTimeToSqlDateTime(formCreateViewModel.DTFinish),
                IsPrivate = ConvertingStringBoolToBool(formCreateViewModel.IsPrivate),
                IsAnonymity = ConvertingStringBoolToBool(formCreateViewModel.IsAnonymity),
                IsEditingAfterSaving = ConvertingStringBoolToBool(formCreateViewModel.IsEditingAfterSaving)
            };
            formBL.Create(formViewModel);
        }
        private System.DateTime? ConvertingStringDateTimeToSqlDateTime(string stringDateTime, string sqlFormatDateTime = "yyyy-MM-dd HH:mm:ss")
        {
            System.DateTime sqlDateTime = new DateTime();                                                       // Resulting output variable in case of success
            System.DateTime? negativeResult = null;                                                             // Resulting output variable in case of fail / error or exception

            try
            {   
                if (string.IsNullOrEmpty(stringDateTime))                                                       // Сhecking the input variable <stringDateTime> to <null> and <empty>
                {
                    return System.DateTime.TryParseExact(stringDateTime,                                        // TryParseExact function converts the specified string -
                                                         sqlFormatDateTime,                                     // - representation <stringDateTime> of a datetime -
                                                         System.Globalization.CultureInfo.InvariantCulture,     // - to its DateTime equivalent.
                                                         System.Globalization.DateTimeStyles.None,
                                                         out sqlDateTime) ? sqlDateTime : negativeResult;
                }
                return negativeResult;
            }
            catch (Exception ex)
            {
                return negativeResult;
            }
        }
        private bool ConvertingStringBoolToBool(string stringBool)
        {
            bool result = false;                                                       // Resulting output variable in case of success

            if (string.IsNullOrEmpty(stringBool))                                                       // Сhecking the input variable <stringDateTime> to <null> and <empty>
            {
                if (Boolean.TryParse(stringBool, out result))
                    return result;
            }
            return result;
        }
    }
}
