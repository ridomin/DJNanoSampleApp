using System;
using System.Collections.Generic;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using Windows.Storage;
using DJNANO.Config;
using DJNANO.ViewModels;
using System.Globalization;
using Windows.ApplicationModel.Appointments;
using Windows.UI.Xaml;
using System.Collections.ObjectModel;

namespace DJNANO.Sections
{
    public class ToursConfig : SectionConfigBase<DynamicStorageDataConfig, Tours1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, Tours1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<Tours1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=90acc15e-eea7-4ebd-9e1a-50f339ad8b7c&appId=f079a57d-fb37-4e31-be1b-212a20dbe380"),
                    AppId = "f079a57d-fb37-4e31-be1b-212a20dbe380",
                    StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                    DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get
            {
                return NavigationInfo.FromPage("ToursListPage");
            }
        }

        public override ListPageConfig<Tours1Schema> ListPage
        {
            get
            {
                return new ListPageConfig<Tours1Schema>
                {
                    Title = "Tours",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Donde.ToSafeString();
                        viewModel.SubTitle = item.Cuando.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = "";
                        var dateTime = DateTimeSafeStringParse(item.DondeDT);
                        if (dateTime != null)
                        {
                            viewModel.MainCommand = new RelayCommand(() =>
                            {
                                Appointment a = new Appointment();
                                a.Subject = "DJ Nano Show en " + item.Cuando + " el día " + item.Donde;
                                a.StartTime = new System.DateTimeOffset(dateTime.Value);
                                a.AllDay = true;
                                var s = AppointmentManager.ShowAddAppointmentAsync(a, RectHelper.Empty);
                            });
                        }
                        viewModel.Content = item.DondeDT;
                    },
                    NavigationInfo = (item) =>
                    {
                        return null;
                    }
                };
            }
        }

        public static DateTime? DateTimeSafeStringParse(string stringDateTime)
        {
            string dateTimeFormat = "dd/MM/yyyy";
            DateTime result;
            bool success = DateTime.TryParseExact(stringDateTime, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            if (success) return result;
            else return null;            
        }

        public static void RemoveDeprecatedTours(ObservableCollection<ItemViewModel> items)
        {
            List<ItemViewModel> deprecatedItems = new List<ItemViewModel>();
            foreach (var t in items)
            {
                var dateTime = ToursConfig.DateTimeSafeStringParse(t.Content);
                if (dateTime != null)
                {
                    if (dateTime.Value.Ticks < DateTime.Now.Ticks)
                    {
                        deprecatedItems.Add(t);
                    }
                }
            }
            foreach (var t in deprecatedItems)
            {
                items.Remove(t);
            }
        }

        public override DetailPageConfig<Tours1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Tours1Schema>>();

                var actions = new List<ActionConfig<Tours1Schema>>
                {
                };

                return new DetailPageConfig<Tours1Schema>
                {
                    Title = "Tours",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Tours"; }
        }

    }
}
