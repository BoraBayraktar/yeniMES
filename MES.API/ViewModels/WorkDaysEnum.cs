using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.ViewModels
{
    public enum WorkDaysEnum
    {
        [Description("Pazar")]
        Pazar = 0,
        [Description("Pazartesi")]
        Pazartesi,
        [Description("Salı")]
        Sali,
        [Description("Çarşamba")]
        Carsamba,
        [Description("Perşembe")]
        Perşembe,
        [Description("Cuma")]
        Cuma,
        [Description("Cumartesi")]
        Cumartesi
    }
}
