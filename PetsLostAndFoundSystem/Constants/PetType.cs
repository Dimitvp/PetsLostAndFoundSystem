using System;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Constants
{
    [Flags]
    public enum PetType
    {
        [Display(Name = "Small Breed Dog")]
        SmallBreedDog = 1,
        [Display(Name = "All Dogs")]
        AllDogs = 2,
        [Display(Name = "Cats")]
        Cat = 4,
        [Display(Name = "Other Type")]
        OtherType = 8
    }
}
