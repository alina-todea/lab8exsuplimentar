using System;
using System.Collections.Generic;
using System.Text;

namespace lab8ex1
{
    public class Cont: IDepuneNumerar, iExtrageNumerar, IAtaseazaCard
    {
        public double Sold { get; set; } = 0;
        public string Nume { get; set; } = "";
       
        
        public Guid Id { get; set; }
        public List<Card> ListaCarduri { get; set; }


        public Cont(string nume)
        {
            this.Nume = nume;
            this.Id = Guid.NewGuid();
            ListaCarduri=new List<Card>();
        }

        /// <summary>
        /// depunere numerar in cont
        /// </summary>
        /// <param name="suma"></param>
        public void DepunereNumerar(double suma)
        {
            try
            {
                if (suma > 0)
                {
                    this.Sold += suma;
                }
                else
                {
                    throw new SumaInvalidaException("Suma invalida");
                }
            }

            catch (SumaInvalidaException e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// extragere numerar din cont
        /// Va avea ca parametru suma ce se doreste a fi extrasa
        ///     In cazul in care suma nu este disponibila, contul bancar va arunca o exceptie
        ///     Va fi folosita la de Banca atunci cand vor fi efectuate plati
        /// </summary>
        /// <param name="suma"></param>
        public void ExtrageNumerar(double suma)
        {
            try
            {
                if (suma <= 0)
                {
                    throw new SumaInvalidaException("Suma invalida");
                }

                else if (Sold >= suma)
                {
                    this.Sold -= suma;

                }
                else
                    throw new SoldInsuficientException("Sold insuficient");
            }

            catch (SumaInvalidaException e)
            {
                Console.WriteLine(e);
            }
            catch (SoldInsuficientException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// adauga un card in lista de carduri a contului
        /// </summary>
        /// <param name="card"></param>
        public void AtaseazaCard(Card card)
        {
            try
            {
                

                if (!ListaCarduri.Contains(card))
                {
                    
                    ListaCarduri.Add(card);
                   
                    
                }
                
            }


            catch
            {
            }
        }
        /// <summary>
        /// returneaza Id-ul contului
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            string contId = $"{Id}";

            {
                StringBuilder descriere = new StringBuilder();

                descriere.Append($"{contId}");

                return descriere.ToString();
            }
        }


    }
}
