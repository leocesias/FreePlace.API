﻿using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Services.Communication;

namespace FreePlace.API.Shared.Domain.Services.Communication;

public class UserResponse: BaseResponse<User>
{
    public UserResponse(string message) : base(message) {}
    public UserResponse(User resource) : base(resource) {}
}