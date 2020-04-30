namespace Pizza.Api.Models.SaveModel
{
    public class SaveCommandLinesModel
    {
        public int? Num_Cde_Cli { get; set; }
        public int Num_Pizza { get; set; }
        public string Quantité { get; set; }

        public PizzaViewModel Pizza { get; set; }

        public int? MontantTotal => int.Parse(Quantité) * Pizza?.Prix_Pizza;

        public string MontantTotalPizza => $"{int.Parse(Quantité) * Pizza?.Prix_Pizza}€";
    }
}
