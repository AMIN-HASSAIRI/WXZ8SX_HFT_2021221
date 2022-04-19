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
    public class ArtistsNonCrudWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private RestCollection<Album> getAlbumsOfArtist;
        public RestCollection<Album> GetAlbumsOfArtist
        {
            get { return getAlbumsOfArtist; }
            set { SetProperty(ref getAlbumsOfArtist, value); }
        }

        private RestCollection<Artist> getArtistsOrderedByBirthDate;
        public RestCollection<Artist> GetArtistsOrderedByBirthDate
        {
            get { return getArtistsOrderedByBirthDate; }
            set { SetProperty(ref getArtistsOrderedByBirthDate, value); }
        }

        private RestCollection<Artist> getArtistsOrderedByName;
        public RestCollection<Artist> GetArtistsOrderedByName
        {
            get { return getArtistsOrderedByName; }
            set { SetProperty(ref getArtistsOrderedByName, value); }
        }

        private RestCollection<Artist> getArtistsOrderedByNumOfAlbums;
        public RestCollection<Artist> GetArtistsOrderedByNumOfAlbums
        {
            get { return getArtistsOrderedByNumOfAlbums; }
            set { SetProperty(ref getArtistsOrderedByNumOfAlbums, value); }
        }

        private RestCollection<Album> albums;
        public RestCollection<Album> Albums
        {
            get { return albums; }
            set { SetProperty(ref albums, value); }
        }
        private RestCollection<Artist> artists;
        public RestCollection<Artist> Artists
        {
            get { return artists; }
            set { SetProperty(ref artists, value); }
        }

        private Artist selectedArtist;
        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new Artist()
                    {
                        ArtistId = value.ArtistId,
                        ArtistName = value.ArtistName,
                        DateOfBirth = value.DateOfBirth,
                        NumberOfAlbums = value.NumberOfAlbums,
                    };
                    OnPropertyChanged();
                    (GetAlbumsOfArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand GetAlbumsOfArtistCommand { get; set; }
        public ICommand GetArtistsOrderedByBirthDateCommand { get; set; }
        public ICommand GetArtistsOrderedByNameCommand { get; set; }
        public ICommand GetArtistsOrderedByNumOfAlbumsCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ArtistsNonCrudWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Artists = new RestCollection<Artist>("http://localhost:49755/", "artist", "hub");
                Albums = new RestCollection<Album>("http://localhost:49755/", "album", "hub");

                GetAlbumsOfArtistCommand = new RelayCommand(() =>
                {
                    GetAlbumsOfArtist = new RestCollection<Album>("http://localhost:49755/", $"statartist/getalbumsofartist/{SelectedArtist.ArtistId}", "hub");
                });

                GetArtistsOrderedByBirthDateCommand = new RelayCommand(() =>
                {
                    GetArtistsOrderedByBirthDate = new RestCollection<Artist>("http://localhost:49755/", $"statartist/getartistsorderedbybirthdate", "hub");
                });

                GetArtistsOrderedByNameCommand = new RelayCommand(() =>
                {
                    GetArtistsOrderedByName = new RestCollection<Artist>("http://localhost:49755/", $"statartist/getartistsorderedbyname", "hub");
                });

                GetArtistsOrderedByNumOfAlbumsCommand = new RelayCommand(() =>
                {
                    GetArtistsOrderedByNumOfAlbums = new RestCollection<Artist>("http://localhost:49755/", $"statartist/getartistsorderedbynumofalbums", "hub");
                });
            }
        }
    }
}
