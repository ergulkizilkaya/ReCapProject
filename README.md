# ReCapProject - Araç Kiralama Sistemi

![bitmap](https://user-images.githubusercontent.com/77868230/107104545-37940380-6833-11eb-88c0-9fa3d4771470.png)  
Bu repo **Yazılım Geliştirici Yetiştirme Kampı**'nda yapılan çalışmaları kapsayan **Araç Kiralama Projesi**'ni içerir.
## :pushpin:Getting Started
N-Katmanlı mimari yapısı ile hazırlanan, EntityFramework kullanılarak CRUD işlemlerinin yapıldığı, Wpf arayüzü ile çalışan, Araç Kiralama iş yerlerine yönelik örnek bir proje.
## :books:Layers  
![bitmap](https://user-images.githubusercontent.com/77868230/107105115-cb66cf00-6835-11eb-8fd7-9ddc5d7ac56e.png)
### Entities Layer
Veritabanı nesneleri için oluşturulmuş **Entities Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.  
<br>:file_folder:`Abstract`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IEntity.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Entities/Abstract/IEntity.cs)
<br> <br> :file_folder:`Concrete`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [Brand.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Entities/Concrete/Brand.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [Car.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Entities/Concrete/Car.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [Color.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Entities/Concrete/Color.cs)  
<br>
![rect1510](https://user-images.githubusercontent.com/77868230/107105276-82634a80-6836-11eb-9dd5-a159f029cfc0.png)
###  Business Layer
Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan **Business Katmanı**'nda **Abstract**,**Concrete**,**Utilities** ve **ValidationRules** olmak üzere dört adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.Utilities ve ValidationRules klasörlerinde validation işlemlerinin gerçekleştiği classlar mevcuttur.  
<br>:file_folder:`Abstract`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ICarService.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Business/Abstract/ICarService.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IColorService.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Business/Abstract/IColorService.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IBrandService.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Business/Abstract/IBrandService.cs)  
<br> <br> :file_folder:`Concrete`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [CarManager.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Business/Concrete/CarManager.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ColorManager.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Business/Concrete/ColorManager.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [BrandManager.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Business/Concrete/BrandManager.cs)    
<br> :file_folder:`Utilities`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ValidationTool.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Business/Utilities/ValidationTool.cs)  
<br> :file_folder:`ValidationRules`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `FluentValidation`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [CarValidator.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.Business/ValidationRules/FluentValidation/CarValidator.cs)   
<br>
![rect1510](https://user-images.githubusercontent.com/77868230/107105238-45975380-6836-11eb-8b3e-50c7b7989b14.png)
###  Data Access Layer
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan **Data Access Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.  
<br>:file_folder:`Abstract`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IBrandDal.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.DataAccess/Abstract/IBrandDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ICarDal.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.DataAccess/Abstract/ICarDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IColorDal.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.DataAccess/Abstract/IColorDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IEntityRepository.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.DataAccess/Abstract/IEntityRepository.cs)
<br> <br> :file_folder:`Concrete`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `EntityFramework`    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [EfBrandDal.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.DataAccess/Concrete/EntityFramework/EfBrandDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [EfCarDal.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.DataAccess/Concrete/EntityFramework/EfCarDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [EfColorDal.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.DataAccess/Concrete/EntityFramework/EfColorDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [NorthwindContext.cs](https://github.com/ergulkizilkaya/FinalProject/blob/master/DataAccess/Concrete/EntityFramework/NorthwindContext.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `InMemory`    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [InMemoryCarDal.cs](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProject.DataAccess/Concrete/InMemory/InMemoryCarDal.cs)  
<br>
![rect1510-4](https://user-images.githubusercontent.com/77868230/107106389-72e70000-683c-11eb-9717-e2a97e72c990.png)
### Veritabanı Oluşturma (localdb)
Araba Kiralama Projemiz localdb ile çalışmaktadır. **LocalDb**'de veritabanı oluşturmak için **Visual Studio 2019** için *View > SQL Server Object Explorer* menü yolunu takip edebilirsiniz.Pencere açıldıktan sonra *SQL Server > (localdb)MSSQLLocalDB* altındaki **Databases** klasörüne sağ tıklayıp Add **New Database** seçeneğini ile veritabanınızı oluşturabilirsiniz. Veritabanı oluşturulduktan sonra **New Query** seçerek aşağıda bulunan Sql File ile veritabanınızda olması gereken tabloları oluşturabilirsiniz.  
<br>
:file_folder:`Sql File`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ReCapProjectDB.sql](https://github.com/ergulkizilkaya/ReCapProject/blob/master/ReCapProjectDB.sql)  
<br>
## Tables
Veritabanı tablolarınızı manuel de oluşturabilirsiniz. Tablolar,sutün ve veri tipleri hakkında bilgiler aşağıda listelenmiştir.   
<table>
  <tr>
    <td>Cars</td>
     <td>Brands</td>
     <td>Colors</td>
  </tr>
  <tr>
    <td>

Variable | Data Type
------------ | -------------
Id | int
BrandId | int
ColorId | int
ModelYear | int
DailyPrice | decimal
Description | string
   
   </td>
    <td>

Variable | Data Type
------------ | -------------
Id | int
Name | string
   
   </td>
    <td>

Variable | Data Type
------------ | -------------
Id | int
Name | string
   
   </td>
  </tr>
 </table>


<br><br>
![rect1510-4](https://user-images.githubusercontent.com/77868230/107105506-d02c8280-6837-11eb-865f-b2f3b8f4e779.png)

```
EntityFrameworkCore.SqlServer 3.1.11
FluentValidation 7.3.3
```
## ScreenShots
![image](https://user-images.githubusercontent.com/77868230/107121347-f1768880-68a2-11eb-889a-c410e6833c0a.png)  
![image](https://user-images.githubusercontent.com/77868230/107121367-0bb06680-68a3-11eb-8ea8-65504ef18b07.png)  
![image](https://user-images.githubusercontent.com/77868230/107121391-37335100-68a3-11eb-9232-c4d5d5a2d29c.png)  
![image](https://user-images.githubusercontent.com/77868230/107121405-4914f400-68a3-11eb-9c90-3e75f68bab64.png)  
## :pencil2:Authors
* **Ergül Kızılkaya** - [ergulkizilkaya](https://github.com/ergulkizilkaya)
