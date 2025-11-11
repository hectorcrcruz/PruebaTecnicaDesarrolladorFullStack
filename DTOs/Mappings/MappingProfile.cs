using AutoMapper;
using Domain;
using DTOs.Features.Tarea.Commands.Add;
using DTOs.Features.Tarea.Commands.Up;
using DTOs.Models.TareaVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTareaCommand, Tarea>();
            CreateMap<UpdateTareaCommand, Tarea>();
            CreateMap<Tarea, TareaModel>();
        }
    }
}
