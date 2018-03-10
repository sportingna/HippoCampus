using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HippoCampus.Enum
{
    public class Enum
    {
    }

    public enum YesOrNo
    {
        Yes,
        No
    }
    public enum Level
    {
        [Display (Name = "On Campus")] High,
        [Display(Name = "Off Campus")] Mid,
        [Display(Name = "Recommended/Optional")] Low
    }
    public enum Gender
    {
        Male,
        Female,
        NA
    }
}