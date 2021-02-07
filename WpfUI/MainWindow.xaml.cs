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

namespace WpfUI
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
        }
        ICarService _carService;
        IColorService _colorService;
        IBrandService _brandService;
        Car _selectedCar;
        List<Car> cars;
        List<CarDetailDto> carsDto;
        void LoadCars()
        {
            cars = _carService.GetAll();
            carsDto = _carService.GetCarDetailDto();
            lvCars.ItemsSource = carsDto;
            lvCarsUpdate.ItemsSource = cars;
        }
        void LoadColors()
        {
            List<ReCapProject.Entities.Concrete.Color> colors = _colorService.GetColors();

            cbxColors.ItemsSource = colors;
            cbxColors.DisplayMemberPath = "Name";
            cbxColors.SelectedValuePath = "Id";

            cbxUpdateColor.ItemsSource = colors;
            cbxUpdateColor.DisplayMemberPath = "Name";
            cbxUpdateColor.SelectedValuePath = "Id";

            cbxColors_Add.ItemsSource = colors;
            cbxColors_Add.DisplayMemberPath = "Name";
            cbxColors_Add.SelectedValuePath = "Id";
        }
        void LoadBrands()
        {
            List<ReCapProject.Entities.Concrete.Brand> brands = _brandService.GetBrands();

            cbxBrands.ItemsSource = brands;
            cbxBrands.DisplayMemberPath = "Name";
            cbxBrands.SelectedValuePath = "Id";

            cbxUpdateBrand.ItemsSource = brands;
            cbxUpdateBrand.DisplayMemberPath = "Name";
            cbxUpdateBrand.SelectedValuePath = "Id";

            cbxBrands_Add.ItemsSource = brands;
            cbxBrands_Add.DisplayMemberPath = "Name";
            cbxBrands_Add.SelectedValuePath = "Id";

        }
        void GetCarsByColorId(int colorId) => lvCars.ItemsSource = _carService.GetCarsByColorId(colorId);
        void GetCarsByBrandId(int brandId) => lvCars.ItemsSource = _carService.GetCarsByBrandId(brandId);
        void ShowCount() => lblCarsCount.Content = lvCars.Items.Count;
        void SetUpdateField()
        {
            tbxUpdatedName.Text = _selectedCar.Name;
            tbxUpdateDailyPrice.Text = _selectedCar.DailyPrice.ToString();
            tbxUpdateDescription.Text = _selectedCar.Description;
            tbxUpdateModelYear.Text = _selectedCar.ModelYear.ToString();
            cbxUpdateBrand.SelectedValue = _selectedCar.BrandId;
            cbxUpdateColor.SelectedValue = _selectedCar.ColorId;
        }
        void ClearUpdateField()
        {
            tbxUpdateDailyPrice.Text = null;
            tbxUpdateDescription.Text = null;
            tbxUpdatedName.Text = null;
            tbxUpdateModelYear.Text = null;
            cbxUpdateBrand.SelectedIndex = -1;
            cbxUpdateColor.SelectedIndex = -1;
        }
        void ClearInsertField()
        {
            tbxDailyPrice.Text = null;
            tbxDescription.Text = null;
            tbxName.Text = null;
            tbxModelYear.Text = null;
            cbxBrands_Add.SelectedIndex = -1;
            cbxColors_Add.SelectedIndex = -1;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCars();
            LoadColors();
            LoadBrands();
            ShowCount();
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
                _selectedCar = cars.FirstOrDefault(x=>x.Id==(lvCars.SelectedItem as CarDetailDto).Id); 
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
                try
                {
                    _selectedCar.BrandId = (int)cbxUpdateBrand.SelectedValue;
                    _selectedCar.ColorId = (int)cbxUpdateColor.SelectedValue;
                    _selectedCar.DailyPrice = Convert.ToDecimal(tbxUpdateDailyPrice.Text);
                    _selectedCar.ModelYear = Convert.ToInt32(tbxUpdateModelYear.Text);
                    _selectedCar.Description = tbxUpdateDescription.Text;
                    _selectedCar.Name = tbxUpdatedName.Text;
                    _carService.Update(_selectedCar);
                    WindowsSuccesfulMessage success = new WindowsSuccesfulMessage("Başarılı", "Araç Güncelleme İşlemi Başarılı");
                    success.ShowDialog();
                    LoadCars();
                    ClearUpdateField();
                    _selectedCar = null;
                    tbxSearch.Text = null;

                    
                }
                catch (Exception ex)
                {
                    WindowErrorMessage error = new WindowErrorMessage("Sistem Uyarısı",ex.Message);
                    error.ShowDialog();
                }

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
            try
            {
                Car car = new Car
                {
                    BrandId = (int)cbxBrands_Add.SelectedValue,
                    ColorId = (int)cbxColors_Add.SelectedValue,
                    DailyPrice = Convert.ToDecimal(tbxDailyPrice.Text),
                    Description = tbxDescription.Text,
                    ModelYear = Convert.ToInt32(tbxModelYear.Text),
                    Name = tbxName.Text
                };
                _carService.Add(car);
                WindowsSuccesfulMessage success = new WindowsSuccesfulMessage("Başarılı", "Araç Kayıt İşlemi Başarılı");
                success.ShowDialog();
                LoadCars();
                ShowCount();
                ClearInsertField();

            }
            catch (NullReferenceException)
            {
                WindowErrorMessage error = new WindowErrorMessage("Sistem Uyarısı", "Kayıt başarısız, girdiğiniz bilgileri kontrol ediniz.");
                error.ShowDialog();
           
            }
            catch (Exception ex)
            {
                WindowErrorMessage error = new WindowErrorMessage("Sistem Uyarısı", ex.Message);
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
    }
}
