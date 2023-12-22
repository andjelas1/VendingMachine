namespace VendingMachine
{
    public partial class Form1 : Form
    {
        internal Automat VendingMachine;
        private TextBox[,] stanjePozicijaVisual = new TextBox[6,6];
        private Button[,] pozicijeVisual = new Button[6, 6];

        private int red;
        private int kolona;
        public Form1()
        {
            InitializeComponent();
            InicijalizujAutomat();
        }

        private void InicijalizujAutomat()
        {
            VendingMachine = new Automat();

            InicijalizujStanjePozicijaVisual();
            InicijalizujPozicijeVisual();
            OsveziEkran();
        }
        private void InicijalizujStanjePozicijaVisual()
        {
            pozicijeVisual[0, 0] = p11;
            pozicijeVisual[0, 1] = p12;
            pozicijeVisual[0, 2] = p13;
            pozicijeVisual[0, 3] = p14;
            pozicijeVisual[0, 4] = p15;
            pozicijeVisual[0, 5] = p16;

            pozicijeVisual[1, 0] = p21;
            pozicijeVisual[1, 1] = p22;
            pozicijeVisual[1, 2] = p23;
            pozicijeVisual[1, 3] = p24;
            pozicijeVisual[1, 4] = p25;
            pozicijeVisual[1, 5] = p26;

            pozicijeVisual[2, 0] = p31;
            pozicijeVisual[2, 1] = p32;
            pozicijeVisual[2, 2] = p33;
            pozicijeVisual[2, 3] = p34;
            pozicijeVisual[2, 4] = p35;
            pozicijeVisual[2, 5] = p36;

            pozicijeVisual[3, 0] = p41;
            pozicijeVisual[3, 1] = p42;
            pozicijeVisual[3, 2] = p43;
            pozicijeVisual[3, 3] = p44;
            pozicijeVisual[3, 4] = p45;
            pozicijeVisual[3, 5] = p46;

            pozicijeVisual[4, 0] = p51;
            pozicijeVisual[4, 1] = p52;
            pozicijeVisual[4, 2] = p53;
            pozicijeVisual[4, 3] = p54;
            pozicijeVisual[4, 4] = p55;
            pozicijeVisual[4, 5] = p56;

            pozicijeVisual[5, 0] = p61;
            pozicijeVisual[5, 1] = p62;
            pozicijeVisual[5, 2] = p63;
            pozicijeVisual[5, 3] = p64;
            pozicijeVisual[5, 4] = p65;
            pozicijeVisual[5, 5] = p66;
        }
        private void InicijalizujPozicijeVisual()
        {
            stanjePozicijaVisual[0, 0] = s11;
            stanjePozicijaVisual[0, 1] = s12;
            stanjePozicijaVisual[0, 2] = s13;
            stanjePozicijaVisual[0, 3] = s14;
            stanjePozicijaVisual[0, 4] = s15;
            stanjePozicijaVisual[0, 5] = s16;

            stanjePozicijaVisual[1, 0] = s21;
            stanjePozicijaVisual[1, 1] = s22;
            stanjePozicijaVisual[1, 2] = s23;
            stanjePozicijaVisual[1, 3] = s24;
            stanjePozicijaVisual[1, 4] = s25;
            stanjePozicijaVisual[1, 5] = s26;

            stanjePozicijaVisual[2, 0] = s31;
            stanjePozicijaVisual[2, 1] = s32;
            stanjePozicijaVisual[2, 2] = s33;
            stanjePozicijaVisual[2, 3] = s34;
            stanjePozicijaVisual[2, 4] = s35;
            stanjePozicijaVisual[2, 5] = s36;

            stanjePozicijaVisual[3, 0] = s41;
            stanjePozicijaVisual[3, 1] = s42;
            stanjePozicijaVisual[3, 2] = s43;
            stanjePozicijaVisual[3, 3] = s44;
            stanjePozicijaVisual[3, 4] = s45;
            stanjePozicijaVisual[3, 5] = s46;

            stanjePozicijaVisual[4, 0] = s51;
            stanjePozicijaVisual[4, 1] = s52;
            stanjePozicijaVisual[4, 2] = s53;
            stanjePozicijaVisual[4, 3] = s54;
            stanjePozicijaVisual[4, 4] = s55;
            stanjePozicijaVisual[4, 5] = s56;

            stanjePozicijaVisual[5, 0] = s61;
            stanjePozicijaVisual[5, 1] = s62;
            stanjePozicijaVisual[5, 2] = s63;
            stanjePozicijaVisual[5, 3] = s64;
            stanjePozicijaVisual[5, 4] = s65;
            stanjePozicijaVisual[5, 5] = s66;
        }
        private void OsveziEkran()
        {
            for (int i = 0; i < stanjePozicijaVisual.GetLength(0); i++)
            {
                for (int j = 0; j < stanjePozicijaVisual.GetLength(1); j++)
                {
                    stanjePozicijaVisual[i, j].Text = VendingMachine.StanjePozicije(i, j).ToString();
                }
            }

            for (int i = 0; i < pozicijeVisual.GetLength(0); i++)
            {
                for (int j = 0; j < pozicijeVisual.GetLength(1); j++)
                {
                    pozicijeVisual[i, j].Text = VendingMachine.StanjePozicije(i, j) == 0 ? "Empty" : $"{VendingMachine.VratiSledeciArtikal(i, j).Naziv} ({Math.Round(VendingMachine.VratiSledeciArtikal(i, j).Cena , 2).ToString("N2")} rsd)";
                }
            }

            infoPozicije.Text = "";
            kolicina.Text = "";
            naziv.Text = "";
            cena.Text = "";
            rok.Text = "";
            popustNaDan.Text = "";
            procenatPopusta.Text = "";

            kredit.Text = VendingMachine.MojaKasa.GetKreadit().ToString();

            stanjeKase.Text = VendingMachine.MojaKasa.GetStanjeKase().ToString();

        }
        private void kljuc_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < stanjePozicijaVisual.GetLength(0); i++)
            {
                for (int j = 0; j < stanjePozicijaVisual.GetLength(1); j++)
                {
                    stanjePozicijaVisual[i, j].Enabled = VendingMachine.Zakljucan;
                }
            }

            for (int i = 0; i < pozicijeVisual.GetLength(0); i++)
            {
                for (int j = 0; j < pozicijeVisual.GetLength(1); j++)
                {
                    pozicijeVisual[i, j].Enabled = !VendingMachine.Zakljucan;
                }
            }

            kolicina.Enabled = VendingMachine.Zakljucan;
            naziv.Enabled = VendingMachine.Zakljucan;
            cena.Enabled = VendingMachine.Zakljucan;
            rok.Enabled = VendingMachine.Zakljucan;
            popustNaDan.Enabled = VendingMachine.Zakljucan;
            procenatPopusta.Enabled = VendingMachine.Zakljucan;

            ubaciArtikal.Enabled = VendingMachine.Zakljucan;
            napuniAutomat.Enabled = VendingMachine.Zakljucan;

            novcanica1.Enabled = !VendingMachine.Zakljucan;
            novcanica2.Enabled = !VendingMachine.Zakljucan;
            novcanica5.Enabled = !VendingMachine.Zakljucan;
            novcanica10.Enabled = !VendingMachine.Zakljucan;
            novcanica20.Enabled = !VendingMachine.Zakljucan;
            novcanica50.Enabled = !VendingMachine.Zakljucan;
            novcanica100.Enabled = !VendingMachine.Zakljucan;
            novcanica200.Enabled = !VendingMachine.Zakljucan;
            ubacenaNovcanica.Enabled = VendingMachine.Zakljucan;
            ubaciNovcanicu.Enabled = VendingMachine.Zakljucan;
            ispraznikasu.Enabled = VendingMachine.Zakljucan;

            ubacenaNovcanica.Text = "";

            VendingMachine.ZakljucajOtkljucaj();
            if (VendingMachine.Zakljucan)
                kljuc.Text = "Otkljucaj";
            else
                kljuc.Text = "Zakljucaj";
        }
        private void stanjePozicijaVisual_MouseDown(object sender, MouseEventArgs e)
        {
            string _name = ((TextBox)sender).Name;
            this.ParsePozicija(_name);
            this.infoPozicije.Text = $"Uredite poziciju [{red+1}, {kolona+1}]";
        }
        private void pozicijaArtikal_Click(object sender, EventArgs e)
        {
            string _name = ((Button)sender).Name;
            this.ParsePozicija(_name);

            if (VendingMachine.StanjePozicije(red, kolona) == 0)
                return;
            if(VendingMachine.MojaKasa.GetKreadit() < VendingMachine.VratiSledeciArtikal(red, kolona).Cena)
            {
                MessageBox.Show("Nemate dovoljno kredita za ovaj artikal. Ubacite jos novca");
                return;
            }
            Prodaj();
        }

        private void Prodaj()
        {
            Artikal a=  VendingMachine.IsporuciArtikal(red, kolona);
            if (!string.IsNullOrWhiteSpace(isporuceno.Text))
                this.isporuceno.AppendText($"\n {a.Naziv} po ceni {a.Cena.ToString("N2")}");
            else
                this.isporuceno.AppendText($"{a.Naziv} po ceni {Math.Round(a.Cena,2).ToString("N2")}");
            this.OsveziEkran();
        }

        private void ParsePozicija(string name)
        {
            red = Convert.ToInt32(name[1].ToString()) - 1;
            kolona = Convert.ToInt32(name[2].ToString()) - 1;
        }
        private int ParseVrednostNovcanice(string name)
        {
            return Convert.ToInt32(name);
        }
        private void ubaciArtikal_Click(object sender, EventArgs e)
        {
            if ((red >= 0 && red < 6) && (kolona >= 0 && kolona < 6) &&
               naziv.Text != "" && rok.Text != "" && cena.Text != "" && popustNaDan.Text != "" && procenatPopusta.Text != "" && kolicina.Text != "")
            {
                Artikal a = new Artikal(naziv.Text, rok.Text, Convert.ToDecimal(cena.Text), popustNaDan.Text, Convert.ToDecimal(procenatPopusta.Text));

                VendingMachine.DodajArtikle(a, Convert.ToInt32(kolicina.Text), red, kolona);

                this.OsveziEkran();
            }
            else
                MessageBox.Show("Nisu popunjene sve stavke!");

        }
        private void napuniAutomat_Click(object sender, EventArgs e)
        {
            Artikal a1 = new Artikal("cips", "2023-01-25", 15, "2023-01-24", 10);
            VendingMachine.DodajArtikle(a1, 1, 0, 0);
            VendingMachine.DodajArtikle(a1, 1, 0, 1);
            VendingMachine.DodajArtikle(a1, 1, 0, 2);
            VendingMachine.DodajArtikle(a1, 1, 0, 3);
            VendingMachine.DodajArtikle(a1, 1, 0, 4);
            VendingMachine.DodajArtikle(a1, 1, 0, 5);

            Artikal a2 = new Artikal("smoki", "2023-01-25", 20, "2023-01-24", 10);
            VendingMachine.DodajArtikle(a2, 1, 1, 0);
            VendingMachine.DodajArtikle(a2, 1, 1, 1);
            VendingMachine.DodajArtikle(a2, 1, 1, 2);
            VendingMachine.DodajArtikle(a2, 1, 1, 3);
            VendingMachine.DodajArtikle(a2, 1, 1, 4);
            VendingMachine.DodajArtikle(a2, 1, 1, 5);

            Artikal a3 = new Artikal("voda", "2023-01-25", 40, "2023-01-24", 10);
            VendingMachine.DodajArtikle(a3, 1, 2, 0);
            VendingMachine.DodajArtikle(a3, 1, 2, 1);
            VendingMachine.DodajArtikle(a3, 1, 2, 2);
            VendingMachine.DodajArtikle(a3, 1, 2, 3);
            VendingMachine.DodajArtikle(a3, 1, 2, 4);
            VendingMachine.DodajArtikle(a3, 1, 2, 5);

            Artikal a4 = new Artikal("zvaka", "2023-01-25", 5, "2023-01-24", 10);
            VendingMachine.DodajArtikle(a4, 1, 3, 0);
            VendingMachine.DodajArtikle(a4, 1, 3, 1);
            VendingMachine.DodajArtikle(a4, 1, 3, 2);
            VendingMachine.DodajArtikle(a4, 1, 3, 3);
            VendingMachine.DodajArtikle(a4, 1, 3, 4);
            VendingMachine.DodajArtikle(a4, 1, 3, 5);

            Artikal a5 = new Artikal("sok", "2023-01-25", 35, "2023-01-24", 10);
            VendingMachine.DodajArtikle(a5, 1, 4, 0);
            VendingMachine.DodajArtikle(a5, 1, 4, 1);
            VendingMachine.DodajArtikle(a5, 1, 4, 2);
            VendingMachine.DodajArtikle(a5, 1, 4, 3);
            VendingMachine.DodajArtikle(a5, 1, 4, 4);
            VendingMachine.DodajArtikle(a5, 1, 4, 5);

            Artikal a6 = new Artikal("jafa", "2023-01-25", 45, "2023-01-24", 10);
            VendingMachine.DodajArtikle(a6, 1, 5, 0);
            VendingMachine.DodajArtikle(a6, 1, 5, 1);
            VendingMachine.DodajArtikle(a6, 1, 5, 2);
            VendingMachine.DodajArtikle(a6, 1, 5, 3);
            VendingMachine.DodajArtikle(a6, 1, 5, 4);
            VendingMachine.DodajArtikle(a6, 1, 5, 5);

            OsveziEkran();

        }
        private void novcanica_Click(object sender, EventArgs e)
        {
            if (VendingMachine.StanjeArtikala() == 0)
            {
                MessageBox.Show(this, "Automat je trenutno prazan, ne prihvatamo novcanice");
                return;
            }
            VendingMachine.MojaKasa.PrimiNovcanicu(ParseVrednostNovcanice(((Button)sender).Text));
            kredit.Text = VendingMachine.MojaKasa.GetKreadit().ToString();
            stanjeKase.Text = VendingMachine.MojaKasa.GetStanjeKase().ToString();
        }

        private void vratiKusur_Click(object sender, EventArgs e)
        {
           int[] _kusur = VendingMachine.MojaKasa.kusur2();

            for (int i = 0; i < 8; i++)
            {
                for(int j=0; j < _kusur[i]; j++)
                    this.kusur.AppendText($"\n {VendingMachine.MojaKasa._dozvoljeneNovcanice[i]}");
            }

            OsveziEkran();
        }

        private void ubaciNovcanicu_Click(object sender, EventArgs e)
        {
            if (!VendingMachine.MojaKasa.dodaj(Convert.ToInt32(ubacenaNovcanica.Text)))
                MessageBox.Show("Ne postoji takva nocanica");

            stanjeKase.Text = VendingMachine.MojaKasa.GetStanjeKase().ToString();
        }

        private void preuzmiKusur_Click(object sender, EventArgs e)
        {
            kusur.Text = "";
            isporuceno.Text = "";

        }

        private void ispraznikasu_Click(object sender, EventArgs e)
        {
            VendingMachine.MojaKasa.ispraznikasu();
            OsveziEkran();
        }
    }
}