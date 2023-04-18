using Sandbox2.DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sandbox2.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICommand SaySomethingCommand1 { get; set; }
        public ICommand SaySomethingCommand2 { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            this.SaySomethingCommand1 = new MyCommand(o => SaySomething());

            this.SaySomethingCommand2 = new MyCommand(async o => await SaySomethingAsync());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaySomething();
        }

        private void SaySomething()
        {
            Thread.Sleep(3000);
            MessageBox.Show("Hi There!");
        }

        private async Task SaySomethingAsync()
        {
            await Task.Delay(3000);
            MessageBox.Show("Hi There!");
        }
    }
}
