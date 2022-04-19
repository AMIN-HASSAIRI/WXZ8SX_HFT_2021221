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
    public class AlbumsNonCrudWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private RestCollection<Album> getAlbumsByArtist;
        public RestCollection<Album> GetAlbumsByArtist
        {
            get { return getAlbumsByArtist; }
            set { SetProperty(ref getAlbumsByArtist, value); }
        }
        private RestCollection<Album> getAlbumsByYear;
        public RestCollection<Album> GetAlbumsByYear
        {
            get { return getAlbumsByYear; }
            set { SetProperty(ref getAlbumsByYear, value); }
        }
        private RestCollection<KeyValuePair<string, double>> getLongestSongInEachAlbum;
        public RestCollection<KeyValuePair<string, double>> GetLongestSongInEachAlbum
        {
            get { return getLongestSongInEachAlbum; }
            set { SetProperty(ref getLongestSongInEachAlbum, value); }
        }

        private RestCollection<Genre> getGenreNameOfAlbumBySongId;
        public RestCollection<Genre> GetGenreNameOfAlbumBySongId
        {
            get { return getGenreNameOfAlbumBySongId; }
            set { SetProperty(ref getGenreNameOfAlbumBySongId, value); }
        }

        private RestCollection<Album> getBestAlbums;
        public RestCollection<Album> GetBestAlbums
        {
            get { return getBestAlbums; }
            set { SetProperty(ref getBestAlbums, value); }
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

        private Album selectedAlbum;
        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        AlbumId = value.AlbumId,
                        AlbumName = value.AlbumName,
                        ReleasedDate = value.ReleasedDate,
                        NumberOfSongs = value.NumberOfSongs,
                        Length = value.Length,
                        Rating = value.Rating,
                        ArtistId = value.ArtistId,
                        GenreId = value.GenreId,
                    };
                    OnPropertyChanged();
                    (GetAlbumsByYearCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
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
                    (GetAlbumsByArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand GetAlbumsByArtistCommand { get; set; }
        public ICommand GetAlbumsByYearCommand { get; set; }
        public ICommand GetLongestSongInEachAlbumCommand { get; set; }
        public ICommand GetBestAlbumsCommand { get; set; }
        public ICommand GetGenreNameOfAlbumBySongIdCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AlbumsNonCrudWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Artists = new RestCollection<Artist>("http://localhost:49755/", "artist", "hub");
                Albums = new RestCollection<Album>("http://localhost:49755/", "album", "hub");

                GetAlbumsByArtistCommand = new RelayCommand(() =>
                {
                    //GetAlbumsByArtistCmd(SelectedArtist.ArtistId);
                    GetAlbumsByArtist = new RestCollection<Album>("http://localhost:49755/", $"statalbum/getalbumsbyartist/{SelectedArtist.ArtistId}", "hub");
                });

                GetAlbumsByYearCommand = new RelayCommand(() =>
                {
                    GetAlbumsByYear = new RestCollection<Album>("http://localhost:49755/", $"statalbum/getalbumsbyyear/{SelectedAlbum.ReleasedDate.Year}", "hub");
                });

                GetLongestSongInEachAlbumCommand = new RelayCommand(() =>
                {
                    GetLongestSongInEachAlbum = new RestCollection<KeyValuePair<string, double>>("http://localhost:49755/", $"statalbum/getlongestsongineachalbum", "hub");
                });

                GetBestAlbumsCommand = new RelayCommand(() =>
                {
                    GetBestAlbums = new RestCollection<Album>("http://localhost:49755/", "statalbum/getbestalbums", "hub");
                });

            }
        }
    }
}
