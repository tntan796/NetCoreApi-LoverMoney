using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public enum ApiResult
    {
        Success = 1,
        Fail = 0,
        FailedSome = 2,
        NeedToRefreshData = 3,
        InternalServerError = 4,
        DeleteSuccess = 5,
        DeleteFail = 6,
        CreateFail = 7,
        CreateFailDuplicate = 8,
        OpenUrl = 9,
        Valid = 10,
        Invalid = 11,
        Error = 12
    }
}
