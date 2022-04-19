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
    public class AlbumsWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Album> Albums { get; set; }

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
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand AddAlbumCommand { get; set; }

        public ICommand DeleteAlbumCommand { get; set; }

        public ICommand EditAlbumCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AlbumsWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:49755/", "album", "hub");
                AddAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        AlbumId = SelectedAlbum.AlbumId,
                        AlbumName = SelectedAlbum.AlbumName,
                        ReleasedDate = SelectedAlbum.ReleasedDate,
                        NumberOfSongs = SelectedAlbum.NumberOfSongs,
                        Length = SelectedAlbum.Length,
                        Rating = SelectedAlbum.Rating,
                        ArtistId = SelectedAlbum.ArtistId,
                        GenreId = SelectedAlbum.GenreId,
                    });
                });

                EditAlbumCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Albums.Update(SelectedAlbum);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Delete(SelectedAlbum.AlbumId);
                },
                () =>
                {
                    return SelectedAlbum != null;
                });

                SelectedAlbum = new Album();
            }
        }
    }
}
