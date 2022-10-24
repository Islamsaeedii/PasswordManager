using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    public class User
    {
        public class Query : IRequest<Result<UserInfoDto>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<UserInfoDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<UserInfoDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userInfo = await _context.Users.ProjectTo<UserInfoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
                foreach (var item in userInfo.Info)
                {
                    item.Password = EncryptDecryptManager.Decrypt(item.Password);
                }
                return Result<UserInfoDto>.Success(userInfo);
            }
        }
    }
}