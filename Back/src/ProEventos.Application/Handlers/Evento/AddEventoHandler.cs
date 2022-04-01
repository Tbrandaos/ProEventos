using ProEventos.Domain.Services;
using MediatR;
using System.Threading.Tasks;
using ProEventos.Domain.Request.Evento;
using System.Threading;
using AutoMapper;
using System;

namespace ProEventos.Application.Handlers.Evento
{
    public class AddEventoHandler : IRequestHandler<AddEventoRequest, int>
    {
        private readonly IEventoService _service;
        private readonly IMapper _mapper;

        public AddEventoHandler(IEventoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddEventoRequest request, CancellationToken cancellationToken)
        {          
            var evento = await _service.Create(request);

            return evento.Id;
        }
    }
}