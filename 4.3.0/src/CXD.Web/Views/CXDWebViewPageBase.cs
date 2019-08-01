using Abp.Web.Mvc.Views;

namespace CXD.Web.Views
{
    public abstract class CXDWebViewPageBase : CXDWebViewPageBase<dynamic>
    {

    }

    public abstract class CXDWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected CXDWebViewPageBase()
        {
            LocalizationSourceName = CXDConsts.LocalizationSourceName;
        }
    }
}