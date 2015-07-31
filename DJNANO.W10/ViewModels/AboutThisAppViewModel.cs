using System;
using AppStudio.Common;
using Windows.ApplicationModel;

namespace DJNANO.ViewModels
{
    public class AboutThisAppViewModel : ObservableBase
    {
        public string Publisher
        {
            get
            {
                return "App Studio Team";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Official DJ Nano App created with App Studio";
            }
        }
    }
}

