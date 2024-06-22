using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetFilterFiles();
        }

        private void FileTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetFilterFiles();
        }
        private void GetFilterFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Temp\ispp21\LabWork33");
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            var result = files.Where(file=>file.Name.Contains(FilterFilesTextBox.Text))
                .Select(file=>new { file.Name, file.Extension, file.FullName, file.Length, file.CreationTime, file.LastAccessTime})
                .ToList();
            if (result.Count==0)
                ErrorLabel.Visibility = Visibility.Visible;
            else
                ErrorLabel.Visibility = Visibility.Collapsed;
            CountFilesLabel.Content = $"Показано: {result.Count} из {files.Count()}";
            ResultDataGrid.ItemsSource = result;
        }

        private void ClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilterFilesTextBox.Text = string.Empty;
        }
    }
}