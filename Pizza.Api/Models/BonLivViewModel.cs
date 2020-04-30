using System;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Api.Models
{
    public class BonLivViewModel
    {
        public CommandViewModel CdeCli { get; set; }
        public FacturationViewModel Facturation { get; set; }
        [Display(Name = "Date livraison")]
        public DateTime Date_Liv { get; set; }
    }
}
