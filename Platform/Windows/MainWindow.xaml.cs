using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using OfficeDocumentViewer.Models.Settings;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OfficeDocumentViewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.SetTitleBar(AppTitleBar);
            ExtendsContentIntoTitleBar = true;
        }

        private void AdddeFaultTab(SplitButton sender, SplitButtonClickEventArgs args)
        {
            AddNewTab("FileExplorer", "OpenFile");
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            AddNewTab("Home", "Home");
        }

        private void OpenButton(object sender, RoutedEventArgs e)
        {
            AddNewTab("FileExplorer", "OpenFile");
        }

        private void SettingsButton(object sender, RoutedEventArgs e)
        {
            AddNewTab("Settings", "SettingsPage");
        }

        private void AboutButton(object sender, RoutedEventArgs e)
        {
            var new_window = new AboutProject();
            new_window.Activate();
        }

        private void AddNewTab(string modelName1,string modelName2)
        {
            var newTab = new TabViewItem();
            newTab.Header = "newTab";
            string modelLongName = $"OfficeDocumentViewer.Models.{modelName1}.{modelName2}";
            try
            {
                Type type = Type.GetType(modelLongName);
                Frame frame = new();
                newTab.Content = frame;
                frame.Navigate(type);
            }
            catch
            {
                newTab.Content = "Something went wrong:\n" +
                    "Counld not find Model\""
                    + $"{modelLongName}" + "\"";
            }
            tabView.TabItems.Add(newTab);
            tabView.SelectedItem = newTab;
        }

        private void tabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
        }
    }
}
