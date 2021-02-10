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

namespace ReCapProject.WpfUI
{
    /// <summary>
    /// WindowErrorMessage.xaml etkileşim mantığı
    /// </summary>
    public partial class WindowErrorMessage : Window
    {
        public WindowErrorMessage(string des, string message)
        {
            InitializeComponent();
            lblDescription.Content = des;
            lblMessage.Text = message;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
