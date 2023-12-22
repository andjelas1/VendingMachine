namespace VendingMachine
{
    internal class Automat
    {
        private bool _zakljucan;
        private Queue<Artikal>[,] _artikli = new Queue<Artikal>[6, 6];
        public Kasa MojaKasa = new Kasa();
        public bool Zakljucan
        {
            get { return _zakljucan; }
            set { _zakljucan = value; }
        }

        public Automat()
        {
            this._zakljucan=true;
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    _artikli[i, j] = new Queue<Artikal>();
                }
            }
        }

        public void ZakljucajOtkljucaj()
        {
            this.Zakljucan = !this.Zakljucan;
        }

        public void DodajArtikle(Artikal a, int kolicina, int red, int kolona)
        {
            for (int i = 0; i < kolicina; i++)
            {
                _artikli[red, kolona].Enqueue(a);
            }
        }
        public int StanjePozicije(int red, int kolona)
        {
            return _artikli[red, kolona].Count();
        }
        public int StanjeArtikala()
        {
            int stanje = 0;
            for(int i = 0; i < 6; i++)
            {
                for(int j=0; j< 6; j++)
                {
                    stanje += _artikli[i, j].Count();
                }
            }
            return stanje;
        }
        public Artikal VratiSledeciArtikal(int red, int kolona)
        {
            return _artikli[red, kolona].Peek();
        }
        public Artikal IsporuciArtikal(int red, int kolona)
        {
            Artikal a = _artikli[red, kolona].Dequeue();
            MojaKasa.SetKredit(a.Cena);
            return a;
        }
    }
}
