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
    public class SongsWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Song> Songs { get; set; }

        private Song selectedSong;
        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (value != null)
                {
                    selectedSong = new Song()
                    {
                        SongId = value.SongId,
                        Name = value.Name,
                        Length = value.Length,
                        Writer = value.Writer,
                        Singer = value.Singer,
                        AlbumId = value.AlbumId,
                    };
                    OnPropertyChanged();
                    (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand AddSongCommand { get; set; }

        public ICommand DeleteSongCommand { get; set; }

        public ICommand EditSongCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public SongsWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<Song>("http://localhost:49755/", "song", "hub");
                AddSongCommand = new RelayCommand(() =>
                {
                    Songs.Add(new Song()
                    {
                        SongId = SelectedSong.SongId,
                        Name = SelectedSong.Name,
                        Length = SelectedSong.Length,
                        Writer = SelectedSong.Writer,
                        Singer = SelectedSong.Singer,
                        AlbumId = SelectedSong.AlbumId,
                    });
                });

                EditSongCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Songs.Update(SelectedSong);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteSongCommand = new RelayCommand(() =>
                {
                    Songs.Delete(SelectedSong.SongId);
                },
                () =>
                {
                    return SelectedSong != null;
                });
                SelectedSong = new Song();
            }
        }
    }
}
