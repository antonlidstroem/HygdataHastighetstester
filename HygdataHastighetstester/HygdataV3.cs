using System;
using System.Collections.Generic;

namespace HygdataHastighetstester;

public partial class HygdataV3
{
    public int Id { get; set; }

    public int? Hip { get; set; }

    public string? Hd { get; set; }

    public string? Hr { get; set; }

    public string? Gl { get; set; }

    public string? Bf { get; set; }

    public string? Proper { get; set; }

    public string Ra { get; set; } = null!;

    public string Dec { get; set; } = null!;

    public string Dist { get; set; } = null!;

    public string Pmra { get; set; } = null!;

    public string Pmdec { get; set; } = null!;

    public string Rv { get; set; } = null!;

    public string Mag { get; set; } = null!;

    public string Absmag { get; set; } = null!;

    public string? Spect { get; set; }

    public string? Ci { get; set; }

    public string X { get; set; } = null!;

    public string Y { get; set; } = null!;

    public string Z { get; set; } = null!;

    public string Vx { get; set; } = null!;

    public string Vy { get; set; } = null!;

    public string Vz { get; set; } = null!;

    public string Rarad { get; set; } = null!;

    public string Decrad { get; set; } = null!;

    public string Pmrarad { get; set; } = null!;

    public string Pmdecrad { get; set; } = null!;

    public string? Bayer { get; set; }

    public string? Flam { get; set; }

    public string? Con { get; set; }

    public int Comp { get; set; }

    public int CompPrimary { get; set; }

    public string? Base { get; set; }

    public string Lum { get; set; } = null!;

    public string? Var { get; set; }

    public string? VarMin { get; set; }

    public string? VarMax { get; set; }
}
