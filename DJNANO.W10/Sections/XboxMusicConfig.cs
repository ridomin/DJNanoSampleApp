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
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=bbcdf6a7-c7ff-4628-b3b3-fc115477e455&appId=f079a57d-fb37-4e31-be1b-212a20dbe380"),
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
                    viewModel.PageTitle = "Album";
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = item.ReleaseDate.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Tracks";
                    viewModel.Title = item.Title.ToSafeString();
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
