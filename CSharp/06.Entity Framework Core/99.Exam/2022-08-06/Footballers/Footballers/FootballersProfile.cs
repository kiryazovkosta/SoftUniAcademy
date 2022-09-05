namespace Footballers
{
    using AutoMapper;
    using Footballers.Common;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using System;
    using System.Globalization;

    public class FootballersProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public FootballersProfile()
        {
            this.CreateMap<CoachInputModel, Coach>()
                .ForMember(d => d.Footballers, mo => mo.Ignore());
            this.CreateMap<FootballerInputModel, Footballer>()
                .ForMember(d => d.ContractStartDate, mo => mo.MapFrom(s => DateTime.ParseExact(s.ContractStartDate, GlobalConstants.FootballerDateFormat, CultureInfo.InvariantCulture)))
                .ForMember(d => d.ContractEndDate, mo => mo.MapFrom(s => DateTime.ParseExact(s.ContractEndDate, GlobalConstants.FootballerDateFormat, CultureInfo.InvariantCulture)))
                .ForMember(d => d.BestSkillType, mo => mo.MapFrom(s => (BestSkillType)s.BestSkillType))
                .ForMember(d => d.PositionType, mo => mo.MapFrom(s => (PositionType)s.PositionType));

            this.CreateMap<TeamInputModel, Team>()
                .ForMember(d => d.TeamsFootballers, mo => mo.Ignore());
        }
    }
}
