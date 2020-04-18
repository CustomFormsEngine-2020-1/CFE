﻿using AutoMapper;
using CFE.DAL;
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
        private JsonElement jsonElement;
        private FormViewModel formViewModel;
        private List<QuestionCreateViewModel> listQuestionCreateViewModel;
        private FormBL formBL;

        public FormCreateBL()
        {

        }
        public FormCreateBL(IMapper _mapper, IUnitOfWork _unitOfWork, FormCreateViewModel _formCreateViewModel) // JsonElement _jsonElement)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            formCreateViewModel = _formCreateViewModel;
            // jsonElement = _jsonElement;
            formBL = new FormBL(mapper, unitOfWork);
            // JsonDeserialize(value);
            // CreateForm();
        }


        public void JsonDeserialize()
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

        public void CreateQuestionCreateViewModel()
        {
            listQuestionCreateViewModel = formCreateViewModel.QuestionCreateViewModel;
            QuestionCreateBL questionCreateBL = new QuestionCreateBL(mapper, unitOfWork, formViewModel, listQuestionCreateViewModel);
            questionCreateBL.Create();
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
    }
}
