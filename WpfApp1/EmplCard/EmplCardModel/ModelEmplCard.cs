using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ViewEmpl.Model;


namespace EmplCard.Model
{
    public class ModelEmplCard : BaseNotifyClass
    {
        private string emplName;
        public string EmplName
        {
            get { return emplName;}
            set
            {
                emplName = value;
                NotifyPropertyChanged();
            }
        }

        private string department;
        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                NotifyPropertyChanged();
            }
        }

        private string scienceDegree;

        public string ScienceDegree
        {
            get { return scienceDegree; }
            set
            {
                scienceDegree = value;
                NotifyPropertyChanged();
            }
        }

        private double hours;
        public double Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                NotifyPropertyChanged();
            }
        }

        private string emplId;
        public string EmplId
        {
            get { return emplId; }
            set
            {
                emplId = value;
                
                NotifyPropertyChanged();
            }
        }

        private string position;
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                NotifyPropertyChanged();
            }
        }
        private string megaDep;
        public string MegaDep
        {
            get { return megaDep; }
            set
            {
                megaDep = value;
                NotifyPropertyChanged();
            }
        }
        private double stavka;
        public double Stavka
        {
            get { return stavka; }
            set
            {
                stavka = value;
                NotifyPropertyChanged();
            }
        }

        private double privStavka;
        public double PrivStavka
        {
            get { return privStavka; }
            set
            {
                privStavka = value;
                NotifyPropertyChanged();
            }
        }

        private string snizh_nagr;
        public string SnizhNagr
        {
            get { return snizh_nagr; }
            set
            {
                snizh_nagr = value;
                NotifyPropertyChanged();
            }
        }

        private double stavkaSnizh;
        public double StavkaSnizh
        {
            get { return stavkaSnizh; }
            set
            {
                stavkaSnizh = value;
                NotifyPropertyChanged();
            }
        }

        private double normativ;
        public double Normativ
        {
            get { return normativ; }
            set
            {
                normativ = value;
                NotifyPropertyChanged();
            }
        }

        private string subdivision;
        public string Subdivision
        {
            get { return subdivision; }
            set
            {
                subdivision = value;
                NotifyPropertyChanged();
            }
        }

        private double sop;
        public double Sop
        {
            get { return sop; }
            set
            {
                sop = value;
                NotifyPropertyChanged();
            }
        }
    }
}