using AutoMapper;
using DTOs.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Features.Tarea.Commands.Up
{
    public class UpdateTareaCommandHandler : IRequestHandler<UpdateTareaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTareaCommandHandler> _logger;

        public UpdateTareaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateTareaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateTareaCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.Tarea>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.Descripcion = request.Descripcion;
                VerifiData.FechaCreacion = request.FechaCreacion;
                VerifiData.Completada = request.Completada;
                VerifiData.Titulo = request.Titulo;

                var EntityGetResponse = await _unitOfWork.Repository<Domain.Tarea>().UpdateAsync(VerifiData);

                _logger.LogInformation($"La tarea {request.Id} fue actualizada");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La tarea {request.Id} no fue actualizada");

                return resp = false;
            }
        }
    }
}
