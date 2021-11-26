using System;
using System.ComponentModel.DataAnnotations;
using HK.BL.Domain;
using HK.DAL;

namespace HK.UI.CA
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repo = new Repository();
            Program program = new Program(repo);
            program.Run();
        }

        private bool _quit = false;
        private readonly IRepository _repo;

        public Program(IRepository repo)
        {
            _repo = repo;
        }
        
        void Run()
        {
            while (!_quit)
                ShowMenu();
        }

        private void ShowMenu()
        {
            Console.WriteLine("===================");
            Console.WriteLine("===    Hotels   ===");
            Console.WriteLine("===================");
            Console.WriteLine(" 1) Toon alle hotels");
            Console.WriteLine(" 2) Toon hoeveelheid hotels in de db");
            Console.WriteLine(" 3) Toon hotel adhv id");
            Console.WriteLine(" 4) Toon hotel adhv exacte naam");
            Console.WriteLine(" 5) Toon hotel met de grootste capaciteit");
            Console.WriteLine(" 6) Toon alle hotels die een restaurant hebben");
            Console.WriteLine(" 7) Toon alle hotels van een bepaald type");
            Console.WriteLine(" 8) Toon alle hotels uit een bepaald jaar");
            Console.WriteLine(" 9) Toon alle hotels in een bepaalde postcode");
            Console.WriteLine("10) Toon alle hotels met een bepaalde letter/woord");
            Console.WriteLine("11) Voeg een hotel toe");
            Console.WriteLine("12) Wijzig een hotelprijs");
            Console.WriteLine("13) Verwijder een hotel");
            Console.WriteLine(" 0) Afsluiten");
            DetectMenuAction();
        }

        private void DetectMenuAction()
        {
            try
            {
                bool inValidAction;
                do
                {
                    inValidAction = false;
                    Console.Write("Keuze: ");
                    string input = Console.ReadLine();
                    int action;
                    if (Int32.TryParse(input, out action))
                    {
                        switch (action)
                        {
                            case 0:
                                _quit = true;
                                break;
                            case 1:
                                ShowAllHotelsMenuAction();
                                break;
                            case 2:
                                ShowCountHotelsMenuAction();
                                break;
                            case 3:
                                ShowHotelByIdMenuAction();
                                break;
                            case 4:
                                ShowHotelByNameMenuAction();
                                break;
                            case 5:
                                ShowHotelsWithMaxCapacityMenuAction();
                                break;
                            case 6:
                                ShowHotelsWithARestaurantMenuAction();
                                break;
                            case 7:
                                ShowHotelsOfTypeMenuAction();
                                break;
                            case 8:
                                ShowHotelsOfAYearMenuAction();
                                break;
                            case 9:
                                ShowHotelsWithZipCodeMenuAction();
                                break;
                            case 10:
                                ShowHotelsWithLetterOrWordMenuAction();
                                break;
                            case 11:
                                ShowAddHotelMenuAction();
                                break;
                            case 12:
                                ShowChangePriceOfHotelMenuAction();
                                break;
                            case 13:
                                ShowRemoveHotelMenuAction();
                                break;
                            default:
                                Console.WriteLine("Ongeldige keuze!");
                                inValidAction = true;
                                break;
                        }
                    }
                } while (inValidAction);
            }
            catch (NotImplementedException nie)
            {
                Console.WriteLine("NotImplemented: " + nie.Message);
            }
            catch (ValidationException ve)
            {
                Console.WriteLine("Validation: " + ve.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ShowAllHotelsMenuAction() //optie 1 alle hotels
        {
            foreach (var hotel in _repo.ReadAllHotels())
            {
                Console.WriteLine(hotel.AllInfo());
            }
        }

        private void ShowCountHotelsMenuAction() //optie 2 tel hotels
        {
            int nbrOfHotels = _repo.CountAllHotels();
            Console.WriteLine("{0} hotels gevonden", nbrOfHotels);
        }

        private void ShowHotelByIdMenuAction() //optie 3 toon hotel met specifiek 'id'
        {
            Console.Write("Geef een 'id' in: ");
            int id = Int32.Parse(Console.ReadLine());

            Hotel hotel = _repo.ReadHotel(id);
            if (hotel != null)
            {
                Console.WriteLine(hotel.AllInfo());
            }
            else
                Console.WriteLine("Geen hotel gevonden met het opgegeven 'id' !!");
        }

        private void ShowHotelByNameMenuAction() //optie 4 toon hotel met specifieke naam
        {
            Console.Write("Geef de (volledige) naam in: ");
            string name = Console.ReadLine();

            Hotel hotel = _repo.ReadHotel(name);
            if (hotel != null)
            {
                Console.WriteLine(hotel.AllInfo());
            }
            else
                Console.WriteLine("Geen hotel gevonden met de opgegeven naam !!");
        }

        private void ShowHotelsWithMaxCapacityMenuAction() //optie 5 toon hotel met grootste capaciteit
        {
            Hotel hotel = _repo.ReadHotelWithMaxCapacity();
            if (hotel != null)
            {
                Console.WriteLine(hotel.AllInfo());
            }
            else
                Console.WriteLine("Geen hotel gevonden met een capaciteit aanduiding !!");
        }

        private void ShowHotelsWithARestaurantMenuAction() //optie 6 alle hotels met een restaurant
        {
            foreach (var hotel in _repo.ReadHotelsWithRestaurant())
            {
                Console.WriteLine(hotel.ShortInfo());
            }
        }

        private void ShowHotelsOfTypeMenuAction() //optie 7 alle hotels van bepaald type
        {
            foreach (var item in Enum.GetValues(typeof(HotelType)))
            {
                Console.WriteLine("{0:d}: {0}", item);
            }

            Console.Write("Kies een hotel-type uit bovenstaande lijst: ");
            byte type = Byte.Parse(Console.ReadLine());

            if (Enum.IsDefined(typeof(HotelType), type))
            {
                var hotels = _repo.ReadHotelsOfType((HotelType) type);
                foreach (var hotel in hotels)
                {
                    Console.WriteLine(hotel.ShortInfo());
                }
            }
            else
                Console.WriteLine("Ongeldige keuze van hoteltype");
        }

        private void ShowHotelsOfAYearMenuAction() //optie 8 alle hotels uit bepaald stichtingsjaar
        {
            Console.Write("Geef het inschrijvingsJAAR in: ");
            int input = Int32.Parse(Console.ReadLine());

            var hotels = _repo.ReadHotelsOfAYear(input);
            foreach (var hotel in hotels)
            {
                Console.WriteLine(hotel.ShortInfo());
            }
        }

        private void ShowHotelsWithZipCodeMenuAction() //optie 9 alle hotels uit bepaald postcode
        {
            Console.Write("Geef de postcode in: ");
            string input = Console.ReadLine();

            var hotels = _repo.ReadHotelsOfZipCode(input);
            foreach (var hotel in hotels)
            {
                Console.WriteLine(hotel.ShortInfo());
            }
        }

        private void ShowHotelsWithLetterOrWordMenuAction() //optie 10 alle hotels met bepaalde letters
        {
            Console.Write("Geef de letter/woord in, die in de hotelnaam moet voorkomen: ");
            string input = Console.ReadLine();

            var hotels = _repo.ReadHotelsWithLetterOrWord(input);
            foreach (var hotel in hotels)
            {
                Console.WriteLine(hotel.ShortInfo());
            }
        }

        private void ShowAddHotelMenuAction() //optie 11 voeg hotel toe
        {
            //Naam
            Console.Write("Naam nieuw hotel: ");
            string name = Console.ReadLine();
            //HotelType (adhv overzicht van alle types)
            Console.Write("Geef HotelType aan - mogelijke waarden zijn: " + Environment.NewLine);
            foreach (var item in Enum.GetValues(typeof(HotelType)))
            {
                Console.WriteLine("{0:d} ({0})", item);
            }

            Console.Write("HotelType: ");
            HotelType hotelType = (HotelType) Byte.Parse(Console.ReadLine());
            //FoundationDate
            Console.Write("Oprichtingsdatum: ");
            string dateInput = Console.ReadLine();
            DateTime? hotelDateTime = null;
            if (!String.IsNullOrEmpty(dateInput)) hotelDateTime = DateTime.Parse(dateInput);
            //Land
            Console.Write("Land (bv. 'BE' voor belgium): ");
            string country = Console.ReadLine();
            //Zipcode
            Console.Write("Postcode: ");
            string zipCode = Console.ReadLine();
            //Restaurant of niet
            Console.Write("Restaurant aanwezig (j/n): ");
            bool hasRestaurant = Console.ReadLine().ToLower().Equals("j");
            //Prijs
            Console.Write("Standaard/Gemiddelde prijs: ");
            double price = Double.Parse(Console.ReadLine());
            //Capaciteit
            Console.Write("Capaciteit: ");
            int capacity = Int32.Parse(Console.ReadLine());

            Hotel h = new Hotel()
            {
                Name = name,
                Type = hotelType,
                FoundingDate = hotelDateTime,
                Country = country,
                ZipCode = zipCode,
                HasRestaurant = hasRestaurant,
                Price = price,
                Capacity = capacity
            };
            _repo.CreateHotel(h);
            Console.WriteLine("Hotel toegevoegd");
        }

        private void ShowChangePriceOfHotelMenuAction() //optie 12 wijzig prijs hotel
        {
            Console.Write("Van welk hotel (PK) wenst u de prijs te wijzigen? ");
            int hotelId = Int32.Parse(Console.ReadLine());

            Hotel h1 = _repo.ReadHotel(hotelId);
            if (h1 == null)
                Console.WriteLine("Het gevraagde hotel kon niet worden gevonden !!!");
            else
            {
                Console.Write("Geef de nieuwe prijs in: ");
                double newPrice = Double.Parse(Console.ReadLine());

                _repo.UpdateHotel(hotelId, newPrice);
                Console.WriteLine("Hotelprijs werd aangepast");
            }
        }

        private void ShowRemoveHotelMenuAction() //optie 13 verwijder een hotel
        {
            Console.Write("Geef de naam van het hotel dat u wenst te verwijderen? ");
            string hotelName = Console.ReadLine();

            Hotel h1 = _repo.ReadHotel(hotelName);
            if (h1 != null)
            {
                Console.WriteLine(h1.AllInfo());
                Console.Write("Bent u zeker dat u dit hotel wenst te verwijderen (j/n): ");
                if (Console.ReadLine().ToLower().Equals("j"))
                {
                    _repo.DeleteHotel(h1);
                    Console.WriteLine("Hotel verwijderd !");
                }
            }
            else
                Console.WriteLine("Geen hotel met deze naam bekend !");
        }
    }
}