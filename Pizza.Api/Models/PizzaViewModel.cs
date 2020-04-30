namespace Pizza.Api.Models
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Nom_Pizza { get; set; }
        /// <summary>
        /// 0 - Medium / 1 - Large 
        /// </summary>
        public bool Taille_Pizza { get; set; }
        public int Prix_Pizza { get; set; }

        public string Taille => Taille_Pizza ? "Large" : "Medium";
        public string PizzaToDiplay => $"{Nom_Pizza} - {Prix_Pizza}€ - " + Taille;
    }
}
