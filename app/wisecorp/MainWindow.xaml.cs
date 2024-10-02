﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Threading;
using System.Globalization;
using System.Windows.Media;
using System.Diagnostics;



namespace wisecorp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NavigationService NavigationService { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            this.NavigationService = this.GetNavigationService();

            // Hide the default navigation
            MainNavigationFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            // Navigate to the first page
            // MainNavigationFrame.NavigationService.Navigate(new Uri("Views/Login.xaml", UriKind.Relative));
        }

        // Add a method to access the NavigationService of the frame
        public NavigationService GetNavigationService()
        {
            return MainNavigationFrame.NavigationService;
        }

        // Clicking on the logo will open the GitHub page
        private void OpenGitHub(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/cegep-chicoutimi/WiseCorp-temps",
                UseShellExecute = true
            });
        }

        private void Next_Btn(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoForward)
                NavigationService.GoForward();
        }

        private void Back_Btn(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void Open_Settings(object sender, RoutedEventArgs e)
        {
            MainNavigationFrame.NavigationService.Navigate(new Uri("Views/ViewSettings.xaml", UriKind.Relative));
        }

        public Frame GetMainNavigationFrame()
        {
            return MainNavigationFrame;
        }

        public void SetWindowInfos(string title, double minHeight, double minWidth, double maxHeight = double.PositiveInfinity, double maxWidth = double.PositiveInfinity)
        {
            Window window = GetWindow(this);
            if (window != null)
            {
                window.Title = title;
                window.MinHeight = minHeight;
                window.MinWidth = minWidth;
                window.MaxHeight = maxHeight;
                window.MaxWidth = maxWidth;
            }
        }
    }
}