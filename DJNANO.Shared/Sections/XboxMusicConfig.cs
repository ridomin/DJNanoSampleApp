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
    public class XboxMusicConfig : SectionConfigBase<DynamicStorageDataConfig, XboxMusic1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, XboxMusic1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<XboxMusic1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=03b2a14d-dd3e-4bc0-90c4-f4587d1e4881&appId=817d0baf-4b9c-4b0f-894f-2210734bd402"),
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
                return NavigationInfo.FromPage("XboxMusicListPage");
            }
        }

        public override ListPageConfig<XboxMusic1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<XboxMusic1Schema>
                {
                    Title = "Discografía",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.ReleaseDate.ToSafeString();
                        viewModel.Description = null;
                        viewModel.Image = item.ImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("XboxMusicDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<XboxMusic1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, XboxMusic1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = "";
                    viewModel.Description = item.ReleaseDate.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = "";
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<XboxMusic1Schema>>
				{
                    ActionConfig<XboxMusic1Schema>.Play("Play", (item) => item.Link.ToSafeString()),
				};

                return new DetailPageConfig<XboxMusic1Schema>
                {
                    Title = "Discografía",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Discografía"; }
        }

    }
}
