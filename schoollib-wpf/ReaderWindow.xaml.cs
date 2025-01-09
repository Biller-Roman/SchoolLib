using schoollib_wpf.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace schoollib_wpf
{
    /// <summary>
    /// Логика взаимодействия для ReaderWindow.xaml
    /// </summary>
    public partial class ReaderWindow : Window
    {
        public List<AttachedBook> attachedBooks = new List<AttachedBook>();

        private void UpdateAttachedBookList()
        {
            attachedBookList.ItemsSource = null;
            attachedBookList.ItemsSource = attachedBooks;
        }

        public ReaderWindow()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            BookWindow bookWindow = new BookWindow();
            bookWindow.Title = "Добавить книгу";
            if (bookWindow.ShowDialog() == true)
            {
                string bookTitle = bookWindow.bookTitleTextBox.Text;
                string bookAuthor = bookWindow.bookAuthorTextBox.Text;

                var attachedBook = new AttachedBook()
                {
                    Title = bookTitle,
                    Author = bookAuthor,
                };

                attachedBooks.Add(attachedBook);
            }

            UpdateAttachedBookList();
        }

        private void deleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            var attachedBook = attachedBookList.SelectedItem as AttachedBook;
            if (attachedBook == null)
            {
                // Show error about missing item selected for deletion
                return;
            }

            attachedBooks.Remove(attachedBook);

            UpdateAttachedBookList();
        }
    }
}
