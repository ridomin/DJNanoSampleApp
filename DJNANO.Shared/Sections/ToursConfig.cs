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
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=2fda093d-90b0-42a1-b1f3-c0a78659544f&appId=817d0baf-4b9c-4b0f-894f-2210734bd402"),
                    AppId = "817d0baf-4b9c-4b0f-894f-2210734bd402",
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
                        viewModel.Title = item.Cuando.ToSafeString();
                        viewModel.SubTitle = item.Donde.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.ImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return null;
                    }
                };
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
