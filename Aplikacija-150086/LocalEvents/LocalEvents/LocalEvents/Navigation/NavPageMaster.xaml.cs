using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalEvents.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPageMaster : ContentPage
    {
        public ListView ListView;

        public NavPageMaster()
        {
            InitializeComponent();

            BindingContext = new NavPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class NavPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NavPageMenuItem> MenuItems { get; set; }

            public NavPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<NavPageMenuItem>(new[]
                {
                    new NavPageMenuItem { Id = 0, Title = "Events", TargetType = typeof(Events.MainPage) },
                    new NavPageMenuItem { Id = 1, Title = "My Events", TargetType = typeof(Events.MyEvents) },
                    new NavPageMenuItem { Id = 2, Title = "Locations", TargetType = typeof(Lokacije.MainPage) },
                    new NavPageMenuItem {Id = 3, Title = "My Fav. Locations", TargetType = typeof(Lokacije.MyFavLocationsPage)},
                    new NavPageMenuItem { Id = 4, Title = "My Profile", TargetType = typeof(User.MyProfilePage) },
                    new NavPageMenuItem { Id = 5, Title = "Sign Out", TargetType = typeof(LoginPage) } //LoginPage
                });
                
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}