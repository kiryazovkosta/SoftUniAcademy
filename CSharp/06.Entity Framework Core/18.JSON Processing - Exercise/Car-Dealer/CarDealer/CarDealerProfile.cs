using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Car;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Part;
using CarDealer.DTO.Sale;
using CarDealer.DTO.Supplier;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<ImportCarDto, Car>();
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.BirthDate, mo => mo.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy")));
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(d => d.PartsCount, mo => mo.MapFrom(s => s.Parts.Count));

            this.CreateMap<Car, ExportCarDataDto>();
            this.CreateMap<PartCar, ExportPartDto>()
                .ForMember(d => d.Name, mo => mo.MapFrom(s => s.Part.Name))
                .ForMember(d => d.Price, mo => mo.MapFrom(s => s.Part.Price.ToString("F2", CultureInfo.InvariantCulture)));
            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Car, mo => mo.MapFrom(s => s))
                .ForMember(d => d.Parts, mo => mo.MapFrom(s => s.PartCars));
        }
    }
}
