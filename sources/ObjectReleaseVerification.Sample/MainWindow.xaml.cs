namespace OutcoldSolutions.ObjectReleaseVerification.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    using OutcoldSolutions;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<TabItem> listOfTabItems = new List<TabItem>();

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void AddTab(object sender, RoutedEventArgs e)
        {
            // Create new tab item, the header will contain "document" name
            var tabItem = new TabItem() { Header = DateTime.Now.ToString("O") };

            // Add tab item and select it
            this.TabControl.SelectedIndex = this.TabControl.Items.Add(tabItem);

            // Store tab also in our custom list of tabs
            this.listOfTabItems.Add(tabItem);

            // Track object (you can add this in constructor of your object, if it will be simple for you)
            ObjectReleaseVerifier.TrackObject(context: tabItem.Header.ToString(), trackingObject: tabItem);
        }

        private void RemoveTab(object sender, RoutedEventArgs e)
        {
            if (this.TabControl.SelectedItem != null)
            {
                // Get selected tab item
                var tabItem = (TabItem)this.TabControl.SelectedItem;

                // Remove it from the custom collection of tabs, removing this line can bring memory leak bug.
                this.listOfTabItems.Remove(tabItem);

                // Remove tab from view.
                this.TabControl.Items.Remove(tabItem);

                // Verify that all tracking objects in context which is "document" name (which we create in AddTab method)
                // are released. We ask to perform to do this with delay in 1 second, to make sure that we will go away from
                // current method and the tabItem object will not be on the stack.
                ObjectReleaseVerifier.Verify(context: tabItem.Header.ToString(), delay: 1000);
            }
        }
    }
}
