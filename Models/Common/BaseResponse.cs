using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public class BaseResponse<T>
    {
        public int StatusCode { set; get; }
        public string Message { set; get; }
        public string Status { set; get; }
        public T Data { set; get; }
        public List<string> Error { set; get; }
        public void AddError(string error)
        {

            if (Error == null)
            {
                Error = new List<string>();
            }
            Error.Add(error);
        }

        public void AddError(ApiResult status, string error)
        {
            SetStatus(status);
            AddError(error);
        }

        public void AddErrors(List<string> errors)
        {

            if (Error == null)
            {
                Error = new List<string>();
            }
            Error.AddRange(errors);
        }

        public void AddErrors(ApiResult status, List<string> errors)
        {
            SetStatus(status);
            AddErrors(errors);
        }

        public BaseResponse(T data)
        {
            SetStatus(ApiResult.Success);
            Data = data;
        }

        public BaseResponse()
        {
            SetStatus(ApiResult.Success);
        }
        public void SetStatus(ApiResult status)
        {
            switch (status)
            {
                case (ApiResult.Success):
                    StatusCode = Constants.CodeStatusSuccess;
                    Message = Constants.StatusSuccess;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.Fail):
                    StatusCode = Constants.CodeStatusFail;
                    Message = Constants.MessageSaveFail;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.DeleteSuccess):
                    StatusCode = Constants.CodeStatusSuccess;
                    Message = Constants.MessageDeleteSuccess;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.DeleteFail):
                    StatusCode = Constants.CodeStatusFail;
                    Message = Constants.MessageDeleteFail;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.CreateFail):
                    StatusCode = Constants.CodeStatusCreateFail;
                    Message = Constants.MessageCreateFail;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.CreateFailDuplicate):
                    StatusCode = Constants.CodeStatusCreateDupcate;
                    Message = Constants.MessageCreateDupcate;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.NeedToRefreshData):
                    StatusCode = Constants.CodeStatusRefreshToken;
                    Message = Constants.MessageRefreshToken;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.OpenUrl):
                    StatusCode = Constants.CodeStatusRefreshToken;
                    Message = Constants.MessageOpenUrl;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.Valid):
                    StatusCode = Constants.CodeStatusSuccess;
                    Message = Constants.MessageDataValid;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.Invalid):
                    StatusCode = Constants.CodeStatusFail;
                    Message = Constants.MessageDataInvalid;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.Error):
                    StatusCode = Constants.CodeStatusFail;
                    Message = Constants.MessageGetDataFail;
                    Status = Constants.Statusfail;
                    break;
                default:
                    break;
            }
        }

        public void SetStatus(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        public BaseResponse(ApiResult status, T data = default, string error = null)
        {
            SetStatus(status);

            if (data != null)
            {
                Data = data;
            }

            if (!string.IsNullOrEmpty(error))
            {
                AddError(error);
            }
        }

        public void SetStatus(ApiResult status, string message)
        {
            switch (status)
            {
                case (ApiResult.Success):
                    StatusCode = Constants.CodeStatusSuccess;
                    Message = message;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.Fail):
                    StatusCode = Constants.CodeStatusFail;
                    Message = message;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.DeleteSuccess):
                    StatusCode = Constants.CodeStatusSuccess;
                    Message = message;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.DeleteFail):
                    StatusCode = Constants.CodeStatusFail;
                    Message = message;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.CreateFail):
                    StatusCode = Constants.CodeStatusCreateFail;
                    Message = message;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.CreateFailDuplicate):
                    StatusCode = Constants.CodeStatusCreateDupcate;
                    Message = message;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.NeedToRefreshData):
                    StatusCode = Constants.CodeStatusRefreshToken;
                    Message = message;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.OpenUrl):
                    StatusCode = Constants.CodeStatusRefreshToken;
                    Message = message;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.Valid):
                    StatusCode = Constants.CodeStatusSuccess;
                    Message = message;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.Invalid):
                    StatusCode = Constants.CodeStatusFail;
                    Message = message;
                    Status = Constants.Statusfail;
                    break;
                case (ApiResult.Error):
                    StatusCode = Constants.CodeStatusFail;
                    Message = message;
                    Status = Constants.Statusfail;
                    break;
                default:
                    break;
            }
        }

        public BaseResponse(ApiResult status)
        {
            SetStatus(status);
        }

        public BaseResponse(ApiResult status, string error = null)
        {
            SetStatus(status);

            if (!string.IsNullOrEmpty(error))
            {
                AddError(error);
            }
        }
    }
}