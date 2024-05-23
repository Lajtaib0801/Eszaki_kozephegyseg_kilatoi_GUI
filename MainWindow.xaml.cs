using Eszaki_kozephegyseg_kilatoi_GUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eszaki_kozephegyseg_kilatoi_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        

        private ObservableCollection<ViewpointModel> viewpoints;

        public ObservableCollection<ViewpointModel> Viewpoints
        {
            get { return viewpoints; }
            set { viewpoints = value; OnPropertyChanged(nameof(Viewpoints)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<LocationModel> Locations { get; set; }
        Context context = new();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            context.Locations.Load();
            context.Viewpoints.Load();
            Locations = context.Locations.Local.ToObservableCollection();
            viewpoints_DG.ItemsSource = Viewpoints;
        }

        private void mountains_LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocationModel selectedMountain = (LocationModel)mountains_LB.SelectedItem;
            if (selectedMountain != null)
            {
                Viewpoints = new ObservableCollection<ViewpointModel>(context.Viewpoints.Local.Where(x => x.location == selectedMountain.id).ToList());
            }
            viewpoints_DG.ItemsSource = Viewpoints;
        }

        private void viewpoints_DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewpoints_DG.SelectedItem is not null)
            {
                viewpoint_IMG.Source = new BitmapImage(new Uri(((ViewpointModel)viewpoints_DG.SelectedItem).imageUrl));
                description_LB.Text = ((ViewpointModel)viewpoints_DG.SelectedItem).description;
            }
        }
    }
}
