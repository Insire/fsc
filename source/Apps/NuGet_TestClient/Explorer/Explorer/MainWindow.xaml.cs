﻿namespace Explorer
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;

            var appVM = new ExplorerLib.ViewModels.ApplicationViewModel();
            this.DataContext = appVM;

            var newPath = FileSystemModels.PathFactory.SysDefault;
            appVM.InitializeViewModel(newPath);
        }

        protected override void OnClosed(EventArgs e)
        {
            var disposeAble = (this.DataContext as IDisposable); // Dispose of ViewModels
            if (disposeAble != null)
            {
                disposeAble.Dispose();
            }
            this.DataContext = null;

            base.OnClosed(e);
        }
    }
}
