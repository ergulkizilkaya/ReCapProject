using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.Entities.Concrete;
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
    /// WindowSettings.xaml etkileşim mantığı
    /// </summary>
    public partial class WindowSettings : Window
    {
        public WindowSettings()
        {
            InitializeComponent();
            _colorService = new ColorManager(new EfColorDal());
            _brandService = new BrandManager(new EfBrandDal());
        }
        IColorService _colorService;
        IBrandService _brandService;

        Entities.Concrete.Color _selectedColor;
        Entities.Concrete.Brand _selectedBrand;

        List<Entities.Concrete.Color> colorList;
        List<Entities.Concrete.Brand> brandList;
        void LoadColors()
        {
            lvColors.ItemsSource = null;
            List<Entities.Concrete.Color> colors = _colorService.GetAll().Data;
            lvColors.ItemsSource = colors;
            colorList = colors;
        }
        void LoadBrands()
        {
            lvBrands.ItemsSource = null;
            List<Brand> brands = _brandService.GetAll().Data;
            lvBrands.ItemsSource = brands;
            brandList = brands;
        }
        private void SetBrandUpdateField()
        {
            tbxUpdateBrand.Text = _selectedBrand.Name;

            btnDeleteBrand.IsEnabled = true;
        }
        private void SetColorUpdateField()
        {
            tbxUpdateColorName.Text = _selectedColor.Name;
            btnDeleteColor.IsEnabled = true;
        }
        private void ClearBrandUpdateField()
        {
            _selectedBrand = null;
            tbxUpdateBrand.Text = null;
            btnDeleteBrand.IsEnabled = false;
        }
        private void ClearColorUpdateField()
        {
            _selectedColor = null;
            tbxUpdateColorName.Text = null;
            btnDeleteColor.IsEnabled = false;
        }

        private void success(string message)
        {
            WindowsSuccesfulMessage success = new WindowsSuccesfulMessage("Sistem Mesajı",message);
            success.Show();
        }

        private void error(string message)
        {
            WindowErrorMessage error = new WindowErrorMessage("Sistem Mesajı", message);
            error.Show();
        }


        private void BtnDeleteBrand_Click(object sender, RoutedEventArgs e)
        {
            var result = _brandService.Delete(brandList.FirstOrDefault(x => x.Id == (lvBrands.SelectedItem as Brand).Id));
            if(result.Success)
            {
                success(result.Message);
                LoadBrands();
                ClearBrandUpdateField();
            }
        }

        private void BtnUpdateBrand_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBrand != null)
            {
                _selectedBrand.Name = tbxUpdateBrand.Text;

                var result = _brandService.Update(_selectedBrand);
                if (result.Success)
                {
                    success(result.Message);
                    LoadBrands();
                    ClearBrandUpdateField();
                }
                else
                {
                    error(result.Message);
                }
            }
        }

        private void BtnAddBrand_Click(object sender, RoutedEventArgs e)
        {

            var result = _brandService.Add(new Brand { Name = tbxNewBrand.Text});
            if (result.Success)
            {
                success(result.Message);
                LoadBrands();
                ClearBrandUpdateField();
            }
            else
            {
                error(result.Message);
            }
        }

        private void LvBrands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(lvBrands.SelectedItem is null))
            {
                _selectedBrand = lvBrands.SelectedItem as Brand;
                SetBrandUpdateField();
            }
        }



        private void TbxSearchColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClearColorUpdateField();
            lvColors.ItemsSource = string.IsNullOrEmpty(tbxSearchColor.Text)
                                       ? colorList
                                       : colorList.Where(x => x.Name.ToLower().Contains(tbxSearchColor.Text.ToLower())).ToList();
        }

        private void TbxSearchBrand_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClearBrandUpdateField();
            lvBrands.ItemsSource = string.IsNullOrEmpty(tbxSearchBrand.Text)
                                       ? brandList
                                       : brandList.Where(x => x.Name.ToLower().Contains(tbxSearchBrand.Text.ToLower())).ToList();
        }

        private void LvColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(lvColors.SelectedItem is null))
            {
                _selectedColor = lvColors.SelectedItem as Entities.Concrete.Color;
                SetColorUpdateField();
            }
        }

        private void BtnUpdateColor_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedColor != null)
            {
                _selectedColor.Name = tbxUpdateColorName.Text;
                var result = _colorService.Update(_selectedColor);
                if (result.Success)
                {
                    success(result.Message);
                    LoadColors();
                    ClearColorUpdateField();
                }
                else
                {
                    error(result.Message);
                }

            }
        }

        private void BtnAddColor_Click(object sender, RoutedEventArgs e)
        {
            var result = _colorService.Add(new Entities.Concrete.Color { Name = tbxNewColor.Text });
            if (result.Success)
            {
                success(result.Message);
                LoadColors();
                ClearColorUpdateField();
                
            }
            else
            {
                error(result.Message);
            }
        }

        private void BtnDeleteColor_Click(object sender, RoutedEventArgs e)
        {
            var result = _colorService.Delete(colorList.FirstOrDefault(x => x.Id == (lvColors.SelectedItem as Entities.Concrete.Color).Id));
            if (result.Success)
            {
                success(result.Message);
                LoadColors();
                ClearColorUpdateField();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBrands();
            LoadColors();
            ClearBrandUpdateField();
            ClearColorUpdateField();

        }
    }
}
