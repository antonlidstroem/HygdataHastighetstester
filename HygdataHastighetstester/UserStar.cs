using System;
using System.Collections.Generic;

namespace HygdataHastighetstester;

public partial class UserStar
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int StarId { get; set; }

    public virtual HygdataV3 Star { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
