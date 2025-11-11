using AutoMapper;
using DTOs.Contracts;
using DTOs.Features.Tarea.Commands.Add;
using DTOs.Models.TareaVm;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Features.Tarea.Commands.Delete
{
    public class DeleteTareaCommandHandler : IRequestHandler<DeleteTareaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteTareaCommandHandler> _logger;

        public DeleteTareaCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteTareaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public bool DeleteOption { get; private set; }

        public async Task<bool> Handle(DeleteTareaCommand request, CancellationToken cancellationToken)
        {
            bool resp = false;
            if (!request.Id.Equals(null))
            {
                var Delete = await _unitOfWork.Repository<Domain.Tarea>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

                if (Delete != null)
                {
                    await _unitOfWork.Repository<Domain.Tarea>().DeleteAsync(Delete);

                    return true;
                }
                else
                {
                    return resp;

                }

            }
            else
            {
                return resp;

            }
        }
    }
}
