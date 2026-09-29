using System;
using System.Collections.Generic;

namespace Apispnet.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string UsernameHash { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }
}
