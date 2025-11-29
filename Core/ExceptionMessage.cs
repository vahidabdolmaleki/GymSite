namespace Core
{
    public class ExceptionMessage
    {
        public const string FirstNameRequired = "وارد کردن نام اجباری است";
        public const string LastNameRequired = "وارد کردن نام خانوادگی اجباری است";
        public const string PasswordRequired = "وارد کردن کلمه عبور اجباری است";
        public const string PasswordMinimumRequired = "کلمه عبور باید حداکثر 16 حرف باشد";
        public const string UserNameMinimumRequired = "نام کاربری باید بیش از 3 حرف باشد";
        public const string PersonNotFound = "شخص مورد نظر پیدا نشد";
        public const string GetAllAsyncFailed = "بازیابی کل اشخاص با خطا مواجه شد";
        public const string CreateAsyncFailedFor = "اطلاعات شخص مورد نظر ذخیره نشد";
        public const string DeleteAsyncFeild = "DeleteAsync feild for Id: ";
        public const string CurrentPasswordIsIncorrect = "رمز عبور فعلی وارد شده اشتباه است!";
        public const string ChengePasswordFeildForPersonId = "تغییر رمز عبور برای کاربر با خطا مواجه شد. شماره کاربر:";
        public const string PicNotFound = "Picture not found";
        public const string SetPrimaryPictureAsyncFeildForPersonId = "SetPrimaryPictureAsync Feild For PersonId";
        public const string InvalidDatetime = "تاریخ را به  درستی وارد نمایید";
        public const string DontFindUser = "کاربر مورد نظر یافت نشد.";
        public const string UpdateSuccessFully = "اطلاعات مورد نظر با موفقیت بروزرسانی شد";
        public const string DeleteSuccessFully= "اطلاعات مورد نظر با موفقیت حذف شد";
        public const string UserIdDoesNotMatch = "شناسه کاربر مطابقت ندارد.";
        public const string ForgotPasswrodFeild= "عملیات فراموشی کلمه عبور با خطا مواجه شد کد خطا:";
        public const string SendVerificationCodeCompelete= "ارسال کد فعال سازی با موفقیت انجام شد خلاص شدیم رفت ";
        public const string CodeExpiredOrNotValid= " کد منقضی شده و با معتبر نمی‌باشد باباجان دقت کن دیگه";
        public const string codeVrified ="کد تاپید شد عزیزم";
        public const string VerifyCodeError ="عملیات تایید کد با خطا مواجه شده کد خطا اینه :";
        public const string CreateWorkoutSuccessFully= "تمرین با موفقیت ایجاد شد.";
        public const string WorkourNotFound= "تمرین یافت نشد.";
        public const string WorkoutUpdatedSuccessfully= "تمرین بروزرسانی شد.";
        public const string WorkOutNotFound ="تمرین یافت نشد.";
        public const string CreateStudentSuccessfully="شاگرد مورد نظر با موفقیت ایجاد شد";
        public const string CreateStudentFeild = "خطا در ثبت شاگرد";
        public const string DontFindStudent = " شاگرد یافت نشد.";
        public const string UpdateStudentSuccessfully = "اطلاعات شاگرد با موفقیت به‌روزرسانی شد.";
        public const string UpdateStudentFeild = "خطا در ویرایش شاگرد";
        public const string ListStudentSuccessfullyRetrieved= "لیست شاگردان بازیابی شد";
        public const string FeildListStudentRetrieved= "لیست شاگردان بازیابی شد";
        public const string StudentSuccessfullyDeactived = "شاگرد با موفقیت غیرفعال شد.";
        public const string DeleteStudentFeild = "خطا در حذف شاگرد";
        public const string DataCouldNotBeReadFromCache= "داده‌ها از کش خوانده شدند.";
        public const string DataWasSuccessfullyRecoverd = "داده‌ها با موفقیت بازیابی شدند.";
        public const string UsernameOrPasswordIsInvalid= "نام کاربری یا رمز عبور اشتباه است.";
        public const string LoginSuccessFully= "ورود موفقیت‌آمیز بود.";
        public const string YouCantInsertDuplicateUser= "کاربری با این اطلاعات از قبل وجود دارد.";
        public const string RegisterSuccessfullyDoPleaseInsertComfirmCode= "ثبت‌نام با موفقیت انجام شد. لطفاً کد ارسال‌شده را تأیید کنید.";
        public const string RegisterFeild= "خطا در ثبت‌نام: ";
        public const string CodeIsNotValid= "کد معتبر نیست یا منقضی شده.";
        public const string PasswordSuccessfullyChanged= "رمز عبور با موفقیت تغییر یافت.";
        public const string TokenIsNotValid = "توکن نامعتبر است.";
        public const string RefeshTokenOrExpiredToken = "رفرش توکن منقضی یا نامعتبر است.";
        public const string NewTokenCreated = "توکن جدید صادر شد.";
        public const string FeildUpdatetoken = "خطا در بروزرسانی توکن:";
        public const string DontFindDeviceForExit = "دستگاهی برای خروج یافت نشد.";
        public const string ExitSuccessfully= "خروج با موفقیت انجام شد.";
        public const string ExitFeild= "خطا در خروج:";
        public const string MasterListSuccessfullyRetrieved = "لیست مربی‌ها با موفقیت دریافت شد.";
        public const string MasterListFeild= "خطا در دریافت لیست مربی‌ها:";
        public const string CoachNotFound = "مربی یافت نشد.";
        public const string CoachInformationSuccessfullyRetieved= "اطلاعات مربی با موفقیت دریافت شد.";
        public const string CoachInformationFeild= "خطا در دریافت اطلاعات مربی: ";
        public const string SerachSuccessfully= "جستجو با موفقیت انجام شد.";
        public const string SerachFeild = "خطا در جستجو:";
        public const string GetStudentFeild= "خطا در دریافت شاگردها: ";
        public const string GetWorkoutLogAsyncSuccess = "بازیابی گزارش تمرین با موفقیت انجام شد";
        public const string GetNotificationListSuccessfully = "بازیابی اعلان‌های ارسال شده با موفقیت انجام شد";
        public const string NotficationReadSuccessfull= "اعلان خوانده شد.";
        public const string RegisterReadForNotficationFeild ="عملیات ثبت خوانده اعلان با مشکل مواجه شد";
        public const string GetCountNotificationSuccessfully ="تعداد اعلان‌ها با موفقیت بازیابی شد";
        public const string GetCountNoficationFeild="بازیابی تعداد اعلان‌ها با مشکل مواجه شده است";

        public const string Test = "";
        public const string SendNoficationFeild = "ارسال اعلان با طا مواجه شد";
        public const string SendNoficationSuccessFully = "اعلان ارسال شد.";
    }
}
