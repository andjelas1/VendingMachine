using Microsoft.VisualBasic;

namespace VendingMachine
{
    internal class Artikal
    {
        #region Atributi
        private static int _nextID = 0;
        private static int NextID 
        { get 
            {
                _nextID++;
                return _nextID;
            } 
        }

        private int _id;
        private string _naziv = String.Empty;
        private DateTime _rokTrajanja;
        private decimal _cena;
        private DateTime _danPopusta;
        private decimal _procenatPopusta;
        public int ID
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        public DateTime RokTrajanja
        {
            get { return _rokTrajanja; }
            set { _rokTrajanja = value; }
        }
        public decimal Cena
        {
            get
            {
                if (DanpoPusta.Equals(DateTime.Now) || (RokTrajanja.Date - DateTime.Now.Date).Days <=3)
                    return _cena - _cena * (ProcenatPopusta/100);
                else
                    return _cena;
            }
            set { _cena = value; }
        }
        public DateTime DanpoPusta
        {
            set { _danPopusta = value; }
            get { return _danPopusta; }
        }
        public decimal ProcenatPopusta
        {
            get { return _procenatPopusta; }
            set { _procenatPopusta = value; }
        }
        #endregion

        private Artikal() { }
        public Artikal(string _naziv, string _rokTrajanja, decimal _cena, string _danPopusta, decimal _procenatPopusta)
        {
            ID = NextID;
            Naziv = _naziv;
            RokTrajanja = DateTime.Parse( _rokTrajanja);
            Cena = _cena;
            DanpoPusta = DateTime.Parse(_danPopusta);
            ProcenatPopusta = _procenatPopusta;
        }

        public void PrikaziMe()
        {
            Console.WriteLine($"{Naziv}, CENA:{ Math.Round(Cena, 2)} RSD");
        }
    }
}
