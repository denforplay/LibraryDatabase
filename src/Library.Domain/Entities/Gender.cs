﻿using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("GenderType")]
    public class Gender : EntityBase<int>
    {
        string Name { get; set; }
    }
}
