﻿using System;
using Caliburn.Micro;

namespace BiavlerProjekt
{
    public class BiAvler : PropertyChangedBase
    {
        private static readonly Lazy<BiAvler> _instance = new Lazy<BiAvler>(() => new BiAvler());
        public static BiAvler Instance => _instance.Value;

        private string _text;
        private string _bistade;
        private string _date;
        private double _count;
        private BiAvler _task;

        public string Bistade
        {
            get => _bistade;
            set
            {
                _bistade = value;
                NotifyOfPropertyChange();
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                NotifyOfPropertyChange();
            }
        }

        public double Count
        {
            get => _count;
            set
            {
                _count = value;
                NotifyOfPropertyChange();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                NotifyOfPropertyChange();
            }
        }

        public BiAvler Task
        {
            get => _task;
            set
            {
                _task = value;
                NotifyOfPropertyChange();
            }

        }
    }
}