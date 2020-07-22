using System;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Data.Enums
{
    [Flags]
    public enum PetType
    {
        Dog,
        Cat,
        Bird,
        Reptilian,
        [Display(Name = "Other Type")]
        OtherType = 8
    }
}
