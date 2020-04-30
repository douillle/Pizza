using System;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Api.Models
{
    public class FacturationViewModel
    {
        [Display(Name = "Date facturation")]
        public DateTime Date_Fact_Cli { get; set; }
        [Display(Name = "Montant total")]
        public int Montant_Total { get; set; }

        public string Montant => $"{Montant_Total} €";

        public ClientViewModel Client { get; set; }
    }
}
