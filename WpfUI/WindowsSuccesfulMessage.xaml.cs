using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfUI
{
    /// <summary>
    /// WindowsSuccesfulMessage.xaml etkileşim mantığı
    /// </summary>
    public partial class WindowsSuccesfulMessage : Window
    {
        public WindowsSuccesfulMessage(string des, string message)
        {
            InitializeComponent();
            lblDescription.Content = des;
            lblMessage.Text = message;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
            }

        }
    }
}
