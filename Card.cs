using System;
using System.Text;

namespace lab8ex1
{
    public class Card
    {
        public string CardNr { get; set; } = string.Empty;
        public Cont Cont { get; set; }
        public Guid Id { get; set; }



       /* public Card(string cardNr, Cont cont)
        {
            this.CardNr = cardNr;
            this.Cont = cont;
            this.Id = Guid.NewGuid();
        }*/

        public Card(Cont cont)
        {
            //this.CardNr = cardNr;
            this.Cont = cont;
            this.Id = Guid.NewGuid();
        }

        public void IntroduCard()
        {
            Console.WriteLine("cardul a fost introdus.");
        }
       
        public void ExtrageCard()
        {
            Console.WriteLine("cardul a fost extras.");
        }

       /* public override string ToString()
        {

            string contId = $"{CardNr}";

            {
                StringBuilder descriere = new StringBuilder();

                descriere.Append($"{CardNr}");

                return descriere.ToString();
            }
        }*/

        public override string ToString()
        {

            string contId = $"{Id}";

            {
                StringBuilder descriere = new StringBuilder();

                descriere.Append($"{Id}");

                return descriere.ToString();
            }
        }

        public  string GetCardData()
        {

            string contId = $"{Id}";

            {
                StringBuilder descriere = new StringBuilder();

                descriere.Append($"{Id}");

                return descriere.ToString();
            }
        }

        }
}
