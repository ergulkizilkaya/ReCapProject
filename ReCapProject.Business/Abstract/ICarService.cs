using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<CarDetailDto> GetCarsByBrandId(int v);
        List<CarDetailDto> GetCarsByColorId(int v);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<CarDetailDto> GetCarDetailDto();
    }
}
