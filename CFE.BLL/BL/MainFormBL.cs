using AutoMapper;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CFE.BLL.BL
{
    public class MainFormBL
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private FormCreateViewModel formCreateViewModel;
        private FormViewModel formViewModel;
        private List<QuestionCreateViewModel> listQuestionCreateViewModel;
        private FormBL formBL;
        private MainQuestionBL mainQuestionBL;

        public MainFormBL()
        {

        }
        public MainFormBL(IMapper _mapper, IUnitOfWork _unitOfWork) // FormCreateViewModel _formCreateViewModel) // JsonElement _jsonElement)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            Init();
            // formCreateViewModel = _formCreateViewModel;
            // jsonElement = _jsonElement;
            formBL = new FormBL(mapper, unitOfWork);
            mainQuestionBL = new MainQuestionBL(mapper, unitOfWork);
            // JsonDeserialize(value);
            // CreateForm();
        }

        public void SaveForm(JsonElement jsonElement)
        {
            JsonDeserialize(jsonElement);
            CreateFormViewModel();
            CreateQuestionCreateViewModel();
        }

        public string ResponseForm(int formId)
        {
            FormCreateViewModel formCreateViewModel = CreateFormCreateViewModel(formId);
            string json = JsonSerializer.Serialize<FormCreateViewModel>(formCreateViewModel);
            return json;
        }
        public void JsonDeserialize(JsonElement jsonElement)
        {
            var json = jsonElement.GetRawText();
            formCreateViewModel = JsonSerializer.Deserialize<FormCreateViewModel>(json);
        }
        public void CreateFormViewModel()
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
                IsEditingAfterSaving = ConvertingStringBoolToBool(formCreateViewModel.IsEditingAfterSaving),
                UserId = ConvertingStringIntToInt(formCreateViewModel.UserId)
            };
            formBL.Create(formViewModel);
        }
        public FormCreateViewModel CreateFormCreateViewModel(int formId)
        {
            FormViewModel formViewModel = formBL.Read(formId);
            FormCreateViewModel formCreateViewModel = new FormCreateViewModel
            {
                Name = formViewModel.Name,
                Description = formViewModel.Description,
                DTCreate = formViewModel.DTCreate.ToString(),
                DTStart = formViewModel.DTStart.ToString(),
                DTFinish = formViewModel.DTFinish.ToString(),
                IsPrivate = formViewModel.IsPrivate.ToString(),
                IsAnonymity = formViewModel.IsAnonymity.ToString(),
                IsEditingAfterSaving = formViewModel.IsEditingAfterSaving.ToString(),
                UserId = formViewModel.UserId.ToString(),
                QuestionCreateViewModel = mainQuestionBL.GetQuestionCreateViewModel(formId)
            };
            return formCreateViewModel;
        }

        public void CreateQuestionCreateViewModel()
        {
            List<QuestionCreateViewModel> listQuestionCreateViewModel = formCreateViewModel.QuestionCreateViewModel;
            MainQuestionBL mainQuestionCreateBL = new MainQuestionBL(mapper, unitOfWork);
            mainQuestionCreateBL.Create(formViewModel, listQuestionCreateViewModel);
        }
        private DateTime? ConvertingStringDateTimeToSqlDateTime(string stringDateTime, string sqlFormatDateTime = "yyyy-MM-dd HH:mm:ss")
        {
            DateTime sqlDateTime = new DateTime();                                                       // Resulting output variable in case of success
            DateTime? negativeResult = null;                                                             // Resulting output variable in case of fail / error or exception

            try
            {
                if (string.IsNullOrEmpty(stringDateTime))                                                // Сhecking the input variable <stringDateTime> to <null> and <empty>
                {
                    return DateTime.TryParseExact(stringDateTime,                                        // TryParseExact function converts the specified string -
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
            bool result = false;                                                                        // Resulting output variable in case of success

            if (string.IsNullOrEmpty(stringBool))                                                       // Сhecking the input variable <stringDateTime> to <null> and <empty>
            {
                if (Boolean.TryParse(stringBool, out result))
                    return result;
            }
            return result;
        }
        private int ConvertingStringIntToInt(string stringInt)
        {
            int intValue = 0;                                                                           // Resulting output variable in case of success
            int negativeResult = -1;                                                                    // Resulting output variable in case of fail / error or exception
            if (!string.IsNullOrEmpty(stringInt))                                                       // Сhecking the input variable <longStringDateTime> to <null>
                return Int32.TryParse(stringInt, out intValue) ? intValue : negativeResult;             // TryParse function converts the string representation of datetime to its 64 - bit signed integer -
            return negativeResult;                                                                      // - equivalent. A return value indicates whether the operation succeeded
        }
        private void Init()
        {
            if (unitOfWork.Elements.ReadAll().Count() == 0)
            {
                List<Element> listElement = new List<Element>
                {
                      new Element {  Name = "TextBox", Description = "Однострочный текст" },
                      new Element {  Name = "TextArea", Description = "Многострочный текст" },
                      new Element {  Name = "Number", Description = "Число" },
                      new Element {  Name = "CheckBox", Description = "Множественный выбор" },
                      new Element {  Name = "CheckList", Description = "Список ответов" },
                      new Element {  Name = "RadioButton", Description = "Переключатель - единичный выбор" },
                      new Element {  Name = "DropDown", Description = "Выпадающий список" },
                      new Element {  Name = "DatePicker", Description = "Выбор даты" },
                      new Element {  Name = "TimePicker", Description = "Выбор времени" },
                      new Element {  Name = "MonthCalendar", Description = "Промежуток дат" },
                      new Element {  Name = "File", Description = "Файл" },
                };
                foreach (var element in listElement)
                    unitOfWork.Elements.Create(element);
                unitOfWork.Save();
            }
        }
    }
}
