using System;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Reporters.Constants
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
