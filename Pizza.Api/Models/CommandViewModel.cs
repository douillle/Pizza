using System;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Api.Models
{
    public class CommandViewModel
    {
        public int Id { get; set; }
        [Display(Name = "En livraison ou à emporter")]
        /// <summary>
        /// 0 - Livré / 1 - A emporter
        /// </summary>
        public bool Livre_Emporte { get; set; }
        [Display(Name = "Date de la commande")]
        public DateTime Date_Cde { get; set; }
        public ClientViewModel Client { get; set; }

        public string LivreouEmporter => Livre_Emporte ? "À emporter" : "À livrer";
    }
}
