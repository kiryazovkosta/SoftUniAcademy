using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;

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

            this.CreateMap<Car, ExportCarWithDistanceDto>();
            this.CreateMap<Car, ExportCarFromMakeBmwDto>();
            this.CreateMap<Supplier, ExportLocalSupplierDto>()
                .ForMember(d => d.PartsCount, mo => mo.MapFrom(s => s.Parts.Count));

            this.CreateMap<Part, ExportPartDto>();
            this.CreateMap<Car, ExportCarWithPartsListDto>()
                .ForMember(d => d.Parts, mo => mo.MapFrom(s => s.PartCars.Select(pc => pc.Part).OrderByDescending(p => p.Price)));

            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.FullName, mo => mo.MapFrom(s => s.Name))
                .ForMember(d => d.BoughtCars, mo => mo.MapFrom(s => s.Sales.Count()))
                .ForMember(d => d.SpentMoney, mo => mo.MapFrom(s => s.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))));

            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Sale, ExportSaleDto>()
                .ForMember(d => d.Price, mo => mo.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price)))
                .ForMember(d => d.PriceWithDiscount, mo => mo.MapFrom(s => (s.Car.PartCars.Sum(pc => pc.Part.Price) - ((s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount / 100))))));
        }
    }
}
