using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfClient.Clients;
using WXZ8SX_HFT_2021221.Models;

namespace WpfClient.ViewModels
{
    public class SongsNonCrudWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private RestCollection<Song> getSongsOrderedByLength;
        public RestCollection<Song> GetSongsOrderedByLength
        {
            get { return getSongsOrderedByLength; }
            set { SetProperty(ref getSongsOrderedByLength, value); }
        }

        private RestCollection<Song> getSongsOrderedByName;
        public RestCollection<Song> GetSongsOrderedByName
        {
            get { return getSongsOrderedByName; }
            set { SetProperty(ref getSongsOrderedByName, value); }
        }

        public RestCollection<Song> Songs { get; set; }


        public ICommand GetSongsOrderedByLengthCommand { get; set; }
        public ICommand GetSongsOrderedByNameCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public SongsNonCrudWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<Song>("http://localhost:49755/", "song", "hub");

                GetSongsOrderedByLengthCommand = new RelayCommand(() =>
                {
                    GetSongsOrderedByLength = new RestCollection<Song>("http://localhost:49755/", $"statsong/getsongsorderedbylength", "hub");
                });

                GetSongsOrderedByNameCommand = new RelayCommand(() =>
                {
                    GetSongsOrderedByName = new RestCollection<Song>("http://localhost:49755/", "statsong/getsongsorderedbyname", "hub");
                });
            }
        }
    }
}
