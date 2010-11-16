using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MvvmExample
{
    public class ViewModelClass : INotifyPropertyChanged
    {

        private string firstProperty;

        public string FirstProperty
        {
            get
            {
                return firstProperty;
            }

            set
            {
                firstProperty = value;
                RaisePropertyChanged("FirstProperty");
            }
        }

        private string secondProperty;

        public string SecondProperty
        {
            get
            {
                return secondProperty;
            }

            set
            {
                secondProperty = value;
                RaisePropertyChanged("SecondProperty");
            }
        }

        private List<string> thirdProperty;

        public List<string> ThirdProperty
        {
            get
            {
                return thirdProperty;
            }

            set
            {
                thirdProperty = value;
                RaisePropertyChanged("ThirdProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
