﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models;

public partial class TipiScadenzePersone
{
    public long Id { get; set; }

    public string Descrizione { get; set; }

    public virtual ICollection<ScadenzePersone> ScadenzePersone { get; } = new List<ScadenzePersone>();
}