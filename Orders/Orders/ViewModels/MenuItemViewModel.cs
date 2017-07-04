using GalaSoft.MvvmLight.Command;
using Orders.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Orders.Services;

namespace Orders.ViewModels
{
    public class MenuItemViewModel
    {

        NavigationServices navigationService;

        public MenuItemViewModel()
        {
            navigationService = new NavigationServices();
        }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(()=> navigationService.Navigate(PageName));
            }
        }

       
    }
}
