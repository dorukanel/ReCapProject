﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DorukanAracContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (DorukanAracContext context = new DorukanAracContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors on c.ColorId equals clr.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             

                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 ColorName = clr.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ColorId = clr.ColorId,
                                 BrandId = b.BrandId,
                                 Id = c.CarId,
                                 ModelYear = c.ModelYear
                                 
                             };


                return result.ToList();
            }

        }


    }
}