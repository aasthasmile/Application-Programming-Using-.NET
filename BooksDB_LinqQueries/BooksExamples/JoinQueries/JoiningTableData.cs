// JoiningTableData.cs
// Using LINQ to perform a join and aggregate data across tables.
using System;
using System.Linq;
using System.Windows.Forms;

namespace JoinQueries
{
    public partial class JoiningTableData : Form
    {
        public JoiningTableData()
        {
            InitializeComponent();
        } // end constructor

        private void JoiningTableData_Load(object sender, EventArgs e)
        {
            // Entity Framework DBContext
            BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();

           /* var example = from author in dbcontext.Authors
                          from title in author.Titles
                          group author by author.AuthorID into authorGrouping
                          select authorGrouping;
           // var example2 = from author in dbcontext.Authors.Find();
            foreach (var element in example)
            {
                outputTextBox.AppendText(String.Format("\r\nkey :{0}", element.Key));
                foreach(var title in element)
                {
                    outputTextBox.AppendText(String.Format("\r\n\t {0} ",title.AuthorID) );
                }
            }
*/

          // get authors and ISBNs of each book they co-authored
          /*  var authorsAndISBNs =
               from author in dbcontext.Authors
               from book in author.Titles
               orderby author.LastName, author.FirstName
               select new { author.FirstName, author.LastName, book.ISBN };

            outputTextBox.AppendText("Authors and ISBNs:");
            // display authors and ISBNs in tabular format
            foreach (var element in authorsAndISBNs)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,-10} {1,-10} {2,-10}",
                   element.FirstName, element.LastName, element.ISBN));
            } // end foreach

            // get authors and titles of each book they co-authored
            var authorsAndTitles =
               from book in dbcontext.Titles
               from author in book.Authors
               orderby author.LastName, author.FirstName, book.Title1
               select new
               {   author.FirstName,author.LastName,book.Title1 };

            outputTextBox.AppendText("\r\n\r\nAuthors and titles:");

            // display authors and titles in tabular format
            foreach (var element in authorsAndTitles)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,-10} {1,-10} {2}",
                      element.FirstName, element.LastName, element.Title1));
            } // end foreach

            // get authors and titles of each book 
            // they co-authored; group by author
            var titlesByAuthor =
               from author in dbcontext.Authors
               orderby author.LastName, author.FirstName
               select new
               {
                   Name = author.FirstName + " " + author.LastName,
                   Titles =
                     from book in author.Titles
                     orderby book.Title1
                     select book.Title1
               };

            outputTextBox.AppendText("\r\n\r\nTitles grouped by author:");

            // display titles written by each author, grouped by author
            foreach (var author in titlesByAuthor)
            {
                // display author's name
                outputTextBox.AppendText("\r\n\t" + author.Name + ":");

                // display titles written by that author
                foreach (var title in author.Titles)
                {
                    outputTextBox.AppendText("\r\n\t\t" + title);
                } // end inner foreach
            } // end outer foreach */

          var authorsAndTitles_q1 =
               from book in dbcontext.Titles
               from author in book.Authors
               orderby book.Title1
               select new
               {
                   author.FirstName,
                   author.LastName,
                   book.Title1
               };

            outputTextBox.AppendText("\r\n\r\nAuthors and titles:");

            // display authors and titles in tabular format
            foreach (var element in authorsAndTitles_q1)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,-10} {1,-10} {2}",
                      element.FirstName, element.LastName, element.Title1));
            } // end foreach

            var authorsAndTitles_q2 =
               from book in dbcontext.Titles
               from author in book.Authors
               orderby  book.Title1,author.LastName,author.FirstName
               select new
               {
                   author.FirstName,
                   author.LastName,
                   book.Title1
               };

            outputTextBox.AppendText("\r\n\r\nAuthors and titles:");

            // display authors and titles in tabular format
            foreach (var element in authorsAndTitles_q2)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,-10} {1,-10} {2}",
                      element.FirstName, element.LastName, element.Title1));
            } // end foreach

            var authorsAndTitles_q3 =
              from title in dbcontext.Titles
              orderby title.Title1
              select new
               {
                   bookTitle = title.Title1,
                   Authors =
                     from author in title.Authors
                     orderby author.LastName, author.FirstName
                     select new { author.LastName, author.FirstName }
               };

            outputTextBox.AppendText("\r\n\r\nTitles grouped by Titles:");

            
            foreach (var titles in authorsAndTitles_q3)
            {
                outputTextBox.AppendText("\r\n\t" + titles.bookTitle + ":");
                foreach (var authors in titles.Authors)
                {
                    outputTextBox.AppendText(String.Format("\r\n\t\t{0} {1}", authors.FirstName,authors.LastName));
                } 
            } 

        } // end method JoiningTableData_Load
    } // end class JoiningTableData
} // end namespace JoinQueries

