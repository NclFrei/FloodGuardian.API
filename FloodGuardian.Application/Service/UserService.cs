using AutoMapper;
using FloodGuardian.Domain.Dtos.Request;
using FloodGuardian.Domain.Dtos.Response;
using FloodGuardian.Domain.Models;
using FloodGuardian.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Application.Service;

public class UserService
{
    public FloodGuardianContext _context { get; set; }
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, FloodGuardianContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
    {
        if (await VerificaEmailExisteAsync(userRequest.Email))
            throw new InvalidOperationException("Email já cadastrado.");

        var user = _mapper.Map<User>(userRequest);

        user.Id = Guid.NewGuid();

        user.SetPassword(userRequest.Password);

        _context.User.Add(user);
        await _context.SaveChangesAsync();

        var userResponse = _mapper.Map<UserResponse>(user);
        return userResponse;
    }

    public async Task<bool> VerificaEmailExisteAsync(string email)
    {
        return await _context.User.CountAsync(u => u.Email == email) > 0;
    }
}
