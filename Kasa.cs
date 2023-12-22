using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Kasa
    {
        public readonly int[] _dozvoljeneNovcanice = new int[8] { 200, 100, 50, 20, 10, 5, 2, 1 };

        private int[] _stanje = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

        private decimal _kredit;

        public decimal GetKreadit()
        {
            return _kredit;
        }

        public void SetKredit(decimal cena)
        {
            this._kredit -= cena;
        }

        public bool PrimiNovcanicu(int _novcanica)
        {
            if (!_dozvoljeneNovcanice.Contains(_novcanica))
                return false;
            else
            {
                _kredit += _novcanica;
                dodaj(_novcanica);
                return true;
            }
        }

        public bool dodaj(int novac)
        {
            if (!_dozvoljeneNovcanice.Contains(novac))
                return false;
            else
            {
                switch (novac)
                {
                    case 200:
                        _stanje[0]++;
                        break;
                    case 100:
                        _stanje[1]++;
                        break;
                    case 50:
                        _stanje[2]++;
                        break;
                    case 20:
                        _stanje[3]++;
                        break;
                    case 10:
                        _stanje[4]++;
                        break;
                    case 5:
                        _stanje[5]++;
                        break;
                    case 2:
                        _stanje[6]++;
                        break;
                    case 1:
                        _stanje[7]++;
                        break;
                }
                return true;
            }
        }

        public int GetStanjeKase()
        {
            int pomocnostanje = 0;
            for (int i = 0; i < 8; i++)
            {
                pomocnostanje += _stanje[i] * _dozvoljeneNovcanice[i];
            }

            return pomocnostanje;
        }
        public int[] kusur2()
        {
            int izbacenanovcanica = 0;
            int[] najboljeResenje = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            decimal najboljiKusur = 0;
            decimal razlika = _kredit;
            for (int j = 0; j < 8; j++)
            {
                int[] _pomStanie = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] izabaceneNovcanice = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int z=0; z<8; z++)
                {
                    _pomStanie[z] = _stanje[z];
                }
                decimal _pomKredit = 0;
                bool _dosloDoPromene = false;
                for (int k=j; k< 8 ; k++)
                {
                    int pom = _dozvoljeneNovcanice[k];
                    izbacenanovcanica = 0;
                    for (int i = 0; i < _pomStanie[k]; i++)
                    {
                        if (_pomKredit + pom <= _kredit)
                        {
                            _pomKredit += pom;
                            izbacenanovcanica++;

                        }
                        else
                            break;
                    }
                    decimal _pomRazlika = _kredit - _pomKredit;
                    if(_pomRazlika < razlika)
                    {
                        _dosloDoPromene = true;
                        razlika = _pomRazlika;
                        _pomStanie[k] -= izbacenanovcanica;
                        izabaceneNovcanice[k] += izbacenanovcanica;
                    }
                }
                if (_dosloDoPromene)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        najboljeResenje[z] = izabaceneNovcanice[z];
                        najboljiKusur = _pomKredit;
                    }
                }
                if(razlika == 0)
                {
                    break;
                }
            }
            _kredit -= najboljiKusur;
            for(int i=0; i< 8; i++)
            {
                _stanje[i] -= najboljeResenje[i];
            }
            return najboljeResenje;
        }
        public int[] kusur()
        {
            int izbacenanovcanica = 0;
            int[] izabaceneNovcanice = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int j = 0; j < 8; j++)
            {
                int pom = _dozvoljeneNovcanice[j];
                for (int i = 0; i < _stanje[j]; i++)
                {
                    if (pom <= _kredit)
                    {
                        _kredit -= pom;
                        izbacenanovcanica++;

                    }
                    else
                        break;
                }

                _stanje[j] -= izbacenanovcanica;
                izabaceneNovcanice[j] += izbacenanovcanica;
                izbacenanovcanica = 0;
            }

            return izabaceneNovcanice;
        }

        public void ispraznikasu()
        {
            for (int i = 0; i < 8; i++)
            {
                _stanje[i] = 0;
            }
            _kredit = 0;
        }
    }
}
