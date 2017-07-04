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
        
        public MainViewModel()
        {
            navigationService = new NavigationServices();
            LoadMenu();
            LoadData();
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

        private void GoTo(string pageName)
        {
            navigationService.Navigate(pageName);
        }

        #endregion

        #region Method
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
            Orders = new ObservableCollection<OrderViewModel>();
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
