using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using TP4_FilmRatingsApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TP4_FilmRatingsApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VisualiserUtilisateurPage : Page
    {
        public VisualiserUtilisateurPage()
        {
            this.InitializeComponent();
            this.DataContext = App.Current.Services.GetService<VisualiserUtilisateurViewModel>();
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            Frame rootFrame = new Frame();
            ((App)Application.Current).m_window.Content = rootFrame;
            ((App)Application.Current).m_window.Activate();
            var selectedItem = args.SelectedItem as NavigationViewItem;
            if (selectedItem != null)
            {
                string tag = selectedItem.Tag.ToString();
                switch (tag)
                {
                    case "Utilisateur":
                        rootFrame.Navigate(typeof(VisualiserUtilisateurPage));
                        break;
                    case "Film":
                        rootFrame.Navigate(typeof(FilmPage));
                        break;
                }
            }
        }
    }
}
