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
    public class GenreNonCrudWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private RestCollection<Album> getAllAlbumsWithGenre;
        public RestCollection<Album> GetAllAlbumsWithGenre
        {
            get { return getAllAlbumsWithGenre; }
            set { SetProperty(ref getAllAlbumsWithGenre, value); }
        }

        private RestCollection<KeyValuePair<string, int>> numberOfSongsInEachGenre;
        public RestCollection<KeyValuePair<string, int>> NumberOfSongsInEachGenre
        {
            get { return numberOfSongsInEachGenre; }
            set { SetProperty(ref numberOfSongsInEachGenre, value); }
        }

        private RestCollection<Genre> genres;
        public RestCollection<Genre> Genres
        {
            get { return genres; }
            set { SetProperty(ref genres, value); }
        }

        private Genre selectedGenre;
        public Genre SelectedGenre
        {
            get { return selectedGenre; }
            set
            {
                if (value != null)
                {
                    selectedGenre = new Genre()
                    {
                        GenreId = value.GenreId,
                        GenreName = value.GenreName,
                    };
                    OnPropertyChanged();
                    (GetAllAlbumsWithGenreCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand GetAllAlbumsWithGenreCommand { get; set; }
        public ICommand NumberOfSongsInEachGenreCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GenreNonCrudWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Genres = new RestCollection<Genre>("http://localhost:49755/", "genre", "hub");

                GetAllAlbumsWithGenreCommand = new RelayCommand(() =>
                {
                    GetAllAlbumsWithGenre = new RestCollection<Album>("http://localhost:49755/", $"statgenre/getallalbumswithgenre/{SelectedGenre.GenreId}", "hub");
                });

                NumberOfSongsInEachGenreCommand = new RelayCommand(() =>
                {
                    NumberOfSongsInEachGenre = new RestCollection<KeyValuePair<string, int>>("http://localhost:49755/", $"statgenre/numberofsongsineachgenre", "hub");
                });
            }
        }
    }
}
