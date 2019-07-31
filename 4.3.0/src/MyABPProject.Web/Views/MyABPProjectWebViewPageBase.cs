using Abp.Web.Mvc.Views;

namespace MyABPProject.Web.Views
{
    public abstract class MyABPProjectWebViewPageBase : MyABPProjectWebViewPageBase<dynamic>
    {

    }

    public abstract class MyABPProjectWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MyABPProjectWebViewPageBase()
        {
            LocalizationSourceName = MyABPProjectConsts.LocalizationSourceName;
        }
    }
}