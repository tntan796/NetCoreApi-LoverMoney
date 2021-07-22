namespace Models.Common
{
    public class Constants
    {
        public const int CodeStatusSuccess = 1;
        public const int CodeStatusFail = 2;
        public const int CodeStatusCreateFail = 3;
        public const int CodeStatusCreateDupcate = 4;
        public const int CodeStatusRefreshToken = 5;

        public const string Empty = "";
        public const string StatusSuccess = "success";
        public const string Statusfail = "error";
        public const string StatusUsernotfound = "Not found user";

        public const string MessageGetDataSuccess = "Get data successfully";
        public const string MessageGetDataFail = "Get data fail";
        public const string MessageSaveSuccess = "Save successfully";
        public const string MessageSaveFail = "Save unsuccessfully";
        public const string MessageDeleteSuccess = "Delete successfully";
        public const string MessageDeleteFail = "Delete unsuccessfully";
        public const string MessageSignUpSuccess = "Signup successfully";
        public const string MessageSignUpFail = "Signup fail";
        public const string MessageSignInSuccess = "Signin successfully";
        public const string MessageSignInFail = "Signin fail";
        public const string MessageSignUpInvalidConfirmPassword = "Confirm password not match with password";
        public const string MessageSignUpExistedEmail = "Your input email has existed";
        public const string MessageException = "Internal Server Error";
        public const string MessageChargeException = "Cannot Charge This Card.";
        public const string MessagePermissionDeny = "Permission Deny";
        public const string MessageFeedisProcessing = "Your feed is processing. Please, try again later!";
        public const string MessageCreateSuccess = "Create successfully";
        public const string MessageCreateDupcate = "The user login already exists. Can not create";
        public const string MessageCreateFail = "Can not create. Invalid data, please try again";
        public const string MessageRefreshToken = "The token is expired!";
        public const string MessageOpenUrl = "Do somthing for next step!";
        public const string MessageNotExist = "The {0} does not exists";
        public const string MessageExisted = "The {0} already exists. Can not create";
        public const string MessageSetDataSuccess = "Set data successfully";
        public const string MessageInvalidPassword = "Invalid Password, The password length is more than 4 character";

        public const string MessageDataEmpty = "Is Empty";
        public const string MessageDataValid = "Valid";
        public const string MessageDataInvalid = "Invalid Data";
    }
}