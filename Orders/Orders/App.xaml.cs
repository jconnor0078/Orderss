﻿using Orders.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Orders
{
    public partial class App : Application
    {
        public static INavigation Navigator { get; internal set; }

        public App()
        {
            InitializeComponent();

            //  MainPage = new Orders.MainPage();
            MainPage = new MasterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}