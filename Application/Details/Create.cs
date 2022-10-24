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
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Information Information { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Information).SetValidator(new DetailsValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
            {
                _mapper = mapper;
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == _userAccessor.GetNameIdentifier());
                var information = new InfoDto
                {
                    AppUser = user,
                    FkAppUser = user.Id,
                    Url = request.Information.Url,
                    Description = request.Information.Description,
                    Email = request.Information.Email,
                    Password = EncryptDecryptManager.Encrypt(request.Information.Password)
                };
                _context.information.Add(_mapper.Map<Information>(information));
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to Create Information");
                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}