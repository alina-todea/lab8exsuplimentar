using System;
using System.Collections.Generic;
using System.Linq;
using lab8ex1.Exceptions;

namespace lab8ex1
{
    public class Banca : IPlateste, ICreazaCont, IEmiteCard, IGetCont

    {
        public List<Cont> ListaConturi { get; set; }
        public List<Card> ListaCarduri { get; set; }
        Dictionary< string, string> Dictionar { get; set; }
        public Cont Cont { get; set; }


        //var dictionary = new Dictionary<string, string>();
        //var dictionary = new Dictionary<string, string>();
        //dictionar.Add("CompanyId", "471413bf-a831-4e4a-bc3f-16492254d1b5");
        // string id = dictionary["CompanyId"];

        public Banca()
        {
            ListaCarduri = new List<Card>();
            ListaConturi = new List<Cont>();
            Dictionar = new Dictionary<string, string>();
        }

        /// <summary>
        /// creaza cont
        /// Va creea un nou cont bancar
        ///   Il va adauga in lista conturilor
        ///   Va returna id-ul contului
        /// </summary>
        public string CreazaCont(string nume)
        {
            var cont = new Cont(nume);

            if (!ListaConturi.Contains(cont))
            {
                ListaConturi.Add(cont);

            }
            return cont.ToString();
        }

        /// <summary>
        ///   emite card
        ///     In cazul in care contul nu exista va arunca o exceptie corespunzatoare
        ///        • In cazul in care au fost emise deja 2 carduri pentru acel cont va arunca o exceptie.
        ///        • Cardul emis va primi id-ul contului.
        /// </summary>
        /// <param name="cont"></param>
        public string EmiteCard(Cont cont)
        {
            try
            {
                if (cont.ListaCarduri.Count < 2)
                {
                    //var card = new Card(cont.ToString(), cont);
                    var card = new Card(cont);

                    cont.AtaseazaCard(card);
                    ListaCarduri.Add(card);

                    if (!Dictionar.ContainsKey(card.ToString()))
                    {
                        Dictionar.Add(card.ToString(), cont.ToString());
                    }
                    return $"cardul {card.GetCardData()} a fost atasat la contul {cont.ToString()}";
                }
                else
                {
                    throw new TooManyCardsException("Contul are deja 2 carduri");

                }

            }

            catch (TooManyCardsException e)
            {
                Console.WriteLine(e);
            }
            return "succes";
        }


        /// <summary>
        /// returneaza contul pe baza card Id
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public Cont GetCont(string cardId)
        {
            try
            {
                var findCard = ListaCarduri.FirstOrDefault(x => x.ToString() == cardId);
                if (findCard != null)

                {
                    var contId = Dictionar[cardId];

                    var findCont = ListaConturi.FirstOrDefault(x => x.ToString() == contId);

                    if (findCont != null)
                    {

                        return findCont;
                     }

                    else
                    {
                        throw new ContInexistentException("Cont inexistent");
                    }
                }
                else
                {
                    throw new CardInexistentException("Card Inexistent");
                }
            }
              
            catch
            {
                throw;
            }

        }




        /// <summary>
        /// plateste suma din cont
        /// • In cazul in care contul nu exista va arunca o exceptie corespunzatoare
        /// </summary>
        public void Plateste(double suma, string cardId)
        {
            try
            {
                Cont findCont = GetCont(cardId);

                if (findCont != null)
                {

                    if (findCont.Sold >= suma)
                    {
                        findCont.Sold -= suma;
                    }
                    else
                    {
                        throw new SoldInsuficientException("Sold insuficient");
                    }
                }
                else
                {
                    throw new CardsauContInexistentException("eroare cont sau card inexistent");
                }
          
            }
            catch (CardsauContInexistentException ex)
            {
                //throw;
                Console.WriteLine(ex);
            }

            catch //(SoldInsuficientException ex)
            {
                throw;
            }
        }
    }

}
