using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Application.Users;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Details
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public EditDto Info { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var Info = await _context.information.FindAsync(request.Info.Id);
                var information = new EditDto
                {
                    Id = request.Info.Id,
                    Url = request.Info.Url,
                    Description = request.Info.Description,
                    Email = request.Info.Email,
                    Password = EncryptDecryptManager.Encrypt(request.Info.Password)
                };
                _mapper.Map(information, Info);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update Information");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}