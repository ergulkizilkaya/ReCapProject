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
    /// WindowRentalDetails.xaml etkileşim mantığı
    /// </summary>
    public partial class WindowRentalDetails : Window
    {
        public WindowRentalDetails(CarDetailDto car)
        {
            InitializeComponent();
            _rentalService = new RentalManager(new EfRentalDal());
            _car = car;
        }
        IRentalService _rentalService;
        CarDetailDto _car;
        List<Rental> _rentals;
        List<RentalDetailDto> _rentalDetails;
        private void LoadRentals()
        {
            _rentals = _rentalService.GetAll().Data;
            _rentalDetails = _rentalService.GetRentalDetailsDto(_car.Id).Data;
            lvRentals.ItemsSource = _rentalDetails;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRentals();
            lblBrand.Text = _car.BrandName;
            lblColor.Text = _car.ColorName;
            lblDailyPrice.Text = _car.DailyPrice.ToString();
            lblDescription.Text = _car.Description;
            lblModelYear.Text = _car.ModelYear.ToString();
            lblCarName.Content = _car.Name;
        }

        private void BtnReturnCar_Click(object sender, RoutedEventArgs e)
        {
            if (_rentalDetails != null)
            {
                var result = _rentalService.UpdateReturnDate(_car.Id);

                if (result.Success)
                {
                    WindowsSuccesfulMessage success = new WindowsSuccesfulMessage("Sistem Mesajı", "Araç Teslim Alındı");
                    success.ShowDialog();
                    LoadRentals();
                }
                else
                {
                    WindowErrorMessage success = new WindowErrorMessage("Sistem Mesajı", "Araç Zaten Teslim Alınmış");
                    success.ShowDialog();
                }
            }

        }
    }
}
