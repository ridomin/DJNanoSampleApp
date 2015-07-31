using System;
using AppStudio.Common;

namespace DJNANO.ViewModels
{
    public class PrivacyViewModel : ObservableBase
    {
        public Uri Url
        {
            get
            {
                return new Uri(UrlText, UriKind.RelativeOrAbsolute);
            }
        }
        public string UrlText
        {
            get
            {
                return "http://1drv.ms/1llJOkM";
            }
        }
    }
}

