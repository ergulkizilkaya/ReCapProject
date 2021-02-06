using ReCapProject.Entities.Concrete;
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
        List<Car> GetCarsByBrandId(int v);
        List<Car> GetCarsByColorId(int v);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
