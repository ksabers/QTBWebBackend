﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models;

public partial class TipiManutenzioni
{
    public long Id { get; set; }

    public string Descrizione { get; set; }

    public virtual ICollection<Manutenzioni> Manutenzioni { get; } = new List<Manutenzioni>();
}