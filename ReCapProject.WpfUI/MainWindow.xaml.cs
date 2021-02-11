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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReCapProject.WpfUI
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _carService = new CarManager(new EfCarDal());
            _colorService = new ColorManager(new EfColorDal());
            _brandService = new BrandManager(new EfBrandDal());
            _rentalService = new RentalManager(new EfRentalDal());

        }
        IRentalService _rentalService;
        ICarService _carService;
        IColorService _colorService;
        IBrandService _brandService;
        Car _selectedCar;
        List<Car> cars;
        List<CarDetailDto> carsDto;
        void LoadCars()
        {
            cars = _carService.GetAll().Data;
            carsDto = _carService.GetCarDetails().Data;
            lvCars.ItemsSource = carsDto;
            lvCarsUpdate.ItemsSource = cars;
        }
        void LoadColors()
        {
            List<Entities.Concrete.Color> colors = _colorService.GetAll().Data;

            cbxColors.ItemsSource = colors;
            cbxColors.DisplayMemberPath = "Name";
            cbxColors.SelectedValuePath = "Id";

            cbxUpdateColor.ItemsSource = colors;
            cbxUpdateColor.DisplayMemberPath = "Name";
            cbxUpdateColor.SelectedValuePath = "Id";
            cbxUpdateColor.SelectedIndex = 0;


            cbxColors_Add.ItemsSource = colors;
            cbxColors_Add.DisplayMemberPath = "Name";
            cbxColors_Add.SelectedValuePath = "Id";
            cbxColors_Add.SelectedIndex = 0;
        }
        void LoadBrands()
        {
            List<Brand> brands = _brandService.GetAll().Data;

            cbxBrands.ItemsSource = brands;
            cbxBrands.DisplayMemberPath = "Name";
            cbxBrands.SelectedValuePath = "Id";

            cbxUpdateBrand.ItemsSource = brands;
            cbxUpdateBrand.DisplayMemberPath = "Name";
            cbxUpdateBrand.SelectedValuePath = "Id";
            cbxUpdateBrand.SelectedIndex = 0;

            cbxBrands_Add.ItemsSource = brands;
            cbxBrands_Add.DisplayMemberPath = "Name";
            cbxBrands_Add.SelectedValuePath = "Id";
            cbxBrands_Add.SelectedIndex = 0;

        }
        void GetCarsByColorId(int colorId) => lvCars.ItemsSource = _carService.GetCarsByColorId(colorId).Data;
        void GetCarsByBrandId(int brandId) => lvCars.ItemsSource = _carService.GetCarsByBrandId(brandId).Data;
        void ShowCount() => lblCarsCount.Content = lvCars.Items.Count;
        void SetUpdateField()
        {
            tbxUpdatedName.Text = _selectedCar.Name;
            tbxUpdateDailyPrice.Text = _selectedCar.DailyPrice.ToString();
            tbxUpdateDescription.Text = _selectedCar.Description;
            tbxUpdateModelYear.Text = _selectedCar.ModelYear.ToString();
            cbxUpdateBrand.SelectedValue = _selectedCar.BrandId;
            cbxUpdateColor.SelectedValue = _selectedCar.ColorId;

            spUpdateField.IsEnabled = true;
            spUpdateField.Opacity = 1;
        }
        void ClearUpdateField()
        {
            tbxUpdateDailyPrice.Text = null;
            tbxUpdateDescription.Text = null;
            tbxUpdatedName.Text = null;
            tbxUpdateModelYear.Text = null;

            spUpdateField.IsEnabled = false;
            spUpdateField.Opacity = 0.3;
        }
        void ClearInsertField()
        {
            tbxDailyPrice.Text = null;
            tbxDescription.Text = null;
            tbxName.Text = null;
            tbxModelYear.Text = null;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCars();
            LoadColors();
            LoadBrands();
            ShowCount();
            ClearUpdateField();
        }

        private void CbxColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                GetCarsByColorId((int)cbxColors.SelectedValue);
                cbxBrands.SelectedIndex = -1;
                ShowCount();
            }
            catch { }
        }

        private void CbxBrands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                GetCarsByBrandId((int)cbxBrands.SelectedValue);
                cbxColors.SelectedIndex = -1;
                ShowCount();
            }
            catch { }
        }

        private void BtnFilterClear_Click(object sender, RoutedEventArgs e)
        {
            cbxColors.SelectedIndex = -1;
            cbxBrands.SelectedIndex = -1;
            LoadCars();
            ShowCount();
        }

        private void LvCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCars.SelectedItem is null)
            {
                btnMiniUpdate.IsEnabled = false;
                btnMiniDelete.IsEnabled = false;
            }
            else
            {
                btnMiniUpdate.IsEnabled = true;
                btnMiniDelete.IsEnabled = true;
            }

        }

        private void BtnMiniAdd_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void BtnMiniUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvCars.SelectedItem is null))
            {
                tabControl.SelectedIndex = 2;
                _selectedCar = cars.FirstOrDefault(x => x.Id == (lvCars.SelectedItem as CarDetailDto).Id);
                lvCarsUpdate.SelectedItem = _selectedCar;
            }

        }

        private void BtnMiniDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvCars.SelectedItem is null))
            {
                var result = MessageBox.Show("Seçilen Araç Kaydı Silinecektir. Onaylıyor Musunuz ?", "Dikkat", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _carService.Delete(cars.FirstOrDefault(x => x.Id == (lvCars.SelectedItem as CarDetailDto).Id));
                    LoadCars();
                    ShowCount();
                }
            }

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!(_selectedCar is null))
            {
                    _selectedCar.BrandId = (int)cbxUpdateBrand.SelectedValue;
                    _selectedCar.ColorId = (int)cbxUpdateColor.SelectedValue;
                    _selectedCar.DailyPrice = Convert.ToDecimal(tbxUpdateDailyPrice.Text);
                    _selectedCar.ModelYear = Convert.ToInt32(tbxUpdateModelYear.Text);
                    _selectedCar.Description = tbxUpdateDescription.Text;
                    _selectedCar.Name = tbxUpdatedName.Text;

                    var result = _carService.Update(_selectedCar);
                    if (result.Success)
                    {
                        WindowsSuccesfulMessage success = new WindowsSuccesfulMessage("Başarılı",result.Message);
                        success.ShowDialog();
                        LoadCars();
                        ShowCount();
                        ClearInsertField();
                    }
                    else
                    {
                        WindowErrorMessage error = new WindowErrorMessage("Sistem Uyarısı", result.Message);
                        error.ShowDialog();
                    }
                    LoadCars();
                    ClearUpdateField();
                    _selectedCar = null;
                    tbxSearch.Text = null;

            }
        }

        private void LvCarsUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(lvCarsUpdate.SelectedItem is null))
            {
                _selectedCar = lvCarsUpdate.SelectedItem as Car;
                SetUpdateField();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            decimal dailyprice=0;
            decimal.TryParse(tbxDailyPrice.Text, out dailyprice);

            int modelYear = 0;
            int.TryParse(tbxModelYear.Text, out modelYear);

            Car car = new Car
            {
                BrandId = (int)cbxBrands_Add.SelectedValue,
                ColorId = (int)cbxColors_Add.SelectedValue,
                DailyPrice = dailyprice,
                ModelYear = modelYear,
                Description = tbxDescription.Text,
                Name = tbxName.Text
            };
            var result = _carService.Add(car);
            if (result.Success)
            {
                WindowsSuccesfulMessage success = new WindowsSuccesfulMessage("Başarılı", result.Message);
                success.ShowDialog();
                LoadCars();
                ShowCount();
                ClearInsertField();
            }
            else
            {
                WindowErrorMessage error = new WindowErrorMessage("Sistem Uyarısı", result.Message);
                error.ShowDialog();
            }




        }

        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _selectedCar = null;
            ClearUpdateField();
            lvCarsUpdate.ItemsSource = string.IsNullOrEmpty(tbxSearch.Text)
                                       ? cars
                                       : cars.Where(x => x.Name.ToLower().Contains(tbxSearch.Text.ToLower())).ToList();
        }

        private void BtnOptions_Click(object sender, RoutedEventArgs e)
        {
            WindowSettings settings = new WindowSettings();
            settings.ShowDialog();
            LoadBrands();
            LoadColors();
            LoadCars();
            ClearInsertField();
            ClearUpdateField();
            ShowCount();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            var result = _rentalService.CheckReturnDate(int.Parse(senderButton.Tag.ToString()));

            if(result.Success)
            {
                WindowRental rental = new WindowRental(carsDto.FirstOrDefault(x => x.Id == int.Parse(senderButton.Tag.ToString())));
                rental.ShowDialog();
            }
            else
            {
                WindowErrorMessage error = new WindowErrorMessage("Sistem Mesajı","Seçilen Araç Henüz Teslim Edilmediği İçin Kiraya Verme İşlemi Yapılamaz.");
                error.ShowDialog();
            }

           
         
        }

        private void BtnShowRental_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            var result = _rentalService.CheckReturnDate(int.Parse(senderButton.Tag.ToString()));


                WindowRentalDetails rental = new WindowRentalDetails(carsDto.FirstOrDefault(x => x.Id == int.Parse(senderButton.Tag.ToString())));
                rental.ShowDialog();
          

        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
