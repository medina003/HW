using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
namespace WPFMovieInfo
{
   
public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public SearchResult? Result { get; set; }
        private async void search_btn_Click(object sender, RoutedEventArgs e)
        {
            result_listbox.Items.Clear();
            string? json = await DownloadService.FindMovie(search_box.Text);
            Result  = await DeserealizeService.Deserialize(json);
            foreach(var item in Result.d)
            {
                result_listbox.Items.Add(item);
            }   
        }

        private async void result_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(result_listbox.SelectedItem != null)
            {
            var index = result_listbox.SelectedIndex;
            var selected_item = Result.d[index];
            name_lbl.Content = selected_item.l;
            style_lbl.Content = selected_item.q;
            type_lbl.Content = selected_item.qid;
            rank_lbl.Content = selected_item.rank;
            stars_lbl.Content = selected_item.s;
            year_lbl.Content = selected_item.y;
            runtime_lbl.Content = selected_item.yr;
            }

        }
    }
}
