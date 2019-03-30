﻿using System;
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
    }
}