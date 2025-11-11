using DTOs.Models.TareaVm;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Features.Tarea.Queries.List
{
    public class ListTareaQuery : IRequest<List<TareaModel>>
    {
        public ListTareaQuery(int? id)
        {
            Id = id;
        }
        public int? Id { get; set; }
    }
}
