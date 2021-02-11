using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
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
    /// WindowRental.xaml etkileşim mantığı
    /// </summary>
    public partial class WindowRental : Window
    {
        public WindowRental(CarDetailDto car)
        {
            InitializeComponent();
            _car = car;
            _customerService = new CustomerManager(new EfCustomerDal());
            _rentalService = new RentalManager(new EfRentalDal());

        }
        ICustomerService _customerService;
        IRentalService _rentalService;
        CarDetailDto _car;
        Customer _selectedCustomer;
        List<Customer> customerList;
        void LoadCustomers()
        {
            customerList = _customerService.GetAll().Data;
            lvCustomers.ItemsSource = customerList;
        }
        private void SetFields()
        {
            tbxCustomerName.Text = _selectedCustomer.CompanyName;
        }
        private void ClearUpdateField()
        {
            _selectedCustomer = null;
            tbxCustomerName.Text = null;
        }

        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            ClearUpdateField();
            lvCustomers.ItemsSource = string.IsNullOrEmpty(tbxSearch.Text)
                                       ? customerList
                                       : customerList.Where(x => x.CompanyName.ToLower().Contains(tbxSearch.Text.ToLower())).ToList();

        }

      
        private void LvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(lvCustomers.SelectedItem is null))
            {
                _selectedCustomer = lvCustomers.SelectedItem as Customer;
                SetFields();
            }
        }

      

        private void BtnAddRental_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer != null)
            {
                Rental rental = new Rental
                {
                    CarId = _car.Id,
                    RentDate = DateTime.Now,
                    ReturnDate = null,
                    CustomerId = _selectedCustomer.Id
                    

                };
                var result = _rentalService.Add(rental);
                if (result.Success)
                {
                    WindowsSuccesfulMessage success = new WindowsSuccesfulMessage("Sistem Mesajı",result.Message);
                    success.ShowDialog();
                    this.Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
            lblBrand.Text = _car.BrandName;
            lblColor.Text = _car.ColorName;
            lblDailyPrice.Text = _car.DailyPrice.ToString();
            lblDescription.Text = _car.Description;
            lblModelYear.Text = _car.ModelYear.ToString();
            tbxCarName.Text = _car.Name;
            lblCarName.Content = _car.Name;
            tbxRentDate.Text = string.Format("{0:dd.MM.yyyy hh:mm}",DateTime.Now);


        }
    }
}
