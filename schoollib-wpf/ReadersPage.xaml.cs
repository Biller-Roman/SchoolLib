using schoollib_wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace schoollib_wpf
{
    /// <summary>
    /// Логика взаимодействия для ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Page
    {
        private void UpdateReaderList()
        {
            readerListView.ItemsSource = null;

            using (ApplicationContext context = new ApplicationContext())
            {
                var readers = context.Readers.ToList();
                readerListView.ItemsSource = readers;
            }
        }

        public ReadersPage()
        {
            InitializeComponent();

            UpdateReaderList();
        }

        private void createReaderButton_Click(object sender, RoutedEventArgs e)
        {
            ReaderWindow readerWindow = new ReaderWindow();
            readerWindow.Title = "Новый читатель";
            if (readerWindow.ShowDialog() == true)
            {
                string surname = readerWindow.surnameTextBox.Text;
                string name = readerWindow.nameTextBox.Text;
                string patronymic = readerWindow.patronymicTextBox.Text;
                int step = int.Parse(readerWindow.stepComboBox.Text);
                string parallel = readerWindow.parallelComboBox.Text;

                var reader = new Reader()
                {
                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    Step = step,
                    Parallel = parallel
                };

                using (ApplicationContext context = new ApplicationContext())
                {
                    context.Readers.Add(reader);
                    context.SaveChanges();
                }
            }

            UpdateReaderList();
        }

        private void readerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = readerListView.SelectedItem as Reader;
            if (item != null)
            {
                ReaderWindow readerWindow = new ReaderWindow();
                readerWindow.Title = "Изменение данных о читателе";
                readerWindow.surnameTextBox.Text = item.Surname;
                readerWindow.nameTextBox.Text = item.Name;
                readerWindow.patronymicTextBox.Text = item.Patronymic;
                readerWindow.stepComboBox.Text = item.Step.ToString();
                readerWindow.parallelComboBox.Text = item.Parallel;
                if (readerWindow.ShowDialog() == true)
                {
                    using (ApplicationContext context = new ApplicationContext())
                    {
                        item.Surname = readerWindow.surnameTextBox.Text;
                        item.Name = readerWindow.nameTextBox.Text;
                        item.Patronymic = readerWindow.patronymicTextBox.Text;
                        item.Step = int.Parse(readerWindow.stepComboBox.Text);
                        item.Parallel = readerWindow.parallelComboBox.Text;

                        context.Readers.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }

                UpdateReaderList();
            }
        }

        private void deleteReaderButton_Click(object sender, RoutedEventArgs e)
        {
            var item = readerListView.SelectedItem as Reader;
            if (item == null)
            {
                // Show error about missing item selected for deletion
                return;
            }

            using (ApplicationContext context = new ApplicationContext())
            {
                context.Readers.Remove(item);
                context.SaveChanges();
            }

            UpdateReaderList();
        }
    }
}