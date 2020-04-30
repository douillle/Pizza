using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Api.Models.SaveModel
{
    public class SaveCommandModel
    {
        [Display(Name = "Livraison ou à emporter")]
        /// <summary>
        /// 0 - Livré / 1 - A emporter
        /// </summary>
        public bool Livre_Emporte { get; set; }
        [Display(Name = "Date de la commande")]
        public DateTime Date_Cde { get; set; }
        public int Num_Cli { get; set; }

        [Display(Name = "Votre nom")]
        public SaveClientModel Client { get; set; }

        public int Num_Pizza { get; set; }
        public int Qte_Pizza { get; set; }
        public ICollection<SaveCommandLinesModel> Ligne_Commandes { get; set; }
    }
}
