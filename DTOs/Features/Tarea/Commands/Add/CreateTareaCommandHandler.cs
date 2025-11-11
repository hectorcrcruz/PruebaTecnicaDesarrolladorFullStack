using AutoMapper;
using Domain;
using DTOs.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Features.Tarea.Commands.Add
{
    public class CreateTareaCommandHandler : IRequestHandler<CreateTareaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTareaCommandHandler> _logger;

        public CreateTareaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateTareaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateTareaCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.Tarea>().GetFirstOrDefaultAsync(x => x.Titulo == request.Titulo);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Domain.Tarea>(request);
                var EntityAdd = await _unitOfWork.Repository<Domain.Tarea>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<Domain.Tarea>(EntityAdd);

                _logger.LogInformation($"La tarea fue creada con el id {EntityAdd.Id}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La tarea {request.Titulo} no fue creada");

                return resp = false;
            }
        }
    }
}
