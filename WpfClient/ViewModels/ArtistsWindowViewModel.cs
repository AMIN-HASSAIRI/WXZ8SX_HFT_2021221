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
    public class ArtistsWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Artist> Artists { get; set; }

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
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                    (AddArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                    (EditArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand AddArtistCommand { get; set; }

        public ICommand DeleteArtistCommand { get; set; }

        public ICommand EditArtistCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ArtistsWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Artists = new RestCollection<Artist>("http://localhost:49755/", "artist", "hub");
                AddArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        ArtistId = SelectedArtist.ArtistId,
                        ArtistName = SelectedArtist.ArtistName,
                        DateOfBirth = SelectedArtist.DateOfBirth,
                        NumberOfAlbums = SelectedArtist.NumberOfAlbums,
                    });
                });

                EditArtistCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Artists.Update(SelectedArtist);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteArtistCommand = new RelayCommand(() =>
                {
                    Artists.Delete(SelectedArtist.ArtistId);
                },
                () =>
                {
                    return SelectedArtist != null;
                });
                SelectedArtist = new Artist();
            }
        }
    }
}
