using System;
using System.Linq;
using lab8ex1.Exceptions;


namespace lab8ex1
{
    public class Pos : IPlatestePos
    {
        private Banca banca = null;

        public Pos( Banca banca) 
        {
            this.banca = banca;
          
        }

        /// <summary>
        /// plata la POS
        /// introdu card
        /// get card data
        /// va incerca sa efectueze plata in banca
        /// </summary>
        /// <param name="suma"></param>
        /// <param name="card"></param>
        public void PlatestePos(double suma, Card card)
        {
            try
            {
                card.IntroduCard();
                Console.WriteLine($"POS: cardul {card.ToString()} a fost introdus");
                banca.Plateste(suma, card.ToString());

            }
            /* -- eroare ca nu exista in c#8
            catch(Exception ex)
            {
                switch (ex)
                {
                    case ContInexistentException:
                        Console.WriteLine("Cont Inexistent");
                        break;
                    case SoldInsuficientException:
                        Console.WriteLine("Sold Insuficient");
                        break;
                }
            }
            */
            catch (CardInexistentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ContInexistentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (SoldInsuficientException ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                card.ExtrageCard();
            }
        }
    }
}
