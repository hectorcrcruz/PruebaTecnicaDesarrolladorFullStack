using AutoMapper;
using DTOs.Contracts;
using DTOs.Models.TareaVm;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Features.Tarea.Queries.List
{
    public class ListTareaQueryHandler : IRequestHandler<ListTareaQuery, List<TareaModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListTareaQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListTareaQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListTareaQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<TareaModel>> Handle(ListTareaQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                var entity = await _unitOfWork.Repository<Domain.Tarea>().GetAsync(x => x.Id == request.Id);
                var entityVm = _mapper.Map<List<TareaModel>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Domain.Tarea>().GetAllAsync();
                var entityVm = _mapper.Map<List<TareaModel>>(entity);

                return entityVm;

            }
        }
    }
}
