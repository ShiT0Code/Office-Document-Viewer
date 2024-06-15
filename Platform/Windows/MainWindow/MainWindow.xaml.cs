using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Office_Document_Viewer.Home_Open;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Office_Document_Viewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }


        private void OnAddTabButtonClick(TabView sender, object args)
        {
            // Create a new tab. 
            var newTab = new TabViewItem
            {
                Header = "New Tab",
                Content = new OpenPage()
            };

            // Add the TabView
            sender.TabItems.Add(newTab);

            // Select the tab 
            sender.SelectedItem = newTab;
        }

        private void OnTabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            // Remove the tab 
            sender.TabItems.Remove(args.Tab);
        }
    }
}
