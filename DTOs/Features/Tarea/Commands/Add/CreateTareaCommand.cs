using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Features.Tarea.Commands.Add
{
    public class CreateTareaCommand : IRequest<bool>
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Completada { get; set; }
    }
}
