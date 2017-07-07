using GalaSoft.MvvmLight.Command;
using Orders.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Orders.Services;

namespace Orders.ViewModels
{
    public class MainViewModel
    {
        NavigationServices navigationService;
        ApiService apiService;
        
        public MainViewModel()
        {
            navigationService = new Orders.Services.NavigationServices();
            apiService = new ApiService();
            Orders = new ObservableCollection<OrderViewModel>();
            LoadMenu();
            //LoadData();
        }

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        #endregion

        #region Commands

        public ICommand GoToCommand
        {
            get
            {
                return new RelayCommand<string>(GoTo);
            }
        }

        public ICommand StartCommand
        {
            get
            {
                return new RelayCommand(Start);
            }
        }

        private void GoTo(string pageName)
        {
            navigationService.Navigate(pageName);
        }

        #endregion

        #region Method

        private async void Start()
        {
            var list = await apiService.GetAllOrders();
            Orders.Clear();
            foreach (var item in list)
            {
                Orders.Add(new OrderViewModel()
                {
                    Title= item.Title,
                    DeliveryDate= item.DeliveryDate!=null?item.DeliveryDate.Value:DateTime.MinValue,
                    Description= item.Description
                });
            }
            navigationService.SetMainPage("MasterPage");
        }
        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_orders",
                Title = "Pedidos",
                PageName = "MainPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_clients",
                Title = "Clientes",
                PageName = "ClientsPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_alarm",
                Title = "Alarmas",
                PageName = "AlarmsPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_settings",
                Title = "Ajustes",
                PageName = "SettingsPage"
            });
        }
        private void LoadData()
        {
          
            for (int i = 0; i < 5; i++)
            {
                Orders.Add(new OrderViewModel()
                {
                    Title = "Lorem Ipsum" + i.ToString(),
                    Description = "Esta es una Descripció corta del Producto" + i.ToString(),
                    DeliveryDate = DateTime.Today
                });
            }
        }

     
        #endregion



    }
}
