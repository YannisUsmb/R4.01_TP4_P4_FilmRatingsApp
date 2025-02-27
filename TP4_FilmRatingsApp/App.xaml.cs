﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using TP4_FilmRatingsApp.Views;
using TP4_FilmRatingsApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TP4_FilmRatingsApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Gets the instance to resolve application services.
        /// </summary>
        public ServiceProvider Services { get; }


        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            /// <summary>
            /// Configures the services for the application.
            /// </summary>
            ServiceCollection services = new ServiceCollection();

            // ViewModels
            services.AddTransient<VisualiserUtilisateurViewModel>();

            Services = services.BuildServiceProvider();

        }

        /// <summary>
        /// Gets the current app instance in use.
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            // Create a Frame to act as the navigation context and navigate to the first page
            Frame rootFrame = new Frame();
            // Place the frame in the current Window
            this.m_window.Content = rootFrame;
            // Ensure the current window is active
            m_window.Activate();
            // Navigate to the first page
            rootFrame.Navigate(typeof(VisualiserUtilisateurPage));

            MainRoot = m_window.Content as FrameworkElement;

        }

        public Window m_window;

        public static FrameworkElement MainRoot { get; private set; }
    }
}
