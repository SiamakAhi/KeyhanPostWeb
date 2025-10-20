namespace keyhanPostWeb.Classes
{
    public enum SaveResult : Int16
    {
        SaveSuccess = 1, //ثبت اطلاعات با موفقیت انجام شد
        UpdateSuccess = 2, // ویرایش اطلاعات انجام شد
        DeleteSuccess = 3, // حذف اطلاعات با موفقیت انجام شد
        DuplicateErrorr = 4, // رکورد تکراری است
        HassDataErrorr = 5, // در جدول دیگری داری اطلاعات است و حذف آن امکانپذیر نمی باشد
        UserDataEntryErrorr = 6, //اطلاعات وارد شده توسط کاربر صحیح نمی باشد
        InternalErrorr = 7, // بروز مشکل سیستمی
        NoImageSelected = 8, // تصویری انتخاب نشده است
        ApproveChange = 9, // عملیات تغییر وضعیت با موفقیت انجام شد
    }
}
